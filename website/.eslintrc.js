module.exports = {
  root: true,
  env: {
    es6: true,
    jest: true,
    node: true,
    browser: true,
  },
  extends: [
    'eslint:recommended',
    'plugin:vue/recommended',
  ],
  plugins: [],
  parserOptions: {
    parser: 'babel-eslint',
  },
  rules: {
    'max-len': ['error', {
      code: 120,
      tabWidth: 2,
      ignoreUrls: true,
      ignoreComments: true,
      ignoreTrailingComments: true,
    }],
    ['jsx-quotes']: ['error', 'prefer-double'],
    'comma-dangle': ['error', 'always-multiline'],
    semi: ['error', 'always'],
    indent: ['error', 2],
    quotes: ['error', 'single'],
    'no-console': process.env.NODE_ENV === 'production' ? 'warn' : 'off',
    'no-debugger': process.env.NODE_ENV === 'production' ? 'warn' : 'off',
    'vue/no-v-html': 'off',
    'vue/no-use-v-if-with-v-for': 'off',
    'vue/require-default-prop': 'off',
    'vue/component-definition-name-casing': 'off',
    'vue/name-property-casing': ['error', 'kebab-case'],
    'vue/html-indent': [
      'error',
      2,
      {
        attribute: 1,
        baseIndent: 1,
        closeBracket: 0,
        alignAttributesVertically: true,
        ignores: [],
      },
    ],
    'vue/max-attributes-per-line': [
      'error',
      {
        singleline: 1,
        multiline: {
          max: 1,
          allowFirstLine: false,
        },
      },
    ],
  },
  overrides: [
    {
      files: [
        '*/_tests_/.{j,t}s?(x)',
        '*/tests/unit/*/*.spec.{j,t}s?(x)',
      ],
      env: {
        jest: true,
      },
    },
    {
      files: ['.vue', '*/host/tests/*/.js'],
      rules: {
        'import/no-extraneous-dependencies': 'off',
      },
    },
  ],
};
