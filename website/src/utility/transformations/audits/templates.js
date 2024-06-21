import { toDate } from '../../../shared/dayjs-extension';

const toSubString = (data = '') =>  data.replace(/(.{32})..+/, '$1…');

const viewListTemplate = {
  $path: '[]',
  id: '$item.id',
  state: '$item.state',
  tableName: '$item.tableName',
  oldValue: {
    $path: '$item.oldValues',
    $formatting: toSubString,
  },
  newValue: {
    $path: '$item.newValues',
    $formatting: toSubString,
  },
  lastUpdatedAt: {
    $path: '$item.lastUpdatedAt',
    $formatting: toDate,
  },
};

export {
  viewListTemplate,
};
