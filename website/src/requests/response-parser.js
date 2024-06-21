import { deepProp, hasValue } from '../shared/rambda-extension';

const defaultError = 'An error occurred while processing your request';

const parseError = result => {
  const code = deepProp(['statusCode'], result) || 500;
  const errCode = deepProp(['error', 'code'], result) || 'UNKNOWN_ERROR';
  const error = errCode || defaultError;

  return { error, code };
};

const parseResult = (response, code = 200) => {
  const { data, statusCode, error } = response || {};
  return statusCode !== code || hasValue(error) ? parseError(response) : { data };
};

export  {
  parseError,
  parseResult,
};
