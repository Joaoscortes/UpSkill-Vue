import type { INote } from "@/models/Note"
import axios from "axios"

export default {
  apiUrl: "http://localhost:5200",

  get() {
    return axios.get(`${this.apiUrl}/Note/Get`)
  },
  add(note: INote) {
    return axios.post(`${this.apiUrl}/Note/Add`, note)
  },
  update(note: INote) {
    return axios.put(`${this.apiUrl}/Note/Update`, note)
  }
}