import {inject, NewInstance} from 'aurelia-framework';
import {Router} from 'aurelia-router';

@inject(Router)
export class ConfirmEmailNavBar{
  constructor(router){
    debugger;
    this.router = router;
  }
  redirectLogin(){
    this.router.navigate('login');
  }

  get baseURL(){
    if (!location.origin)
      location.origin = location.protocol + "//" + location.host;
    return location.origin;
  }
}