<template>
  <nav>
    <router-link to="/books">Books</router-link> |
    <router-link to="/authors">Authors</router-link> |
    <router-link to="/borrowers">Borrowers</router-link> |
    <router-link to="/stats">Stats</router-link>
  </nav>

  <router-view />
</template>

<style>
nav {
  background-color: #222;
  padding: 10px;
}
a {
  color: white;
  margin-right: 10px;
  text-decoration: none;
}
</style>
