<template>
  <table class="table">
    <thead>
      <tr>
        <th scope="col">ID</th>
        <th scope="col">Message</th>
        <th scope="col">Created At</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="note in notesStore.getNotes">
        <th>{{note.id}}</th>
        <td>{{note.message}}</td>
        <td>{{note.created}}</td>
      </tr>
    </tbody>
  </table>
</template>

<script lang="ts">
import { useNotesStore } from "@/stores/notes";
import { mapStores } from "pinia";
import { defineComponent } from "vue";

export default defineComponent({
 computed: {
  ...mapStores(useNotesStore)
 }
})
</script>