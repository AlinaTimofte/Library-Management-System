<template>
  <div class="container mt-4">
    <h1>Genres</h1>
    <div class="input-group mb-3">
      <input type="text" v-model="newGenre.name" class="form-control" placeholder="New genre name">
      <button @click="addGenre" class="btn btn-primary">Add Genre</button>
    </div>
    <ul class="list-group">
      <li v-for="genre in genres" :key="genre.id" class="list-group-item d-flex justify-content-between align-items-center">
        {{ genre.name }}
        <button @click="deleteGenre(genre.id)" class="btn btn-danger btn-sm">Delete</button>
      </li>
    </ul>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import api from '../api/axios';

const genres = ref([]);
const newGenre = ref({ name: '' });

const fetchGenres = async () => {
  try {
    const response = await api.get('/genres');
    genres.value = response.data;
  } catch (error) {
    console.error('Error fetching genres:', error);
  }
};

const addGenre = async () => {
  try {
    await api.post('/genres', newGenre.value);
    newGenre.value.name = '';
    fetchGenres();
  } catch (error) {
    console.error('Error adding genre:', error);
  }
};

const deleteGenre = async (id) => {
  try {
    await api.delete(`/genres/${id}`);
    fetchGenres();
  } catch (error) {
    console.error('Error deleting genre:', error);
  }
};

onMounted(fetchGenres);
</script>
