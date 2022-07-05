<template>
  <form @submit.prevent="saveNote()">
    <div class="mb-3">
      <label for="inputMessage" class="form-label">Message</label>
      <input v-model="note.message" type="text" class="form-control" id="inputMessage">
    </div>

    <button type="submit" class="btn btn-primary">Submit</button>
  </form>
</template>

<script lang="ts">
import type { INote } from "@/models/Note";
import { defineComponent } from "vue";
import noteApi from "@/api/Note"
import { mapStores } from "pinia";
import { useNotesStore } from "@/stores/notes";
import { useAuthStore } from "@/stores/auth";

export default defineComponent({
  data() {
    return {
      note: {} as INote
    }
  },
  methods: {
    saveNote() {
      if (!this.authStore.getUser.id) {
        return
      }
      this.note.authorId = parseInt(this.authStore.getUser.id)
      noteApi.add(this.note)
        .then((response) => {
          this.notesStore.addNote(response.data);
          this.note = {} as INote
        })
    }
  },
  computed: {
    ...mapStores(useNotesStore, useAuthStore)
  }
})
</script>