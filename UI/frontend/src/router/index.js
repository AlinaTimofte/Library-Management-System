import { createRouter, createWebHistory } from "vue-router";
import BooksView from "../views/BooksView.vue";
import AuthorsView from "../views/AuthorsView.vue";
import BorrowersView from "../views/BorrowersView.vue";
import StatsView from "../views/StatsView.vue";

const router = createRouter({
  history: createWebHistory(),
  routes: [
    { path: "/", redirect: "/books" },
    { path: "/books", component: BooksView },
    { path: "/authors", component: AuthorsView },
    { path: "/borrowers", component: BorrowersView },
    { path: "/stats", component: StatsView },
  ],
});

export default router;
