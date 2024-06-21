import json2json from 'awesome-json2json';
import { sort } from '../../../shared/rambda-extension';
import { measurementViewListTemplate } from './templates';

const sortByLatest = sort((a, b) => b.lastUpdatedAt - a.lastUpdatedAt);

const transformMeasurementsList = async (data) => {
  const measurements = json2json(data || [], measurementViewListTemplate) || [];
  return sortByLatest(measurements);
};

export {
  transformMeasurementsList,
};
