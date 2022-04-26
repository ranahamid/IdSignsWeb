import $ from 'bootstrap';
import 'fastclick';
import 'nprogress';
import 'malihu-custom-scrollbar-plugin';
import 'icheck';
import 'icheck/skins/square/red.css!'
import 'select2';
import 'fetch';
import 'toastr';
import 'bootstrap-maxlength';
import 'eonasdan-bootstrap-datetimepicker';

import * as entities from 'dashboard/config/entities';
import authConfig from 'authorization/authConfig';

export function configure(aurelia) {
  aurelia.use
    .standardConfiguration()
    .developmentLogging()

    // registers global resources
    .feature('resources')

    // Load the plugin, and set the base url.
    .plugin('aurelia-api', config => {
			config
				.registerEndpoint('auth', '/api/')
				.registerEndpoint('api', '/api/')
				.setDefaultEndpoint('api');
    })
    
    // registers aurelia validation plugin
    .plugin('aurelia-validation')
    
    // Register the plugin, and register our entities.
    .plugin('aurelia-orm', builder => {
      builder.registerEntities(entities);
    })    

    .plugin('aurelia-authentication', baseConfig => {
        baseConfig.configure(authConfig);
    })

    // This plugin provides drag-drop functionality
    .plugin('aurelia-dragula', (options) => {
      options.revertOnSpill = true;
    })

    .plugin('aurelia-pager')

    .plugin('aurelia-plugins-switch')

    .plugin('aurelia-table')
    
  //Anyone wanting to use HTMLImports to load views, will need to install the following plugin.
  //aurelia.use.plugin('aurelia-html-import-template-loader')

  aurelia.start().then(() => aurelia.setRoot());
}