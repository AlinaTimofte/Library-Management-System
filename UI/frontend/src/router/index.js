import { createRouter, createWebHistory } from 'vue-router';
import Dashboard from '../components/Dashboard.vue';
import BooksView from '../views/BooksView.vue';
import AuthorsView from '../views/AuthorsView.vue';
import BorrowersView from '../views/BorrowersView.vue';
import GenresView from '../views/GenresView.vue';
import SuggestionsView from '../views/SuggestionsView.vue';
import AISuggestionsView from '../views/AISuggestionsView.vue';

const routes = [
  { path: '/', component: Dashboard },
  { path: '/books', component: BooksView },
  { path: '/authors', component: AuthorsView },
  { path: '/genres', component: GenresView },
  { path: '/borrowers', component: BorrowersView },
  { path: '/suggestions', component: SuggestionsView },
  { path: '/ai-suggestions', component: AISuggestionsView },
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;