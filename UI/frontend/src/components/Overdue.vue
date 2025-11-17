<template>
  <div>
    <h2>⚠️ Cititori cu întârzieri</h2>
    <ul>
      <li v-for="b in overdue" :key="b.id">
        {{ b.name }} — {{ b.currentBook?.title }} (scadentă la {{ b.dueAt }})
      </li>
    </ul>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import axios from 'axios'

const overdue = ref([])

onMounted(async () => {
  const res = await axios.get('http://localhost:8080/api/borrowers/overdue')
  overdue.value = res.data
})
</script>
