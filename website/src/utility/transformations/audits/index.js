import json2json from 'awesome-json2json';
import { viewListTemplate } from './templates';
import { sort } from '../../../shared/rambda-extension';

const sortByLatest = sort((a, b) => a.lastUpdatedAt - b.lastUpdatedAt);

const transformAuditsList = async (data) => {
  const audits = json2json(data || [], viewListTemplate) || [];
  return sortByLatest(audits);
};

export {
  transformAuditsList,
};
