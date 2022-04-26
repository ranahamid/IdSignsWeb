import { EntityManager } from 'aurelia-orm';
import { inject, NewInstance, computedFrom } from 'aurelia-framework';
import { ValidationController, ValidationRules } from 'aurelia-validation';
import { BootstrapFormRenderer } from 'resources/renderer/bootstrap-form-renderer';
import { Router } from 'aurelia-router';
import Constants from 'resources/utilities/constants';

@inject(EntityManager, NewInstance.of(ValidationController), Router, Element)
export class CompanyDetail {
  id;
  name;
  address;
  entity;

  constructor(entityManager, controller, router, element) {
    this.repository = entityManager.getRepository('company');
    this.controller = controller;
    this.router = router;
    this.element = element;
  }

  activate(params, routeConfig) {
    this.loading = true;

    this.id = params.id === undefined ? Constants.NEW_ID : params.id;

    return this.repository.find(this.id)
      .then( response => {
        this.id = response.Id;
        this.name = response.Name;
        this.address = response.Address;
        this.entity = response;

        this.loading = false;
      })
      .catch(err => {
        this.loading = false;
        toastr.error(Constants.ERROR_IN_FETCHING);
        console.log(err);
      })
  }

  attached() {
    $('body').scrollTop(0);
		$("#name").focus();
  }

  submit() {
    this.loading = true;

    this.controller.validate()
      .then(validationResult => {
        if(!validationResult.valid)
        {
          toastr.error(Constants.CORRECT_VALIDATION_ERRORS);
          return;
        }
        
        toastr.info(Constants.REQUEST_PROCESSING);

        this.entity.Name = this.name;
        this.entity.Address = this.address;

        return this.entity.save()
          .then(response => {
            toastr.success(Constants.SAVED_SUCCESSFULLY);
            this.router.navigate('/company');
          })
          .catch(error => {
            console.error(error);
            this.loading = false;
          });
      })
  }
}

ValidationRules
  .ensure('name').required().maxLength(100)
	.ensure('address').maxLength(500)
  .on(CompanyDetail);