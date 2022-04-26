import { inject } from 'aurelia-framework';
import { EntityManager } from 'aurelia-orm';

@inject(EntityManager)
export class ConfirmEmail {
  constructor(entityManager) {
    this.resendEmailRepository = entityManager.getRepository('resend-email');
  }

  attached() {
    this.email = localStorage.getItem('user_email');
  }

  detached() { }

  resendEmail() {
    toastr.info('A confirmation email is sending...');
    return this.resendEmailRepository.find()
      .then(response => {
        toastr.success("Successfully re-sent confirmation email.");
      })
      .catch(err => {
        console.log(err);
        toastr.error('An error occured. Please try again.');
      });
  }
}