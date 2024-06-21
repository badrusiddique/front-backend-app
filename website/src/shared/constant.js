const expandableTypes = {
  measurementCreate: 'measurement-create',
  measurementDetails: 'measurement-details',
};

const validationMessages = {
  required: '{attribute} is required',
  between: '{{attribute}} must be between {0} and {1})',
  email: '{attribute} is not valid (e.g. johndoe@domain.com)',
  maxLength: '{{attribute}} is too long (maximum is {0} characters)',
};

export {
  expandableTypes,
  validationMessages,
};
