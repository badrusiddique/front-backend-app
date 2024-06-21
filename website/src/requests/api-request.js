import { axios } from '../axios';
import { parseResult, parseError } from './response-parser';

const putRequest = async (options, data) => {
  try {
    const { route } = options || {};
    const response = await axios.$put(route, data);
    return parseResult(response);
  } catch(err) {
    return parseError(err);
  }
};

const postRequest = async (options, data) => {
  try {
    const { route, params } = options || {};
    const response = await axios.$post(route, data, { params });
    return parseResult(response);
  } catch(err) {
    return parseError(err);
  }
};

const deleteRequest = async (options) => {
  try {
    const { route } = options || {};
    const response = await axios.$delete(route);
    return parseResult(response);
  } catch(err) {
    return parseError(err);
  }
};

const fetchRequest = async (options) => {
  try {
    const { route, params } = options || {};
    const response = await axios.$get(route, { params });
    return parseResult(response);
  } catch(err) {
    return parseError(err);
  }
};

export {
  putRequest,
  postRequest,
  deleteRequest,
  fetchRequest,
};
