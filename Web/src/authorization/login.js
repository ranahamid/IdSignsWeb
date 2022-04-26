import {AuthService} from 'aurelia-authentication';
import {inject, computedFrom} from 'aurelia-framework';
import {ValidationControllerFactory, ValidationRules} from 'aurelia-validation';
import {BootstrapFormRenderer} from 'resources/renderer/bootstrap-form-renderer';

@inject(ValidationControllerFactory, AuthService)
export class Login {
	username = '';
	password = '';
	controller = null;
	rememberMe = false;

	constructor(controllerFactory, authService){
		this.authService = authService;
		this.controller = controllerFactory.createForCurrentScope();
		this.controller.addRenderer(new BootstrapFormRenderer());	
	}

	activate(){
		if(this.isAuthenticated){
				window.location.href="/dashboard";
		}
	}
	
	submit() {
		return this.controller.validate()
			.then(result => {
				if(result.valid){
					toastr.info("You are now sign in to eatsy");
					this.authService.login({
						username: this.username,
						password: this.password,
						grant_type: "password"
					}, {headers: {'Content-Type': 'application/x-www-form-urlencoded'}})  
						.then(response => {
							toastr.success('Login successful');
						})
						.catch(err => {
							toastr.error("Invalid email or password."); 
						});
				}
			})		
	};

	canActivated(){
		if(this.auth.authenticated()){
				window.location.href="/";
		}
	}

	authenticate(name) {
		return this.authService.authenticate(name)
		.then(response => {
			console.log("auth response " + response);
		})
		.catch(err => {
			console.log(err);
		});
	}

	// use computedFrom to avoid dirty checking
	@computedFrom('authService.authenticated')
	get isAuthenticated() {
		return this.authService.authenticated;
	}

	setRemember(){
		if(this.rememberMe)
			localStorage.setItem("aurelia-remember", 'yes');
		else
			localStorage.removeItem("aurelia-remember");
	}
}


ValidationRules
  .ensure(a => a.username).required()
  .ensure(a => a.password).required()
  .on(Login);