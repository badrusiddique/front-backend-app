import {
  T,
  map,
  pipe,
  pick,
  cond,
  equals,
  always,
  reject,
  isBlank,
} from '../shared/rambda-extension';
import { formatToUtcDate } from '../shared/dayjs-extension';

const getValue = ({ value }) => {
  if (isBlank(value)) { return null; }
  return isNaN(value) ? value : Number(value);
};

const formatByType = (value, type) => cond([
  [equals('date'), () => formatToUtcDate(value, 'MMM D, YYYY')],
  [T, always(value)],
])(type);

const constructRules =  map(({ validations }) => pick('value', validations));

const constructMessages = map(({ validations }) => pick('message', validations));

const formatRequestData = pipe(map(getValue), reject(isBlank));

const formatFormData = async (data, schema) => {
  const format = (input, key) => ({
    ...input,
    value: formatByType(data[key], input.inputType),
  });
  return map(format, schema);
};

const formatValidationData = async (schema) => ({
  rules: constructRules(schema),
  messages: constructMessages(schema),
});

export {
  getValue,
  formatFormData,
  formatRequestData,
  formatValidationData,
};
