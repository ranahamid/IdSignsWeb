import {inject, customAttribute, DOM, TaskQueue} from 'aurelia-framework';

@inject(DOM.Element, TaskQueue)
@customAttribute('ddl')
export class Select2CustomAttribute {
  
  constructor(element, taskQueue) {
    this.element = element;
    this.taskQueue = taskQueue;
  }
  
  bind(bindingContext) {
    this.bindingContext = bindingContext;
  }
  
  attached() {
    this.taskQueue.queueMicroTask(() => {
      this.create();
    });
  }
  
  create() {
    //Object.assign(defaultOpts, this.options);
    $(this.element).select2()
      .on('change', (evt) => {
        if (evt.originalEvent) {
          return;
        }
        this.element.dispatchEvent(new Event('change', { bubbles: true }));
        
        //reset value to avoid multiple-select problems
        let value = this.bindingContext[this.element.getAttribute('value.bind')];
        this.bindingContext[this.element.getAttribute('value.bind')] = [];
        this.bindingContext[this.element.getAttribute('value.bind')] = value;
      });
  }
  
}