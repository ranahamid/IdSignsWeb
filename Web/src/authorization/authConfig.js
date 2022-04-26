/*
For mor visit this page: https://aurelia-authentication.spoonx.org/baseConfig.html
*/ 
var baseUrl = location.origin;
if (!baseUrl)
      baseUrl = location.protocol + "//" + location.host;

export default {
  endpoint: 'auth',
  configureEndpoints: ['auth', 'api'],

  // SPA related options  
  loginRedirect:'/dashboard',                 // The SPA url to which the user is redirected after a successful login  
  logoutRedirect:'/home#login',                // The SPA url to which the user is redirected after a successful logout  
  loginRoute:'/login',                // The SPA route used when an unauthenticated user tries to access an SPA page that requires authentication  
  loginOnSignup: false,               // Whether or not an authentication token is provided in the response to a successful signup  
  signupRedirect: '/home#login',          // If loginOnSignup == false: The SPA url to which the user is redirected after a successful signup (else loginRedirect is used)  
  expiredReload: 0,                   // reload page when token expires. 0 = don't reload (default), 1 = do reload page  
  storageChangedReload: 0,            // reload page when storage changed aka login/logout in other tabs/windows. 0 = don't reload (default), 1 = do reload page

  // API related options  
  baseUrl: '',                        // The base url used for all authentication related requests, including provider.url below. This appends to the httpClient/endpoint base url, it does not override it. 
  loginUrl: baseUrl + '/token',                 // The API endpoint to which login requests are sent   
  signupUrl: 'account/register',    // The API endpoint to which signup requests are sent
  profileUrl: 'account/get',   // The API endpoint used in profile requests (inc. `find/get` and `update`)
  profileMethod: 'put',               // The method used to update the profile ('put' or 'patch')
  unlinkUrl: '/unlink/',     // The API endpoint used with oAuth to unlink authentication
  unlinkMethod: 'get',                // The HTTP method used for 'unlink' requests (Options: 'get' or 'post')

  // Token Options  
  authHeader: 'Authorization',        // The header property used to contain the authToken in the header of API requests that require authentication  
  authTokenType: 'Bearer',            // The token name used in the header of API requests that require authentication
  accessTokenProp: 'access_token',    // The property from which to get the access token after a successful login or signup  

  expiredRedirect: 1,                 // redirect to logoutRedirect after token expiration
  providers: {
    facebook: {
			name: 'facebook',
			url: baseUrl + '/api-auth/addexternalloginbycode',
			clientId: '1283775648377519',
			authorizationEndpoint: 'https://www.facebook.com/v2.5/dialog/oauth',
			redirectUri: window.location.origin + '/',
			requiredUrlParams: ['display', 'scope'],
			scope: ['email'],
			scopeDelimiter: ',',
			display: 'popup',
			oauthType: '2.0',
			popupOptions: { width: 580, height: 400 }
    }
  }
};