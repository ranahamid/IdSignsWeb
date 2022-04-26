export class App {
  $body;
  $nav_menu;
  $footer;
  $main_content;

  constructor() {
  }

  configureRouter(config, router) {
    config.title = 'App';
    config.map([
      { route: ['', 'login'], name: 'login', moduleId: 'authorization/login', nav: false, title: 'Sign In' },
      { route: 'login', name: 'login', moduleId: 'authorization/login', nav: false, title: 'Sign In' },
      { route: 'register', name: 'register', moduleId: 'authorization/register', nav: false, title: 'Sign Up' },
      { route: 'forgot', name: 'forgot', moduleId: 'authorization/forgot-password', nav: false, title: 'Forgot Password' },
      { route: 'logout', name: 'logout', moduleId: 'authorization/logout', nav: false, title: 'logout', auth: true, },
      { route: 'reset-password', name: 'reset-password', moduleId: 'authorization/reset-password', nav: false, title: 'Reset Password' }
    ]);

    this.router = router;
  }

  attached() {
    this.$body = $('body');
    this.$nav_menu = $('.navbar-default');
    this.$footer = $('footer');
    this.$main_content = $('.main-content');
    this.setContentHeight();
  }

  detached() { }

  setContentHeight() {
    let contentHeight = $(window).height() - this.$nav_menu.outerHeight() - this.$footer.outerHeight();
    this.$main_content.css('min-height', contentHeight);
  }
}