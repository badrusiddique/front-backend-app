const R = require('rambda');
const dig = require('object-dig');

const isBlank = R.anyPass([R.isNil, R.isEmpty]);

const deepProp = R.curry((path, obj) => dig(obj, ...path));

module.exports = {
  ...R,
  isBlank,
  deepProp,
};
