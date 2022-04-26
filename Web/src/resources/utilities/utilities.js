export function areEqual(obj1, obj2) {
	return Object.keys(obj1).every((key) => obj2.hasOwnProperty(key) && (obj1[key] === obj2[key]));
};

export function baseUrl() {
	if (!location.origin)
		location.origin = location.protocol + "//" + location.host;
	return location.origin;
}

export function getParameterByName(name, url) {
	if (!url) url = window.location.href;
	name = name.replace(/[\[\]]/g, "\\$&");
	var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
		results = regex.exec(url);
	if (!results) return null;
	if (!results[2]) return '';
	return decodeURIComponent(results[2].replace(/\+/g, " "));
}

export function upload(http, url, data, files, method = "POST") {
	let formData = new FormData();

	for (let i = 0; i < files.length; i++) {
			formData.append(`files[${i}]`, files[i]);
	}

	return http.fetch(url, {
			method: method,
			body: formData,
			headers: new Headers()
	}).then(response => response.json());
}