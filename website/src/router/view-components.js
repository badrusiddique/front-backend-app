const HomeComponent = () => import(/* webpackChunkName: "chunk-home" */ '../pages/home');

const AuditLogComponent = () => import(/* webpackChunkName: "chunk-audit-log" */ '../pages/audits/audit-log');

const MeasurementsComponent = () => import(/* webpackChunkName: "chunk-measurements" */ '../pages/measurements/index');
const EditMeasurementComponent = () => import(/* webpackChunkName: "chunk-measurements" */ '../pages/measurements/measurement-edit');
const MeasurementDetailComponent = () => import(/* webpackChunkName: "chunk-measurements" */ '../pages/measurements/measurement-detail');
const CreateMeasurementComponent = () => import(/* webpackChunkName: "chunk-measurements" */ '../pages/measurements/measurement-create');

const PageNotFoundComponent = () => import(/* webpackChunkName: "chunk-page-not-found" */ '../pages/page-not-found');

export {
  HomeComponent,
  AuditLogComponent,
  MeasurementsComponent,
  EditMeasurementComponent,
  MeasurementDetailComponent,
  CreateMeasurementComponent,
  PageNotFoundComponent,
};
