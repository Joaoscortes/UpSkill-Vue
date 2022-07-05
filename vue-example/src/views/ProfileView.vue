<template>
  <ViewHeader
    title="Profile"
    :actions="['Logout']"
    @action="logout()"></ViewHeader>
  <form @submit.prevent="update()">
    <div class="mb-3">
      <label for="inputName" class="form-label">Name</label>
      <input v-model="profile.name" type="text" class="form-control" id="inputName">
    </div>
    <div class="mb-3">
      <label for="exampleInputEmail1" class="form-label">Email address</label>
      <input v-model="profile.email" type="email" class="form-control" id="exampleInputEmail1"
        aria-describedby="emailHelp">
      <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
    </div>
    <div class="mb-3">
      <label for="exampleInputPassword1" class="form-label">Password</label>
      <input v-model="profile.password" type="password" class="form-control" id="exampleInputPassword1">
    </div>

    <button type="submit" class="btn btn-primary">Submit</button>
  </form>
</template>


<script lang="ts">
import type { IUser } from "@/models/User";
import { useAuthStore } from "@/stores/auth";
import { mapStores } from "pinia";
import { defineComponent } from "vue";
import userApi from "@/api/User"
import ViewHeader from "@/components/ViewHeader.vue"

export default defineComponent({
  components: {
    ViewHeader
  },
  data() {
    return {
      profile: {} as IUser
    }
  },
  mounted() {
    // Same ref - Warning
    // this.profile = this.authStore.getUser;

    this.profile = JSON.parse(JSON.stringify(this.authStore.getUser))
  },
  computed: {
    ...mapStores(useAuthStore)
  },
  methods: {
    update() {
      userApi.update(this.profile)
        .then((response) => {
          this.authStore.setUser(response.data)
        })
        .catch((error) => {
          console.log(error)
        })
    },
    logout() {
      this.authStore.logout();
      this.$router.push('/');
    }
  }
})
</script>