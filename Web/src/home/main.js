import 'jquery';
import 'bootstrap';
import 'toastr';
import 'fetch';

import authConfig from 'authorization/authConfig';

export function configure(aurelia) {
  aurelia.use
    .standardConfiguration()
    .developmentLogging()
    
    .plugin('aurelia-validation')

    // Load the plugin, and set the base url.
    .plugin('aurelia-api', config => {
        config
          .registerEndpoint('auth', '/api/')
          .registerEndpoint('api', '/api/')
          .setDefaultEndpoint('auth');
    })    
    
    .plugin('aurelia-authentication', baseConfig => {
        baseConfig.configure(authConfig);
    });

  //Uncomment the line below to enable animation.
  //aurelia.use.plugin('aurelia-animator-css');
  //if the css animator is enabled, add swap-order="after" to all router-view elements

  //Anyone wanting to use HTMLImports to load views, will need to install the following plugin.
  //aurelia.use.plugin('aurelia-html-import-template-loader') 

  aurelia.start().then(() => aurelia.setRoot());
}

// options for toastr js plugin
toastr.options.positionClass = 'toast-top-center';