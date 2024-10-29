<script setup>
import Login from './Login.vue';
</script>

<template>
  <nav class="navbar navbar-expand-sm bg-light px-3">
    <router-link class="navbar-brand" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <button type="button" class="btn btn-info btn-small d-flex gap-3" aria-label="HomePage">
          <Icon name="home" />
          <span>Home</span>
        </button>
      </div>
    </router-link>

    <!-- <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button> -->
    <div class="collapse navbar-collapse" id="navbarText">
      <!-- <ul class="navbar-nav me-auto"> -->
      <select class="form-select form-select-sm selector" aria-label="Create Selector">
        <option selected>Create</option>
        <option value="1">New Vault</option>
        <option value="2">New Keep</option>
      </select>
      <!-- </ul> -->
    </div>

    <div>
      <Login />
    </div>
  </nav>
  <hr class="hr-shadow my-4">
</template>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

.selector {
  width: 20%;
  outline: none !important;
  box-shadow: none !important;
  border: none;
  background-color: transparent;
  color: inherit;
  padding: 0;
  margin: 0;
  font-size: inherit;
  appearance: none;
}

.hr-shadow {
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.12) !important;
}

@media screen and (min-width: 576px) {
  nav {
    height: 64px;
  }
}
</style>
