import { AuthenticateStep, AuthService } from 'aurelia-authentication';
import { inject, computedFrom } from 'aurelia-framework';
import { EntityManager } from 'aurelia-orm';
import { ResendEmail } from 'dashboard/config/entity/resend-email';
import { baseUrl } from 'resources/utilities/utilities';

@inject(AuthService, EntityManager)
export class App {
  constructor(authService, entityManager) {
    this.authService = authService;
    this.resendEmailRepository = entityManager.getRepository(ResendEmail);
  }

  configureRouter(config, router) {
    config.title = 'Dashboard';
    config.addPipelineStep('authorize', AuthorizeStep);
    config.map([
      { route: ['', 'index'], name: 'index', moduleId: 'dashboard/index', nav: true, auth: true, title: 'Home' },
      { route: 'login', name: 'login', moduleId: 'dashboard/login', title: 'login' },
      { route: 'profile', name: 'profile', moduleId: 'authorization/profile', title: 'profile' },      
      { route: 'confirm-email', name: 'confirm-email', moduleId: 'authorization/confirm-email', nav: false, title: 'Confirm Email', auth: true, },
      { route: 'company', name: 'company', moduleId: 'dashboard/company/companies', nav: true, auth: true, title: 'Companies' },  
      { route: 'company:id', name: 'companyDetail', moduleId: 'dashboard/company/company-detail', href:"#companyDetail", nav: true, auth: true, title: 'Channels' },   
      { route: 'channel', name: 'channel', moduleId: 'dashboard/channel/channels', nav: true, auth: true, title: 'Channels' },  
      { route: 'channel:id', name: 'channelDetail', moduleId: 'dashboard/channel/channel-detail', href:"#channelDetail", nav: true, auth: true, title: 'Channel Detail' },    
    ]);
    
    this.router = router;
  }

  activate() {
    this.authService.getMe()
      .then(response => {
        this.userInfo.profileImage = response.ProfileImageUrl;
        this.userInfo.username = response.Username;
        this.userInfo.email = response.Email;
      })
      .catch(err => {
        console.log(err);
      });
  }

  attached() {    
  }

  detached() {
  }

  // use computedFrom to avoid dirty checking
  @computedFrom('authService.authenticated')
  get isAuthenticated() {
    return this.authService.authenticated;
  }

  get emailConfirmed() {
    return localStorage.getItem('email_confirmed') == 'yes' ? true : false;
  }

  // If the doesn't confirmed email yet and registration is only one day old
  get autoResendEmail() {
    // return localStorage.getItem('auto_resend_email') == 'yes' ? true : false;
    return false;
  }
}

@inject(App)
class AuthorizeStep {
  constructor(app) {
    this.app = app;
  }

  run(navigationInstruction, next) {
    if (navigationInstruction.getAllInstructions().some(i => i.config.auth)) {
      if (!this.app.isAuthenticated)
        window.location.href = baseUrl() + "/home#/login";
      // else if (!this.app.emailConfirmed)        // Check if the user already confirms email, if not redirect to resend email page
      //   this.app.router.navigate('confirm-email')
    }

    return next();
  }
}
