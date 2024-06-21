import { baseUrl } from '../shared/config';
import { fetchRequest } from '../requests/api-request';

const baseRoute = `${baseUrl}/audits`;
const error = 'An error occurred while processing audit request';

const getAudits = async () => {
  const result = await fetchRequest({ route: baseRoute });
  return result || { error };
};

export {
  getAudits,
};
