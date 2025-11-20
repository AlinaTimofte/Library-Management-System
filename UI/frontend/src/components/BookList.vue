<template>
  <div class="container mt-4">
    <h1 class="mb-4">Books</h1>

    <!-- Add Book Form -->
    <div class="card mb-4">
      <div class="card-body">
        <h5 class="card-title">Add New Book</h5>
        <form @submit.prevent="addBook">
          <div class="row">
            <div class="col-md-4 mb-3">
              <input v-model="newBook.title" type="text" class="form-control" placeholder="Book Title" required>
            </div>
            <div class="col-md-3 mb-3">
              <select v-model="newBook.authorId" class="form-select" required>
                <option disabled value="">Select Author</option>
                <option v-for="author in authors" :key="author.id" :value="author.id">{{ author.name }}</option>
              </select>
            </div>
            <div class="col-md-3 mb-3">
              <select v-model="newBook.genreId" class="form-select" required>
                <option disabled value="">Select Genre</option>
                <option v-for="genre in genres" :key="genre.id" :value="genre.id">{{ genre.name }}</option>
              </select>
            </div>
            <div class="col-md-2 mb-3">
              <input v-model.number="newBook.totalCopies" type="number" class="form-control" placeholder="Copies" min="1" required>
            </div>
            <div class="col-md-4 mb-3">
              <textarea v-model="newBook.description" class="form-control" placeholder="Description (optional)" rows="2"></textarea>
            </div>
            <div class="col-md-2 mb-3">
              <button type="submit" class="btn btn-primary w-100">Add Book</button>
            </div>
          </div>
        </form>
      </div>
    </div>

    <!-- Search and Book List -->
    <div class="card">
      <div class="card-header">Book List</div>
      <div class="card-body">
        <input v-model="searchTerm" @input="searchBooks" class="form-control mb-3" placeholder="Search for a book...">

        <table class="table table-striped">
          <thead>
            <tr>
              <th>Title</th>
              <th>Author</th>
              <th>Genre</th>
              <th>Description</th>
              <th>Available</th>
              <th>Available Copies</th>
              <th>Total Copies</th>

            </tr>
          </thead>
          <tbody>
            <tr v-for="book in books" :key="book.id">
              <td>
                <input v-if="editingId === book.id" v-model="editTitle" class="form-control">
                <span v-else>{{ book.title }}</span>
              </td>
              <td>{{ book.author.name }}</td>
              <td>{{ book.genre.name }}</td>
              <td>
                <textarea v-if="editingId === book.id" v-model="editDescription" class="form-control" rows="2"></textarea>
                <span v-else>{{ book.description || 'No description' }}</span>
              </td>
              <td>
                <span :class="book.availableCopies > 0 ? 'text-success' : 'text-danger'">
                  {{ book.availableCopies > 0 ? 'Yes' : 'No' }}
                </span>
              </td>
              <td>{{ book.availableCopies }}</td>

              <td>
                <input v-if="editingId === book.id" v-model.number="editTotalCopies" type="number" class="form-control" min="1">
                <span v-else>{{ book.totalCopies }}</span>
              </td>
              <td>
                <div v-if="editingId === book.id">
                  <button @click="saveEdit(book.id)" class="btn btn-success btn-sm me-2">Save</button>
                  <button @click="cancelEdit" class="btn btn-secondary btn-sm">Cancel</button>
                </div>
                <div v-else>
                  <button @click="startEdit(book)" class="btn btn-warning btn-sm me-2">Edit</button>
                  <button @click="deleteBook(book.id)" class="btn btn-danger btn-sm">Delete</button>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import api from '../api/axios';

const books = ref([]);
const authors = ref([]);
const genres = ref([]);
const searchTerm = ref('');
const editingId = ref(null);
const editTitle = ref('');

const editDescription = ref('');
const editTotalCopies = ref(0);
const newBook = ref({
  title: '',
  authorId: '',
  genreId: '',
  totalCopies: 1,
  description: ''
});

const loadBooks = async () => {
  try {
    const response = await api.get('/books');
    books.value = response.data;
  } catch (error) {
    console.error("Error loading books:", error);
  }
};

const loadAuthors = async () => {
  try {
    const response = await api.get('/authors');
    authors.value = response.data;
  } catch (error) {
    console.error("Error loading authors:", error);
  }
};

const loadGenres = async () => {
  try {
    const response = await api.get('/genres');
    genres.value = response.data;
  } catch (error) {
    console.error("Error loading genres:", error);
  }
};

const searchBooks = async () => {
  try {
    if (!searchTerm.value) {
      loadBooks();
      return;
    }
    const response = await api.get(`/books/search?q=${searchTerm.value}`);
    books.value = response.data;
  } catch (error) {
    console.error("Error searching books:", error);
  }
};

const addBook = async () => {
  if (!newBook.value.title || !newBook.value.authorId || !newBook.value.genreId) return;
  try {
    await api.post('/books', { 
      title: newBook.value.title, 
      author: { id: newBook.value.authorId },
      genre: { id: newBook.value.genreId },
      totalCopies: newBook.value.totalCopies,
      availableCopies: newBook.value.totalCopies,
      description: newBook.value.description || null
    });
    newBook.value.title = '';
    newBook.value.authorId = '';
    newBook.value.genreId = '';
    newBook.value.totalCopies = 1;
    newBook.value.description = '';
    loadBooks();
  } catch (error) {
    console.error("Error adding book:", error);
  }
};

const deleteBook = async (id) => {
  if (confirm('Are you sure you want to delete this book?')) {
    try {
      await api.delete(`/books/${id}`);
      loadBooks();
    } catch (error) {
      console.error("Error deleting book:", error);
    }
  }
};

const startEdit = (book) => {
  editingId.value = book.id;
  editTitle.value = book.title;
  editDescription.value = book.description || '';
  editTotalCopies.value = book.totalCopies;
};

const cancelEdit = () => {
  editingId.value = null;
};

const saveEdit = async (id) => {
  try {
    const book = books.value.find(b => b.id === id);
    const copyDifference = editTotalCopies.value - book.totalCopies;
    
    await api.put(`/books/${id}`, { 
      title: editTitle.value,
      description: editDescription.value || null,
      author: book.author,
      genre: book.genre,
      totalCopies: editTotalCopies.value,
      availableCopies: book.availableCopies + copyDifference
    });
    editingId.value = null;
    loadBooks();
  } catch (error) {
    console.error("Error saving book:", error);
  }
};

onMounted(() => {
  loadBooks();
  loadAuthors();
  loadGenres();
});
</script>

<style scoped>
.container {
  max-width: 1200px;
}
</style>