<script setup>
import { AppState } from '@/AppState.js';
import Icon from './globals/Icon.vue';
import Login from './Login.vue';
import { computed } from 'vue';

const account = computed(() => AppState.account);


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

    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>

    <div class="collapse navbar-collapse" id="navbarText">
      <!-- <ul class="navbar-nav me-auto"> -->
      <button v-if="account" type="button" class="btn btn-primary me-2" data-bs-toggle="modal"
        data-bs-target="#NewVaultModal">New
        Vault</button>

      <button v-if="account" type="button" class="btn btn-primary" data-bs-toggle="modal"
        data-bs-target="#NewKeepModal">New
        Keep</button>


    </div>
    <!-- </ul> -->
    <div>
      <div class="d-flex justify-content-center flex-grow-1">
        <Icon class="fs-3" name="shield" />
        <h1 class="px-2">Keeper</h1>
      </div>
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
  width: 100px;
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
  box-shadow: 0 4px 4px rgba(0, 0, 0, 0.1) !important;
}

@media screen and (min-width: 576px) {
  nav {
    height: 64px;
  }
}
</style>
