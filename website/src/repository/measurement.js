import {
  putRequest,
  postRequest,
  fetchRequest,
  deleteRequest,
} from '../requests/api-request';
import { baseUrl } from '../shared/config';

const baseRoute = `${baseUrl}/measurements`;
const error = 'An error occurred while processing measurement request';

const createMeasurement = async (payload) => {
  const result = await postRequest({ route: baseRoute }, payload);
  return result || { error };
};

const deleteMeasurement = async (id) => {
  const result = await deleteRequest({ route: `${baseRoute}/${id}`});
    return result || { error };
  };

  const updateMeasurement = async (payload) => {
    const { id, data } = payload || {};
    const result = await putRequest({ route: `${baseRoute}/${id}`}, data);
      return result || { error };
    };

    const getAllMeasurements = async () => {
      const result = await fetchRequest({ route: baseRoute });
      return result || { error };
    };

    const getMeasurementById = async (id) => {
      const result = await fetchRequest({ route: `${baseRoute}/${id}`});
        return result || { error };
      };

      export {
        createMeasurement,
        deleteMeasurement,
        updateMeasurement,
        getAllMeasurements,
        getMeasurementById,
      };
