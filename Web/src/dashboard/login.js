import { baseUrl } from 'resources/utilities/utilities';

export class Login {
	constructor() {
		window.location.href = baseUrl() + "/home#login";
	};
}
