<template>
  <ui-expandable-container>
    <ui-spinner
      v-if="isLoading"
      overlay
      size="small"
      position-y="middle"
    />
    <ui-expandable
      arrow
      toggle-show
      :expanded="expanded"
      arrow-position-x="left"
      @expandopen="handleExpandOpen"
      @expandclose="handleExpandClose"
    >
      <card-header
        slot="trigger"
        :text="headerText"
      >
        <slot name="headerContent" />
      </card-header>
      <hr>
      <slot name="contentBody" />
    </ui-expandable>
  </ui-expandable-container>
</template>

<script>
import {
  UISpinner,
  UIExpandable,
  UIExpandableContainer,
} from 'ui-framework';
import CardHeader from './card-header.vue';

export default {
  name: 'card-expandable',

  components: {
    'ui-spinner': UISpinner,
    'card-header': CardHeader,
    'ui-expandable': UIExpandable,
    'ui-expandable-container': UIExpandableContainer,
  },

  props: {
    expanded: { type: Boolean },
    isLoading: { type: Boolean },
    headerText: { type: String, required: true },
  },

  methods: {
    handleExpandOpen() {
      this.$emit('handleExpandOpen');
    },

    handleExpandClose() {
      this.$emit('handleExpandClose');
    },
  },
};
</script>

<style>
.ui-expandable-container .ui-card .ui-expandable-trigger {
  border-bottom: 1px solid #B3B3B3;
}

.ui-expandable-container .ui-card .ui-expandable-trigger:hover {
  background-color: transparent;
}

.ui-expandable-container .ui-card .ui-expandable-content-body {
  padding-top: 0;
}
</style><template>
  <ui-expandable-container>
    <ui-spinner
      v-if="isLoading"
      overlay
      size="small"
      position-y="middle"
    />
    <ui-expandable
      arrow
      toggle-show
      :expanded="expanded"
      arrow-position-x="left"
      @expandopen="handleExpandOpen"
      @expandclose="handleExpandClose"
    >
      <card-header
        slot="trigger"
        :text="headerText"
      >
        <slot name="headerContent" />
      </card-header>
      <hr>
      <slot name="contentBody" />
    </ui-expandable>
  </ui-expandable-container>
</template>

<script>
import {
  UISpinner,
  UIExpandable,
  UIExpandableContainer,
} from 'ui-framework';
import CardHeader from './card-header.vue';

export default {
  name: 'card-expandable',

  components: {
    'ui-spinner': UISpinner,
    'card-header': CardHeader,
    'ui-expandable': UIExpandable,
    'ui-expandable-container': UIExpandableContainer,
  },

  props: {
    expanded: { type: Boolean },
    isLoading: { type: Boolean },
    headerText: { type: String, required: true },
  },

  methods: {
    handleExpandOpen() {
      this.$emit('handleExpandOpen');
    },

    handleExpandClose() {
      this.$emit('handleExpandClose');
    },
  },
};
</script>

<style>
.ui-expandable-container .ui-card .ui-expandable-trigger {
  border-bottom: 1px solid #B3B3B3;
}

.ui-expandable-container .ui-card .ui-expandable-trigger:hover {
  background-color: transparent;
}

.ui-expandable-container .ui-card .ui-expandable-content-body {
  padding-top: 0;
}
</style>
