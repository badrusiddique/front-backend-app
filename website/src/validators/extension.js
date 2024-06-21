import { helpers } from 'vuelidate/lib/validators';


const contains = (param) =>
  helpers.withParams(
    { type: 'contains', value: param },
    (value) => !helpers.req(value) || value.indexOf(param) >= 0,
  );

export {
  contains,
};
