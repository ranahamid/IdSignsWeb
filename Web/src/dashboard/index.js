import { inject, DOM } from 'aurelia-framework';
import { EntityManager } from 'aurelia-orm';
import { App } from 'dashboard/app';

@inject(EntityManager, App, DOM.Element)
export class Index { 
  attached() {
    this.$BODY = $('body');
    this.$SIDEBAR_FOOTER = $(this.element).find('.sidebar-footer');
    this.$LEFT_COL = $('.left_col');
    this.$RIGHT_COL = $('.right_col');
    this.$NAV_MENU = $(this.element).find('.nav_menu');
    this.$FOOTER = $(this.element).find('footer');

    this.$BODY.scrollTop(0);

    this.setContentHeight();
  }

  detached() {
  }

  setContentHeight() {
    this.$RIGHT_COL.css('min-height', $(window).height());

    var bodyHeight = this.$BODY.outerHeight(),
      footerHeight = this.$BODY.hasClass('footer_fixed') ? -10 : this.$FOOTER.height(),
      leftColHeight = this.$LEFT_COL.eq(1).height() + this.$SIDEBAR_FOOTER.height(),
      contentHeight = bodyHeight < leftColHeight ? leftColHeight : bodyHeight;

    // normalize content
    contentHeight -= this.$NAV_MENU.height() + footerHeight;

    this.$RIGHT_COL.css('min-height', contentHeight);
  }
}