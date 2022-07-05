<template>
  <div class="d-flex">
    <h1>{{ title }}</h1>
    <span class="ms-auto">
      <button
        v-for="action in actions"
        @click="$emit('action', action)"
        type="button"
        class="btn btn-primary">
        {{ action }}
      </button>
    </span>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  props: ['title', 'actions'],
  emits: ['action']
})
</script>