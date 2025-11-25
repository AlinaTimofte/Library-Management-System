<template>
  <div id="app">
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
      <div class="container-fluid">
        <router-link class="navbar-brand" to="/">Library</router-link>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
          <ul class="navbar-nav">
            <li class="nav-item">
              <router-link class="nav-link" to="/">Dashboard</router-link>
            </li>
            <li class="nav-item">
              <router-link class="nav-link" to="/books">Books</router-link>
            </li>
            <li class="nav-item">
              <router-link class="nav-link" to="/authors">Authors</router-link>
            </li>
            <li class="nav-item">
              <router-link class="nav-link" to="/genres">Genres</router-link>
            </li>
            <li class="nav-item">
              <router-link class="nav-link" to="/borrowers">Borrowers</router-link>
            </li>
            <li class="nav-item">
              <router-link class="nav-link" to="/suggestions">Suggestions</router-link>
            </li>
            <li class="nav-item">
              <router-link class="nav-link" to="/ai-suggestions">AI Suggestions</router-link>
            </li>
          </ul>
        </div>
      </div>
    </nav>

    <main class="container mt-4">
      <router-view/>
    </main>
  </div>
</template>

<script>
export default {
  name: 'App',
};
</script>

<style>
.navbar-brand {
  font-weight: bold;
}
.nav-link.router-link-exact-active {
  color: #fff !important;
  font-weight: bold;
}
</style>