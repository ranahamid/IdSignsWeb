import { AuthService } from 'aurelia-authentication';
import { inject } from 'aurelia-framework';
import { baseUrl } from 'resources/utilities/utilities';

@inject(AuthService)
export class Logout {
	constructor(authService) {
		this.authService = authService;
	};

	activate() {
		let logoutRedirect = baseUrl() + '/home#login'
		this.authService.logout(logoutRedirect)
			.then(response => {
				localStorage.removeItem('user_email')
				localStorage.removeItem('email_confirmed');
				localStorage.removeItem('auto_resend_email');
				console.log("ok logged out on  logout.js");
			})
			.catch(err => {
				console.log("error logged out  logout.js");
			});
	}
}