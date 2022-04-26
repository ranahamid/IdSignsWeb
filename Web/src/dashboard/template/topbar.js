import { inject, bindable } from 'aurelia-framework';
import { AuthService } from 'aurelia-authentication';
import { baseUrl } from 'resources/utilities/utilities';

@inject(Element, AuthService)
export class Topbar {
	$BODY;
	$SIDEBAR_MENU;
	$MENU_TOGGLE;

	@bindable profileImage;

	constructor(element, authService) {
		this.element = element;
		this.authService = authService;
	}

	attached() {
		this.$BODY = $('body');
		this.$SIDEBAR_MENU = $('#sidebar-menu');
		this.$MENU_TOGGLE = $('#menu_toggle');
		
		$(this.$MENU_TOGGLE).on('click', () => {
			if (this.$BODY.hasClass('nav-md')) {
				this.$SIDEBAR_MENU.find('li.active ul').hide();
				this.$SIDEBAR_MENU.find('li.active').addClass('active-sm').removeClass('active');
				 $('.nav_title img').attr('src', '../../../Images/logo_img_only.png');
			} else {
				this.$SIDEBAR_MENU.find('li.active-sm ul').show();
				this.$SIDEBAR_MENU.find('li.active-sm').addClass('active').removeClass('active-sm');
				 $('.nav_title img').attr('src', '../../../Images/logo.png');
			}
		});
	}

	detached() {
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