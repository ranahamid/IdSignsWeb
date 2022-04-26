import {bindable, bindingMode, inject} from 'aurelia-framework';

@inject(Element)
export class Select2MultipleCustomElement {
  @bindable name = null;    // name/id of custom select
  @bindable selected = [];  // default selected values
  @bindable options = {};   // array of options with id/name properties
  @bindable placeholder = "";
  @bindable allow_clear = false;
  @bindable max_item = null;
  @bindable with_group = false;
  @bindable tags = false;

  constructor(element) {
    this.element = element;
  }

  attached() {
    var el = $(this.element).find('select');
    var sel = el.select2();

    // preload selected values
    sel.val(this.selected).trigger('change');

    // on any change, propagate it to underlying select to trigger two-way bind
    sel.on('change', (event) => {
      // don't propagate endlessly
      // see: http://stackoverflow.com/a/34121891/4354884
      if (event.originalEvent) { return; }
      // dispatch to raw select within the custom element
      // bubble it up to allow change handler on custom element
      var notice = new Event('change', {bubbles: true});
      $(el)[0].dispatchEvent(notice);
    });
  }

  detached() {
    $(this.element).find('select').select2('destroy');
  }
}