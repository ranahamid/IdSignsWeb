import { inject } from 'aurelia-framework';
import { ValidationControllerFactory, ValidationController, ValidationRules } from 'aurelia-validation';
import { BootstrapFormRenderer } from 'resources/renderer/bootstrap-form-renderer';
import { EntityManager } from 'aurelia-orm';
import { Router } from 'aurelia-router';
import { getParameterByName } from 'resources/utilities/utilities';

@inject(ValidationControllerFactory, EntityManager, Router)
export class ResetPassword {
  password;
  code;
  userId;

  constructor(controllerFactory, entityManager, router) {
    this.controller = controllerFactory.createForCurrentScope();
    this.controller.addRenderer(new BootstrapFormRenderer());
    this.entity = entityManager.getEntity('resetpassword');
    this.router = router;
  }

  submit() {
    this.code = getParameterByName('code');
    this.userId = getParameterByName('userId');

    if (!this.code || !this.userId) {
      toastr.error('Code or User Id can not be empty.');
      return;
    }

    this.controller.validate()
      .then(result => {
        if (result.valid) {
          toastr.info('Please wait while we process your request.');

          let data = {
            Code: this.code,
            Password: this.password,
            UserId: this.userId,
          }

          this.entity.setData(data)
            .save()
            .then(response => {
              if (response.Status === 502) {
                toastr.error(response.Message);
                return;
              }

              toastr.success(response);
              this.router.navigate('/login');
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
  .ensure(a => a.password).required().minLength(6).maxLength(15)
  .on(ResetPassword);