<template>
  <div class="container mt-4">
    <h1 class="mb-4">Authors</h1>

    <!-- Add Author Form -->
    <div class="card mb-4">
      <div class="card-body">
        <h5 class="card-title">Add New Author</h5>
        <form @submit.prevent="addAuthor">
          <div class="input-group">
            <input v-model="newAuthorName" type="text" class="form-control" placeholder="Author Name" required>
            <button type="submit" class="btn btn-primary">Add Author</button>
          </div>
        </form>
      </div>
    </div>

    <!-- Authors List -->
    <div class="card">
      <div class="card-header">Authors List</div>
      <div class="card-body">
        <ul class="list-group">
          <li v-for="author in authors" :key="author.id" class="list-group-item d-flex justify-content-between align-items-center">
            <div v-if="editingId === author.id">
              <input v-model="editAuthorName" class="form-control">
            </div>
            <span v-else>{{ author.name }}</span>
            <div>
              <div v-if="editingId === author.id">
                <button @click="saveEdit(author.id)" class="btn btn-success btn-sm me-2">Save</button>
                <button @click="cancelEdit" class="btn btn-secondary btn-sm">Cancel</button>
              </div>
              <div v-else>
                <button @click="startEdit(author)" class="btn btn-warning btn-sm me-2">Edit</button>
                <button @click="deleteAuthor(author.id)" class="btn btn-danger btn-sm">Delete</button>
              </div>
            </div>
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import api from '../api/axios';

const authors = ref([]);
const newAuthorName = ref('');
const editingId = ref(null);
const editAuthorName = ref('');

const loadAuthors = async () => {
  try {
    const response = await api.get('/authors');
    authors.value = response.data;
  } catch (error) {
    console.error("Error loading authors:", error);
  }
};

const addAuthor = async () => {
  if (!newAuthorName.value) return;
  try {
    await api.post('/authors', { name: newAuthorName.value });
    newAuthorName.value = '';
    loadAuthors();
  } catch (error) {
    console.error("Error adding author:", error);
  }
};

const deleteAuthor = async (id) => {
  if (confirm('Are you sure you want to delete this author?')) {
    try {
      await api.delete(`/authors/${id}`);
      loadAuthors();
    } catch (error) {
      console.error("Error deleting author:", error);
    }
  }
};

const startEdit = (author) => {
  editingId.value = author.id;
  editAuthorName.value = author.name;
};

const cancelEdit = () => {
  editingId.value = null;
};

const saveEdit = async (id) => {
  try {
    await api.put(`/authors/${id}`, { name: editAuthorName.value });
    editingId.value = null;
    loadAuthors();
  } catch (error) {
    console.error("Error saving author:", error);
  }
};

onMounted(loadAuthors);
</script>

<style scoped>
.container {
  max-width: 800px;
}
</style>