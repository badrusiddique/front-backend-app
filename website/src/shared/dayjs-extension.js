import dayjs from 'dayjs';
import utc from 'dayjs/plugin/utc';

import { isBlank } from './rambda-extension';

dayjs.extend(utc);

const defaultTemplate = 'MM/DD/YYYY';

const asOfNow = dayjs();

const defaultJsDate = asOfNow.toDate();

const toUtc = (input) => dayjs(input, { utc: true });

const toDate = (input) => (isBlank(input) ? defaultJsDate : toUtc(input).toDate());

const formatToUtcDate = (input, template) => (
  isBlank(input) ? 'N/A' : toUtc(input).format(template || defaultTemplate)
);

export {
  toDate,
  asOfNow,
  formatToUtcDate,
};
