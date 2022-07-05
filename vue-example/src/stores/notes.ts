import type { INote } from '@/models/Note'
import { defineStore } from 'pinia'

export const useNotesStore = defineStore({
  id: 'notes',
  state: () => ({
    notes: [] as INote[]
  }),
  getters: {
    getNotes: (state) => state.notes
  },
  actions: {
    setNotes(value: INote[]) {
      this.notes = value;
    },
    addNote(value: INote) {
      this.notes.push(value)
    }
  }
})
