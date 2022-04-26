import {inject} from 'aurelia-framework';
import {AuthService} from 'aurelia-authentication';
import { ValidationControllerFactory, ValidationController, ValidationRules} from 'aurelia-validation';
import {BootstrapFormRenderer} from 'resources/renderer/bootstrap-form-renderer';

@inject(ValidationControllerFactory, AuthService)
export class Register {
  username;
	email;
	password;
	controller;
	
	constructor(controllerFactory,auth) {
		this.auth = auth;
		if(this.auth.isAuthenticated()){
			window.location.href="/dashboard";
		}
		else
		{
			this.controller = controllerFactory.createForCurrentScope();
			this.controller.addRenderer(new BootstrapFormRenderer());
		}
			
	}

	submit() {
		this.controller.validate()
			.then(result => {
				if(result.valid){
					toastr.info('We are creating your account...');
					var userInfo = { 
            Username: this.username,
						Email: this.email, 
						Password: this.password, 
					}
					this.auth.signup(userInfo)
						.then(result => {							
								toastr.success(result);
						})
						.catch(error => {
							toastr.error('An error occured. Please try again!');
							console.log(error.response);
						});	
				}
				else {
					let errors = '';
					for(let item of result.results){
						if(!item.valid)
							errors += item.message + "\r\n";
					}
					toastr.error(errors);
				}						
		});
	}
}

ValidationRules
  .ensure('firstName').required()
	.ensure('lastName').required()
  .ensure('email').required().email()
  .ensure('password').required().minLength(6).maxLength(15)
  .on(Register);