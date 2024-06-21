import { toDate } from '../../../shared/dayjs-extension';

const toButtonActions = (id) =>
  `<div style="display: flex">
        <ui-button
            title="View"
            icon="eye"
            color="transparent"
            @click='handleView("${id}")'
        />
        <ui-button
            title="Edit"
            icon="edit"
            color="transparent"
            @click='handleEdit("${id}")'
        />
    </div>`;

const measurementViewListTemplate = {
  $path: '[]',
  id: '$item.id',
  name: '$item.name',
  email: '$item.email',
  speed: '$item.speed',
  state: '$item.state',
  vibration: '$item.vibration',
  acceleration: '$item.acceleration',
  temperature: '$item.temperature',
  lastUpdatedAt: {
    $path: '$item.lastUpdatedAt',
    $formatting: toDate,
  },
  actions: {
    $path: '$item.id',
    $formatting: toButtonActions,
  },
};

export {
  measurementViewListTemplate,
};
