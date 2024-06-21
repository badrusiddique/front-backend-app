const datatableSchema = async () => ([
  {
    header: 'Audit ID',
    dataType: 'string',
    propertyName: 'id',
    show: false,
  },
  {
    header: 'Table Name',
    dataType: 'string',
    propertyName: 'tableName',
    show: true,
    sortable: true,
  },
  {
    header: 'State',
    dataType: 'string',
    propertyName: 'state',
    show: true,
    sortable: true,
  },
  {
    header: 'Old Value',
    dataType: 'string',
    propertyName: 'oldValue',
    show: true,
  },
  {
    header: 'New Value',
    dataType: 'string',
    propertyName: 'newValue',
    show: true,
  },
  {
    header: 'Last Updated',
    dataType: 'date',
    dataDateFormat: {
      year: 'numeric',
      month: 'short',
      day: 'numeric',
    },
    propertyName: 'lastUpdatedAt',
    show: true,
    sortable: true,
  },
]);

export {
  datatableSchema,
};
