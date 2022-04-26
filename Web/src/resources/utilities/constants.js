const Constants = {
  NEW_ID: "-1111",
  GENERIC_ERROR_MESSAGE: "",
  ERROR_IN_FETCHING: "An error occured in fetching your data.",
  REQUEST_PROCESSING: "Please wait while we process your request.",
  SAVED_SUCCESSFULLY: "Saved successfully.",
  DELETED_SUCCESSFULLY: "Deleted succssfully.",
  TRY_AGAIN: "An error occured. Please try again.", 
  DELETE_MODAL_HEADING: "Are you sure you want to delete?",
  DELETE_MODAL_ID: "modal-delete",
  CONFIRM_MODAL_HEADING: "Are you sure you want to update this record?",
  CONFIRM_MODAL_ID: "confirm-modal",
  CORRECT_VALIDATION_ERRORS: "Please correct all validation errors."
}

// making the object immutable
Object.freeze(Constants);

export default Constants