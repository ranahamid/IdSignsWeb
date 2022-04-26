export function configure(aurelia) {
  aurelia.globalResources(
    'resources/value-converters/date-format',
    'resources/value-converters/number-format',
    'resources/value-converters/files-to-base64',
    'resources/elements/select2',
    'resources/elements/select2-multiple',
    'resources/elements/select2-attribute',
    'resources/elements/file-input.html',
    'resources/elements/no-data.html',
    'resources/elements/dashboard-body-title.html',
    'resources/elements/loading-indicator',
    'resources/elements/confirm-modal.html',
    'resources/elements/datepicker',
    'resources/elements/detail-loading-indicator.html',
    'resources/elements/info-modal.html',
    'resources/elements/deactivate-modal.html',
    'resources/elements/pagination-helper.html',
    'resources/elements/common-action.html',
    'resources/elements/common-action-topbar.html'
  );
}