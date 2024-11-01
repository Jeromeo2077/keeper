<script setup>
import { computed, onMounted, onUnmounted } from 'vue';
import { AppState } from '../AppState.js';
import { useRoute, useRouter } from 'vue-router';
import { vaultsService } from '@/services/VaultsService.js';
import Pop from '@/utils/Pop.js';
import { logger } from '@/utils/Logger.js';
import { keepsService } from '@/services/KeepsService.js';

const account = computed(() => AppState.account);
const vault = computed(() => AppState.activeVault);
const keeps = computed(() => AppState.vaultKeeps);

const route = useRoute();
const router = useRouter();

onMounted(() => {
  getVaultDetailsById();
  getKeepsByVaultId();
});

onUnmounted(() => {
  AppState.activeVault = null;
});


async function getVaultDetailsById() {
  try {
    await vaultsService.getVaultDetailsById(route.params.vaultId);
  }
  catch (error) {
    Pop.error(error);
    logger.error(error);
    if (error.response.data == "Error: This Vault is Private") {
      router.push({ name: 'Home' })
    }
  }
}


function getKeepsByVaultId() {
  try {
    keepsService.getKeepsByVaultId(route.params.vaultId);
  }
  catch (error) {
    Pop.error(error);
    logger.error(error);
  }
}


</script>

<template>
  <div v-if="vault" class="container account-page">

    <div class="cover-img">
      <img :src="vault.img" alt="Cover Image" class="img-fluid">
      <div class="profile-picture">
        <img :src="account.picture" alt="Profile Picture" class="rounded-circle">
      </div>
    </div>

    <div class="account-info text-center">
      <h1>{{ vault.name }}</h1>
      <h1>By {{ account.name }}</h1>
      <p class="m-0 p-0">Keeps: {{ keeps.length }}</p>
    </div>

    <div class="row keeps-section">
      <h2>Keeps</h2>
      <div v-if="keeps.length" class="row">
        <div v-for="keep in keeps" :key="keep.id" class="col-12 col-md-4 mb-4">
          <KeepCard :keep="keep" />
        </div>
      </div>
      <div v-else>
        <p>No keeps found.</p>
      </div>
    </div>

  </div>
</template>

<style scoped lang="scss">
.account-page {
  .cover-img {
    position: relative;

    img {
      width: 100%;
      height: 300px;
      object-fit: cover;
    }

    .profile-picture {
      position: absolute;
      bottom: -50px;
      left: 50%;
      transform: translateX(-50%);

      img {
        width: 100px;
        height: 100px;
        border: 3px solid white;
      }
    }
  }

  .account-info {
    margin-top: 60px;

    h1 {
      margin-bottom: 0;
    }
  }

  .vaults-section,
  .keeps-section {
    margin-top: 30px;

    h2 {
      margin-bottom: 20px;
    }
  }
}
</style>