const { deepProp } = require('./rambda-extension');

const createError = (message, extra) => {
  const error = new Error(message);
  error.extra = extra;
  return error;
};

const parseError = ({ response }) => {
  const { data } = response || {};
  const code = deepProp(['StatusCode'], data) || deepProp(['status'], response);
  const message = deepProp(['Error'], data) || deepProp(['statusText'], response);
  return createError(message, { code });
};

module.exports = {
  parseError,
  createError,
};
