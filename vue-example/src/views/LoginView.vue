<template>
  <h1>Login Form</h1>
  <form @submit.prevent="login()">
    <div class="mb-3">
      <label for="exampleInputEmail1" class="form-label">Email address</label>
      <input v-model="loginForm.email" type="email" class="form-control" id="exampleInputEmail1"
        aria-describedby="emailHelp">
      <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
    </div>
    <div class="mb-3">
      <label for="exampleInputPassword1" class="form-label">Password</label>
      <input v-model="loginForm.password" type="password" class="form-control" id="exampleInputPassword1">
    </div>

    <button type="submit" class="btn btn-primary">Submit</button>
  </form>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import userApi from "@/api/User"
import { mapStores } from 'pinia';
import { useAuthStore } from '@/stores/auth'

export default defineComponent({
  data() {
    return {
      loginForm: {
        email: '',
        password: ''
      }
    }
  },
  methods: {
    login() {
      userApi.login(this.loginForm)
        .then((response) => {
          this.authStore.setUser(response.data);
          this.$router.push('/about')
        })
        .catch((error) => {
          console.log(error);
        })
    }
  },
  computed: {
    ...mapStores(useAuthStore)
  }
})

</script>

<style>
</style>