<template>
  <div class="container mt-4">
    <h1 class="mb-4">Dashboard</h1>
    <div class="row">
      <div class="col-md-4">
        <div class="card text-white bg-primary mb-3">
          <div class="card-header">Total Books</div>
          <div class="card-body">
            <h5 class="card-title">{{ books.length }}</h5>
          </div>
        </div>
      </div>
      <div class="col-md-4">
        <div class="card text-white bg-success mb-3">
          <div class="card-header">Total Borrowers</div>
          <div class="card-body">
            <h5 class="card-title">{{ borrowers.length }}</h5>
          </div>
        </div>
      </div>
      <div class="col-md-4">
        <div class="card text-white bg-info mb-3">
          <div class="card-header">Books Currently Borrowed</div>
          <div class="card-body">
            <h5 class="card-title">{{ borrowedCount }}</h5>
          </div>
        </div>
      </div>
    </div>

    <div class="mt-5">
      <h2>Top 5 Borrowed Books</h2>
      <ul class="list-group">
        <li v-for="book in topBooks" :key="book.id" class="list-group-item d-flex justify-content-between align-items-center">
          {{ book.title }}
          <span class="badge bg-primary rounded-pill">{{ book.totalBorrows }} borrows</span>
        </li>
      </ul>
    </div>

    <div class="mt-5">
      <h2>Top 5 Active Borrowers</h2>
      <ul class="list-group">
        <li v-for="borrower in topActiveBorrowers" :key="borrower.id" class="list-group-item d-flex justify-content-between align-items-center">
          {{ borrower.name }}
          <span class="badge bg-success rounded-pill">{{ borrower.totalBorrows }} borrows</span>
        </li>
      </ul>
    </div>

    <div class="mt-5">
      <h2>Borrowers with Overdue Books</h2>
      <ul class="list-group">
        <li v-for="loan in overdueLoans" :key="loan.id" class="list-group-item d-flex justify-content-between align-items-center">
          {{ loan.borrower.name }}
        </li>
      </ul>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted, computed } from 'vue';
import api from '../api/axios';

const books = ref([]);
const borrowers = ref([]);
const topBooks = ref([]);
const overdueLoans = ref([]);
const topActiveBorrowers = ref([]);

const borrowedCount = computed(() => {
  return borrowers.value.filter(b => b.currentBook != null).length;
});

onMounted(async () => {
  try {
    const booksResponse = await api.get('/books');
    books.value = booksResponse.data;

    const borrowersResponse = await api.get('/borrowers');
    borrowers.value = borrowersResponse.data;

    const topBooksResponse = await api.get('/books/top-borrowed');
    topBooks.value = topBooksResponse.data;

    const overdueLoansResponse = await api.get('/borrowers/overdue');
    overdueLoans.value = overdueLoansResponse.data;

    const topActiveBorrowersResponse = await api.get('/borrowers/top-active');
    topActiveBorrowers.value = topActiveBorrowersResponse.data;
  } catch (error) {
    console.error('Error fetching dashboard data:', error);
  }
});
</script>

<style scoped>
.card-title {
  font-size: 2.5rem;
}
</style>
