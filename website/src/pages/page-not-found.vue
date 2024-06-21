<template>
  <div class="page-not-found">
    <ui-block
      :columns="9"
      :container="false"
      text="You're looking for something that doesn't actually exist..."
      title="Whoops!!! 404 - Page not found"
    >
      <p>
        Possible reasons:
      </p>
      <ul>
        <li>The page may have been moved or deleted</li>
        <li>You may have used an outdated or broken link</li>
        <li>You may have typed the address (URL) incorrectly</li>
      </ul>
      <hr>
      <ui-button
        outline
        link="/"
        type="secondary"
      >
        Try going to our homepage
      </ui-button>
    </ui-block>
  </div>
</template>

<script>
import { UIBlock, UIButton } from 'ui-framework';

export default {
  name: 'page-not-found',

  components: {
    'ui-block': UIBlock,
    'ui-button': UIButton,
  },
};
</script>
