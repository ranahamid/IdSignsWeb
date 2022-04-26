import { inject, DOM, bindable, computedFrom } from 'aurelia-framework';
import Constants from 'resources/utilities/constants';

@inject(DOM.Element)
export class Sidebar {	
	NEW_ID = Constants.NEW_ID;

	$BODY;
	$SIDEBAR_MENU;
	$SIDEBAR_FOOTER;
	$LEFT_COL;
	$RIGHT_COL;
	$NAV_MENU;
	$FOOTER;

	@bindable profileImage;
	@bindable username;

	constructor(element) {
		this.element = element;
	}

	attached() {
		this.$BODY = $('body');
		this.$SIDEBAR_MENU = $(this.element).find('#sidebar-menu');
		this.$SIDEBAR_FOOTER = $(this.element).find('.sidebar-footer');
		this.$LEFT_COL = $('.left_col');
		this.$RIGHT_COL = $('.right_col');
		this.$NAV_MENU = $(this.element).find('.nav_menu');
		this.$FOOTER = $(this.element).find('footer');

		this.$SIDEBAR_MENU.find('a').on('click', (e) => {
			let target = e.target.id;
			var $li = $('#' + target).parent();

			if ($li.hasClass('active')) {
				$li.removeClass('active active-sm');
				$('ul:first', $li).slideUp(() => {
					this.setContentHeight();
				});
			} else {
				// prevent closing menu if we are on child menu
				if (!$li.parent().hasClass('child_menu')) {
					this.$SIDEBAR_MENU.find('li').removeClass('active active-sm');
					this.$SIDEBAR_MENU.find('li ul').slideUp();
				}
				else {
					$li.siblings().removeClass('active');
				}

				$li.addClass('active');

				$('ul:first', $li).slideDown(() => {
					this.setContentHeight();
				});
			}
		});

		this.setContentHeight();

		// fixed sidebar
		if ($.fn.mCustomScrollbar) {
			$('.menu_fixed').mCustomScrollbar({
				autoHideScrollbar: true,
				theme: 'minimal',
				mouseWheel: { preventDefault: true }
			});
		}
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

	logout() {
		let logoutRedirect = baseUrl() + '/home#login'
		this.authService.logout(logoutRedirect)
			.then(response => {
				console.log("ok logged out on  logout.js");
			})
			.catch(err => {
				console.log("error logged out  logout.js");
			});
	}
}