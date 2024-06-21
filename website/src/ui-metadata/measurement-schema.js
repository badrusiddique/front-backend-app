import format from 'string-format';
import {
  email,
  required,
  between,
  maxLength,
} from '../validators';
import { validationMessages } from '../shared/constant';

const {
  email: emailMsg,
  required: requiredMsg,
  between: betweenMsg,
  maxLength: maxLengthMsg,
} = validationMessages;

const stateOptions = [
  { value: '', label: '-- Select --', disabled: true },
  { label: 'Startup', value: 'Startup' },
  { label: 'Slow Roll', value: 'Slow Roll' },
  { label: 'Running', value: 'Running' },
  { label: 'Stopping', value: 'Stopping' },
  { label: 'Shutdown', value: 'Shutdown' },
]

const datatableSchema = async (methods) => ([
  {
    header: 'Measurement ID',
    dataType: 'string',
    propertyName: 'id',
    show: false,
  },
  {
    header: 'Speed',
    dataType: 'string',
    propertyName: 'speed',
    show: true,
  },
  {
    header: 'Vibration',
    dataType: 'string',
    propertyName: 'vibration',
    show: true,
  },
  {
    header: 'Acceleration',
    dataType: 'string',
    propertyName: 'acceleration',
    show: true,
  },
  {
    header: 'Temperature',
    dataType: 'string',
    propertyName: 'temperature',
    show: true,
  },
  {
    header: 'State',
    dataType: 'string',
    propertyName: 'state',
    show: true,
    sortable: true,
  },
  {
    header: 'User Name',
    dataType: 'string',
    propertyName: 'name',
    show: true,
    sortable: true,
  },
  {
    header: 'Email',
    dataType: 'string',
    propertyName: 'email',
    show: true,
    sortable: true,
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
  {
    dataType: 'vue',
    propertyName: 'actions',
    show: true,
    methods,
    style: { width: '0px' },
  },
]);

const createFormSchema = {
  speed: {
    value: null,
    label: 'Speed',
    type: 'input',
    validations: {
      value: {
        required,
        between: between(0, 10000),
      },
      message: {
        required: requiredMsg,
        between: format(betweenMsg, 0, 10000),
      },
    },
  },
  vibration: {
    value: null,
    label: 'Vibration',
    type: 'input',
    validations: {
      value: {
        required,
        between: between(0, 300),
      },
      message: {
        required: requiredMsg,
        between: format(betweenMsg, 0, 300),
      },
    },
  },
  acceleration: {
    value: null,
    label: 'Acceleration',
    type: 'input',
    validations: {
      value: {
        between: between(-50, 50),
      },
      message: {
        required: requiredMsg,
        between: format(betweenMsg, -50, 50),
      },
    },
  },
  temperature: {
    value: null,
    label: 'Temperature',
    type: 'input',
    validations: {
      value: {
        required,
        between: between(0, 1000),
      },
      message: {
        required: requiredMsg,
        between: format(betweenMsg, 0, 1000),
      },
    },
  },
  state: {
    value: null,
    label: 'State',
    type: 'dropdown',
    options: stateOptions,
    validations: {
      value: {
        required,
      },
      message: {
        required: requiredMsg,
      },
    },
  },
  name: {
    value: null,
    label: 'User Name',
    type: 'input',
    validations: {
      value: {
        required,
        maxLength: maxLength(256),
      },
      message: {
        required: requiredMsg,
        maxLength: format(maxLengthMsg, 256),
      },
    },
  },
  email: {
    value: null,
    label: 'Email',
    type: 'input',
    validations: {
      value: {
        email,
        required,
        maxLength: maxLength(256),
      },
      message: {
        email: emailMsg,
        required: requiredMsg,
        maxLength: format(maxLengthMsg, 256),
      },
    },
  },
};

const editFormSchema = {
  speed: {
    value: null,
    label: 'Speed',
    type: 'input',
    validations: {
      value: {
        required,
        between: between(0, 10000),
      },
      message: {
        required: requiredMsg,
        between: format(betweenMsg, 0, 10000),
      },
    },
  },
  vibration: {
    value: null,
    label: 'Vibration',
    type: 'input',
    validations: {
      value: {
        required,
        between: between(0, 300),
      },
      message: {
        required: requiredMsg,
        between: format(betweenMsg, 0, 300),
      },
    },
  },
  acceleration: {
    value: null,
    label: 'Acceleration',
    type: 'input',
    validations: {
      value: {
        between: between(-50, 50),
      },
      message: {
        required: requiredMsg,
        between: format(betweenMsg, -50, 50),
      },
    },
  },
  temperature: {
    value: null,
    label: 'Temperature',
    type: 'input',
    validations: {
      value: {
        required,
        between: between(0, 1000),
      },
      message: {
        required: requiredMsg,
        between: format(betweenMsg, 0, 1000),
      },
    },
  },
  state: {
    value: null,
    label: 'State',
    type: 'dropdown',
    options: stateOptions,
    validations: {
      value: {
        required,
      },
      message: {
        required: requiredMsg,
      },
    },
  },
};

const viewFormSchema = {
  speed: {
    value: null,
    label: 'Speed',
    type: 'span',
  },
  vibration: {
    value: null,
    label: 'Vibration',
    type: 'span',
  },
  acceleration: {
    value: null,
    label: 'Acceleration',
    type: 'span',
  },
  temperature: {
    value: null,
    label: 'Temperature',
    type: 'span',
  },
  state: {
    value: null,
    label: 'State',
    type: 'span',
  },
  name: {
    value: null,
    label: 'User Name',
    type: 'span',
  },
  email: {
    value: null,
    label: 'Email',
    type: 'span',
  },
  lastUpdatedAt: {
    value: null,
    label: 'Last Updated',
    type: 'span',
    inputType: 'date',
  },
};

export {
  datatableSchema,
  editFormSchema,
  viewFormSchema,
  createFormSchema,
};
