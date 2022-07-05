import type { IUser } from '@/models/User'
import { defineStore } from 'pinia'

export const useAuthStore = defineStore({
  id: 'auth',
  state: () => ({
    user: {} as IUser,
    authenticated: false
  }),
  getters: {
    getUser: (state) => state.user,
    isAuthenticated: (state) => state.authenticated
  },
  actions: {
    setUser(value: IUser) {
      this.user = value;
      this.authenticated = true;
    },
    logout() {
      this.user = {} as IUser;
      this.authenticated = false;
    }
  }
})
