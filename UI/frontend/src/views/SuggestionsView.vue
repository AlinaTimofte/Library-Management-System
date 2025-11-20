<template>
  <div class="suggestions-container">
    <h1>Suggestions</h1>
    <div v-if="loading" class="loading">Loading suggestions...</div>
    <div v-else-if="error" class="error">{{ error }}</div>
    <div v-else>
      <table class="suggestions-table">
        <thead>
          <tr>
            <th>Author</th>
            <th>Title</th>
            <th>Genre</th>
            <th>Description</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="suggestion in suggestions" :key="suggestion.id">
            <td>{{ suggestion.author }}</td>
            <td>{{ suggestion.title }}</td>
            <td>{{ suggestion.genre }}</td>
            <td>{{ suggestion.description }}</td>
            <td>
              <button @click="approveSuggestion(suggestion.id)" class="approve-btn">
                Approve
              </button>
              <button @click="deleteSuggestion(suggestion.id)" class="delete-btn">
                Delete
              </button>
            </td>
          </tr>
          <tr v-if="suggestions.length === 0">
            <td colspan="5" class="no-data">No suggestions found.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import axios from 'axios';

const suggestions = ref([]);
const loading = ref(true);
const error = ref(null);

const API_URL = 'http://localhost:8080/api/suggestions';

const fetchSuggestions = async () => {
  loading.value = true;
  try {
    const response = await axios.get(API_URL);
    suggestions.value = response.data;
    error.value = null;
  } catch (err) {
    error.value = 'Failed to load suggestions.';
    console.error(err);
  } finally {
    loading.value = false;
  }
};

const approveSuggestion = async (id) => {
  if (!confirm('Are you sure you want to approve this suggestion? It will be moved to the book list.')) {
    return;
  }

  try {
    await axios.post(`${API_URL}/${id}/approve`);
    // Remove from list
    suggestions.value = suggestions.value.filter(s => s.id !== id);
    alert('Suggestion approved successfully!');
  } catch (err) {
    alert('Failed to approve suggestion.');
    console.error(err);
  }
};

const deleteSuggestion = async (id) => {
  if (!confirm('Are you sure you want to delete this suggestion? This action cannot be undone.')) {
    return;
  }

  try {
    await axios.delete(`${API_URL}/${id}`);
    // Remove from list
    suggestions.value = suggestions.value.filter(s => s.id !== id);
    alert('Suggestion deleted successfully!');
  } catch (err) {
    alert('Failed to delete suggestion.');
    console.error(err);
  }
};

onMounted(() => {
  fetchSuggestions();
});
</script>

<style scoped>
.suggestions-container {
  padding: 20px;
  max-width: 1200px;
  margin: 0 auto;
}

h1 {
  color: #2c3e50;
  margin-bottom: 20px;
}

.suggestions-table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 20px;
  background-color: white;
  box-shadow: 0 1px 3px rgba(0,0,0,0.2);
}

.suggestions-table th,
.suggestions-table td {
  padding: 12px 15px;
  text-align: left;
  border-bottom: 1px solid #ddd;
}

.suggestions-table th {
  background-color: #f8f9fa;
  font-weight: bold;
  color: #333;
}

.suggestions-table tr:hover {
  background-color: #f5f5f5;
}

.approve-btn {
  background-color: #4CAF50;
  color: white;
  border: none;
  padding: 8px 16px;
  border-radius: 4px;
  cursor: pointer;
  transition: background-color 0.3s;
  margin-right: 8px;
}

.approve-btn:hover {
  background-color: #45a049;
}

.delete-btn {
  background-color: #f44336;
  color: white;
  border: none;
  padding: 8px 16px;
  border-radius: 4px;
  cursor: pointer;
  transition: background-color 0.3s;
}

.delete-btn:hover {
  background-color: #d32f2f;
}

.loading, .error, .no-data {
  text-align: center;
  padding: 20px;
  font-size: 1.1em;
}

.error {
  color: #e74c3c;
}
</style>
