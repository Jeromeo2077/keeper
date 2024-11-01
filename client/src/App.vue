<script setup>
import Navbar from './components/Navbar.vue';
import KeepDetailsModal from './components/globals/KeepDetailsModal.vue';
import NewKeepModal from './components/globals/NewKeepModal.vue';
import NewVaultModal from './components/globals/NewVaultModal.vue';

</script>

<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer class="bg-dark text-light">
  </footer>
  <NewKeepModal />
  <NewVaultModal />
  <KeepDetailsModal />
</template>

<style lang="scss">
@import '@/assets/scss/main.scss';

:root {
  --main-height: calc(100vh - 32px - 64px);
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
