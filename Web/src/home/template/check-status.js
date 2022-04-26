import {inject, NewInstance} from 'aurelia-framework';
import {AuthService} from 'aurelia-authentication';
import {ValidationController, ValidationRules} from 'aurelia-validation';
import {BootstrapFormRenderer} from 'resources/renderer/bootstrap-form-renderer';

@inject(NewInstance.of(ValidationController))
export class CheckStatus{
  viewBy = 'diner';
  email;

  constructor(controller){
    debugger
    this.controller = controller;
		this.controller.addRenderer(new BootstrapFormRenderer());
  }

  submit(){
    debugger;
    this.controller.validate();
  }
}

ValidationRules  
  .ensure(x => x.email).required().email()
  .on(CheckStatus);