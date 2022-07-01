import type { IUser } from "@/models/User"
import axios from "axios"

export default {
  apiUrl: "http://localhost:5200",

  login(user: Partial<IUser>) {
    return axios.post(`${this.apiUrl}/User/Login`, user)
  }
}