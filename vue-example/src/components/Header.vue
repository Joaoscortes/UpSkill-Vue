<template>
  <nav class="navbar navbar-expand-lg bg-light">
    <div class="container-fluid">
      <router-link class="navbar-brand" to="/">Home</router-link>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent"
        aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav mb-lg-0">
          <li class="nav-item">
            <router-link class="nav-link" to="/notes">Notes</router-link>
          </li>
          <li class="nav-item">
            <router-link class="nav-link" to="/about">About</router-link>
          </li>
        </ul>
        <ul class="navbar-nav ms-auto mb-lg-0">
          <li class="nav-item">
            <span v-if="authStore.isAuthenticated">{{ authStore.getUser.name}}</span>
            <router-link v-else class="nav-link" to="/login">Login</router-link>
          </li>
        </ul>
      </div>
    </div>
  </nav>
</template>

<script lang="ts">
import { useAuthStore } from "@/stores/auth";
import { mapStores } from "pinia";
import { defineComponent } from "vue";

export default defineComponent({
  computed: {
    ...mapStores(useAuthStore)
  }
})
</script>