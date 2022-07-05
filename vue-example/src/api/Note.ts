import type { INote } from "@/models/Note"
import axios from "axios"

export default {
  apiUrl: "http://localhost:5200",

  update(note: INote) {
    return axios.put(`${this.apiUrl}/Note/Update`, note)
  }
}