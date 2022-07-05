<template>
  <ViewHeader
    :title="title"
    :actions="['+ Note', 'Get Notes']"
    @action="resolveAction"></ViewHeader>
  <NoteForm v-if="showNewNote"></NoteForm>
  <NotesTable></NotesTable>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import NoteForm from "@/components/NoteForm.vue"
import NotesTable from "@/components/NotesTable.vue"
import ViewHeader from "@/components/ViewHeader.vue"
import { mapStores } from "pinia";
import { useNotesStore } from "@/stores/notes";
import apiNote from "@/api/Note"

export default defineComponent({
  components: {
    NoteForm,
    NotesTable,
    ViewHeader
  },
  data() {
    return {
      title: 'Notes',
      showNewNote: false
    }
  },
  methods: {
    changeShowNewNote() {
      this.showNewNote = !this.showNewNote
    },
    getNotes() {
      apiNote.get()
        .then((response) => {
          this.notesStore.setNotes(response.data)
        })
    },
    resolveAction(action: string) {
      switch (action) {
        case '+ Note':
          this.changeShowNewNote();
          break;
        case 'Get Notes':
          this.getNotes();
          break;

        default:
          console.log('TODO - Implement action:', action);
          break;
      }
    }
  },
  computed: {
    ...mapStores(useNotesStore)
  }
})
</script>
