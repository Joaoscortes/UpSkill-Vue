<script setup lang="ts">
import { RouterView } from 'vue-router'
</script>

<template>
  <Header></Header>
  <div class="container">
    <RouterView />
  </div>

</template>

<script lang="ts">
import { defineComponent } from "vue";
import Header from "./components/Header.vue"

export default defineComponent({
  components: {
    Header
  }
})
</script>
