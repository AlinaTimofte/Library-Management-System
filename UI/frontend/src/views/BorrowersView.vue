<template>
  <div class="container mt-4">
    <h1 class="mb-4">Borrowers</h1>

    <!-- Add Borrower Form -->
    <div class="card mb-4">
      <div class="card-body">
        <h5 class="card-title">Add New Borrower</h5>
        <form @submit.prevent="addBorrower">
          <div class="input-group">
            <input v-model="newBorrowerName" type="text" class="form-control" placeholder="Borrower Name" required>
            <input v-model="newBorrowerEmail" type="email" class="form-control" placeholder="Borrower Email" required>
            <button type="submit" class="btn btn-primary">Add Borrower</button>
          </div>
        </form>
      </div>
    </div>

    <!-- Borrowers List -->
    <div class="card">
      <div class="card-header">Borrowers List</div>
      <div class="card-body">
        <table class="table table-striped">
          <thead>
            <tr>
              <th>Name</th>
              <th>Email</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="borrower in borrowers" :key="borrower.id">
              <td>{{ borrower.name }}</td>
              <td>{{ borrower.email }}</td>
              <td>
                <button @click="viewLoans(borrower)" class="btn btn-info btn-sm">View Loans</button>
                <button @click="openLoanModal(borrower)" class="btn btn-primary btn-sm ms-2">Loan Book</button>
                <button @click="deleteBorrower(borrower.id)" class="btn btn-danger btn-sm ms-2">Delete</button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>

    <!-- Loans Modal -->
    <div v-if="selectedBorrower && !loanModalVisible" class="modal fade show d-block" tabindex="-1">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">Loans for {{ selectedBorrower.name }}</h5>
            <button type="button" class="btn-close" @click="closeModal"></button>
          </div>
          <div class="modal-body">
            <ul v-if="loans.length > 0" class="list-group">
              <li v-for="loan in loans" :key="loan.id" class="list-group-item d-flex justify-content-between align-items-center">
                {{ loan.book.title }} (Due: {{ formatDate(loan.dueAt) }})
                <button @click="returnBook(loan.id)" class="btn btn-success btn-sm">Return</button>
              </li>
            </ul>
            <p v-else>No active loans.</p>
          </div>
        </div>
      </div>
    </div>
    <div v-if="selectedBorrower && !loanModalVisible" class="modal-backdrop fade show"></div>

    <!-- Loan Book Modal -->
    <div v-if="loanModalVisible" class="modal fade show d-block" tabindex="-1">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">Loan a Book to {{ selectedBorrower.name }}</h5>
            <button type="button" class="btn-close" @click="closeLoanModal"></button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="loanBook">
              <div class="mb-3">
                <label for="book-select" class="form-label">Select a Book</label>
                <select v-model="selectedBookId" id="book-select" class="form-select" required>
                  <option v-for="book in books" :key="book.id" :value="book.id">{{ book.title }}</option>
                </select>
              </div>
              <button type="submit" class="btn btn-primary">Loan Book</button>
            </form>
          </div>
        </div>
      </div>
    </div>
    <div v-if="loanModalVisible" class="modal-backdrop fade show"></div>

  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import api from '../api/axios';

const borrowers = ref([]);
const newBorrowerName = ref('');
const newBorrowerEmail = ref('');
const selectedBorrower = ref(null);
const loans = ref([]);
const books = ref([]);
const loanModalVisible = ref(false);
const selectedBookId = ref(null);

const loadBorrowers = async () => {
  try {
    const response = await api.get('/borrowers');
    borrowers.value = response.data;
  } catch (error) {
    console.error("Error loading borrowers:", error);
  }
};

const loadBooks = async () => {
  try {
    const response = await api.get('/books');
    books.value = response.data;
  } catch (error) {
    console.error("Error loading books:", error);
  }
};

const addBorrower = async () => {
  if (!newBorrowerName.value || !newBorrowerEmail.value) return;
  try {
    await api.post('/borrowers', { name: newBorrowerName.value, email: newBorrowerEmail.value });
    newBorrowerName.value = '';
    newBorrowerEmail.value = '';
    loadBorrowers();
  } catch (error) {
    console.error("Error adding borrower:", error);
  }
};

const deleteBorrower = async (borrowerId) => {
  if (confirm('Are you sure you want to delete this borrower?')) {
    try {
      await api.delete(`/borrowers/${borrowerId}`);
      loadBorrowers();
    } catch (error) {
      console.error("Error deleting borrower:", error);
    }
  }
};

const viewLoans = async (borrower) => {
  selectedBorrower.value = borrower;
  try {
    const response = await api.get(`/borrowers/${borrower.id}/loans`);
    loans.value = response.data;
  } catch (error) {
    console.error("Error fetching loans:", error);
    loans.value = [];
  }
};

const returnBook = async (loanId) => {
  try {
    await api.post(`/loans/${loanId}/return`);
    if (selectedBorrower.value) {
      viewLoans(selectedBorrower.value);
    }
  } catch (error) {
    console.error("Error returning book:", error);
  }
};

const closeModal = () => {
  selectedBorrower.value = null;
  loans.value = [];
};

const openLoanModal = (borrower) => {
  selectedBorrower.value = borrower;
  loanModalVisible.value = true;
};

const closeLoanModal = () => {
  loanModalVisible.value = false;
  selectedBookId.value = null;
};

const loanBook = async () => {
  if (!selectedBookId.value || !selectedBorrower.value) return;
  try {
    await api.post(`/borrowers/assign?bookId=${selectedBookId.value}&borrowerId=${selectedBorrower.value.id}`);
    closeLoanModal();
    if (selectedBorrower.value) {
      viewLoans(selectedBorrower.value);
    }
  } catch (error) {
    console.error("Error loaning book:", error);
  }
};

const formatDate = (dateString) => {
  const options = { year: 'numeric', month: 'long', day: 'numeric' };
  return new Date(dateString).toLocaleDateString(undefined, options);
};

onMounted(() => {
  loadBorrowers();
  loadBooks();
});
</script>

<style scoped>
.container {
  max-width: 1000px;
}
.modal {
  background-color: rgba(0,0,0,0.5);
}
</style>
