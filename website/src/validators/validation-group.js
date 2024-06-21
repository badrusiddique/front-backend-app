import { templates } from 'vuelidate-error-extractor';
import { deepProp } from '../shared/rambda-extension';

const validationGroup = deepProp(['singleErrorExtractor', 'foundation6'], templates);

export {
  validationGroup,
};
