import { inject } from 'aurelia-framework';
import { ValidationControllerFactory, ValidationController, ValidationRules } from 'aurelia-validation';
import { BootstrapFormRenderer } from 'resources/renderer/bootstrap-form-renderer';
import { EntityManager } from 'aurelia-orm';

@inject(ValidationControllerFactory, EntityManager)
export class ForgotPassword {
  password;

  constructor(controllerFactory, entityManager) {
    this.controller = controllerFactory.createForCurrentScope();
    this.controller.addRenderer(new BootstrapFormRenderer());
    this.entity = entityManager.getEntity('forgotpassword');
  }

  submit() {
    this.controller.validate()
      .then(result => {
        if(result.valid){
          toastr.info('Please wait while we process your request.');
          
          var data = {
            Email: this.email
          }
          this.entity.setData(data)
            .save()
            .then(response => {
              debugger;
              if(response.Status === 502)
							{
								toastr.error(response.Message);
                return;
							}

              toastr.success(response);
            })
            .error(err => {
              console.log(err);
							toastr.error('An error occured. Please try again.');
            })
        }
      })
  }
}
ValidationRules
  .ensure(a => a.email).required().email()
  .on(ForgotPassword);