<template>
  <div class="form-group">
    <div
      v-for="(item, key) in schema"
      :key="key"
      class="row form-input"
    >
      <div class="col-md-3 label">
        <span>{{ item.label }}</span>
      </div>
      <div class="col-md-5">
        <validation-group
          :validator="extractValidator(key)"
          :messages="extractErrorMessage(key)"
          :attribute="item.label"
          :show-single-error="showSingleError"
        >
          <div
            v-if="item.type === 'span'"
            :ref="key"
            class="form-input-span"
          >
            <span :id="key">{{ item.value }}</span>
          </div>
          <ui-input
            v-else-if="item.type === 'input'"
            :id="key"
            :ref="key"
            size="small"
            :value="item.value"
            :search="item.search"
            :placeholder="item.placeholder"
            @inputtextupdate="handleTextUpdate"
            @focus="() => handleFocus(key, item.value)"
          />
          <ui-select
            v-else-if="item.type === 'dropdown'"
            :id="key"
            :ref="key"
            size="small"
            :value="item.value"
            :options="item.options"
            @selectupdate="handleSelectUpdate"
          />
        </validation-group>
      </div>
    </div>
  </div>
</template>

<script>
import { UIInput, UISelect } from 'ui-framework';
import { validationGroup } from '../../validators';
import { deepProp, hasValue } from '../../shared/rambda-extension';

export default {
  name: 'form-group',

  components: {
    'ui-input': UIInput,
    'ui-select': UISelect,
    'validation-group': validationGroup,
  },

  props: {
    schema: { type: Object, default: () => ({}) },
    validators: { type: Object, default: () => ({}) },
    errorMessages: { type: Object, default: () => ({}) },
    showSingleError: { type: Boolean, default: true },
  },

  methods: {
    handleFocus(id, value) {
      this.$emit('handleChange', { key: id, value });
    },

    handleTextUpdate({ id, value }) {
      const schemaValue = deepProp([id, 'value'], this.schema);
      if (schemaValue !== value) {
        this.$emit('handleChange', { key: id, value });
      }
    },

    handleSelectUpdate({ id, checked }) {
      const value = deepProp([id, 'value'], this.schema);
      if (hasValue(checked) && value !== checked) {
        this.$emit('handleChange', { key: id, value: checked });
      }
    },

    extractValidator(key) {
      return deepProp([key, 'value'], this.validators);
    },

    extractErrorMessage(key) {
      return deepProp([key, 'message'], this.errorMessages);
    },
  },
};
</script>

<style scoped>
.form-group {
  margin-top: 18px;
}

.form-input {
  max-height: 150px;
  align-items: baseline;
}

.form-input-span {
  min-height: 20px;
}

.label {
  padding-top: 2px;
}

.label > span {
  padding-left: 15px;
}
</style>
