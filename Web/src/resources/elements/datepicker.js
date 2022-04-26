import {inject, customAttribute} from 'aurelia-framework';
// import {datetimepicker } from 'jquery-ui';

@customAttribute('datepicker')
@inject(Element)
export class CustomDatePicker {
  constructor(element) {
    this.element = element;
  }
  
  // attached() {
  //   $(this.element).datetimepicker()
  //     .on('change', e => fireEvent(e.target, 'input'));
    
  // }
  
  // detached() {
  //   $(this.element).datetimepicker('destroy')
  //     .off('change');
  // }
}

// function createEvent(name) {
//   var event = document.createEvent('Event');
//   event.initEvent(name, true, true);
//   return event;
// }

// function fireEvent(element, name) {
//   var event = createEvent(name);
//   element.dispatchEvent(event);
// }