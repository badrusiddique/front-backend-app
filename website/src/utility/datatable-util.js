import {
  map,
  pick,
  values,
} from '../shared/rambda-extension';

const getMethods = map(({ methods }) => methods || null);

const getHeaderWithValues = map(({ propertyName }) => propertyName || '');

const constructDataTableRows = async (columns, data) => {
  const methods = getMethods(columns);
  const headers = getHeaderWithValues(columns);

  return map((row) => ({
    id: row.id,
    methods,
    checked: row.checked,
    cells: values(pick(headers, row)),
  }), data);
};

export  {
  constructDataTableRows,
};
