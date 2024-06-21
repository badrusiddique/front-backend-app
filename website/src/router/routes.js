import {
  HomeComponent,
  AuditLogComponent,
  MeasurementsComponent,
  EditMeasurementComponent,
  MeasurementDetailComponent,
  CreateMeasurementComponent,
  PageNotFoundComponent,
} from './view-components';

const routeByParams = ({ params, query }) => {
  const { expand, url } = query || {};
  const { id } = params || {};

  return { id, url, expand };
};


const routes = [
  {
    to: '/',
    path: '/',
    visible: true,
    router: true,
    icon: 'home',
    name: 'home',
    displayName: 'Home',
    meta: {
      order: 0,
      authorize: [],
    },
    component: HomeComponent,
  },
  {
    path: '/measurement-list',
    icon: 'list',
    name: 'measurement-list',
    displayName: 'Measurements',
    visible: true,
    meta: {
      order: 1,
    },
    children: [
      {
        router: true,
        visible: true,
        to: '/measurements',
        path: '/manage-measurements',
        name: 'manage-measurements',
        displayName: 'Manage Measurements',
      },
      {
        router: true,
        visible: true,
        to: '/measurements/create',
        path: '/measurements-create',
        name: 'measurements-create',
        displayName: 'Create Measurement',
      },
    ],
  },
  {
    router: true,
    visible: true,
    to: '/audit-log',
    icon: 'file-alt',
    path: '/audit-log',
    name: 'audit-log',
    displayName: 'Audit Log',
    component: AuditLogComponent,
    meta: {
      order: 4,
    },
  },
  {
    visible: false,
    router: true,
    name: 'measurements',
    path: '/measurements',
    component: MeasurementsComponent,
  },
  {
    visible: false,
    router: true,
    name: 'create-measurement',
    path: '/measurements/create',
    component: CreateMeasurementComponent,
  },
  {
    visible: false,
    router: true,
    to: '/measurements/:id',
    name: 'view-measurement',
    path: '/measurements/:id',
    props: routeByParams,
    component: MeasurementDetailComponent,
  },
  {
    visible: false,
    router: true,
    to: '/measurements/:id/edit',
    name: 'edit-measurement',
    path: '/measurements/:id/edit',
    props: routeByParams,
    component: EditMeasurementComponent,
  },
  {
    path: '*',
    visible: false,
    name: 'page-not-found',
    component: PageNotFoundComponent,
  },
];

export default routes;
