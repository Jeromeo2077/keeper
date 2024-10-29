<script setup>
import { onMounted, ref } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';

const theme = ref(loadState('theme') || 'light')

onMounted(() => {
  document.documentElement.setAttribute('data-bs-theme', theme.value)
})

function toggleTheme() {
  theme.value = theme.value == 'light' ? 'dark' : 'light'
  document.documentElement.setAttribute('data-bs-theme', theme.value)
  saveState('theme', theme.value)
}

</script>

<template>
  <nav class="navbar navbar-expand-sm bg-light px-3">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <button type="button" class="btn btn-info btn-small d-flex gap-3">
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

    <!-- <li>
          <router-link :to="{ name: 'About' }" class="btn text-success lighten-30 selectable text-uppercase">
            About
          </router-link>
        </li> -->
    <!-- LOGIN COMPONENT HERE -->
    <div>
      <!-- <button class="btn text-light" @click="toggleTheme"
        :title="`Enable ${theme == 'light' ? 'dark' : 'light'} theme.`">
        <Icon :name="theme == 'light' ? 'weather-sunny' : 'weather-night'" />
      </button> -->
    </div>
    <Login />
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
