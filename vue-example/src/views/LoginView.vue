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

<script>
import {defineComponent} from 'vue'

export default defineComponent({
  data() {
    return {
      currentUser: {},
      loginForm: {
        email: '',
        password: ''
      }
    }
  },
  methods: {
    login() {
      if (this.loginForm.email && this.loginForm.password) {
        this.currentUser = this.loginForm;
        console.log(this.currentUser);
        this.$router.push('/home')
      }
    }
  }
})

</script>

<style>
</style>