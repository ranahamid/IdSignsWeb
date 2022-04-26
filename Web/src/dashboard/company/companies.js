import { inject, observable } from 'aurelia-framework';
import { EntityManager } from 'aurelia-orm';
import Constants from 'resources/utilities/constants';

@inject(EntityManager)
export class Companies {
  id;
  list = [];
  hasItems = true;
  deleteModalId = Constants.DELETE_MODAL_ID;
  deleteHeading = Constants.DELETE_MODAL_HEADING;

  constructor(entityManager) {
    this.repository = entityManager.getRepository('company');
  }

  activate() {
    this.loading = true;
    return this.repository.find()
      .then(response => {
        this.loading = false;
        this.list = response;
        this.hasItems = response.length > 0;
      })
      .catch(err => {
        toastr.error(Constants.ERROR_IN_FETCHING);
      })
  }

  attached() {
    $('body').scrollTop(0);

    $('#' + this.deleteModalId).find('#okButton').click(() => {
      this.loading = true;
      toastr.info(Constants.REQUEST_PROCESSING);

      this.repository.find(this.id)
      .then(entity => {
        entity.setId(entity.Id);
        return entity.destroy()
      })
      .then(response => {
        this.loading = false;
        toastr.success(Constants.DELETED_SUCCESSFULLY);
        this.list = response;
      })
      .catch(err => toastr.error(err.Error));         
    });
  }

  delete(id) {
    this.id = id;
    return $('#' + this.deleteModalId).modal('show');
  }
}