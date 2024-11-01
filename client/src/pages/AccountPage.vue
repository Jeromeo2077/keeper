<script setup>
import { computed, onMounted, watch } from 'vue';
import { AppState } from '../AppState.js';
import { vaultsService } from '@/services/VaultsService.js';
import { keepsService } from '@/services/KeepsService.js';
// import VaultCard from '@/components/VaultCard.vue';
// import KeepCard from '@/components/KeepCard.vue';

const account = computed(() => AppState.account);
const vaults = computed(() => AppState.accountVaults);
const keeps = computed(() => AppState.accountKeeps);

// onMounted(async () => {
//   // await vaultsService.getVaultsByAccountId(account.value.id);
//   // await keepsService.getKeepsByAccountId(account.value.id);
// });

// watch(account, async () => {
//   await vaultsService.getVaultsByAccountId(account.value.id);
//   await keepsService.getKeepsByAccountId(account.value.id);
// });

</script>

<template>
  <div v-if="account" class="container account-page">

    <div class="cover-img">
      <img :src="account.coverImg" alt="Cover Image" class="img-fluid">
      <div class="profile-picture">
        <img :src="account.picture" alt="Profile Picture" class="rounded-circle">
      </div>
    </div>

    <div class="account-info text-center">
      <h1>{{ account.name }}</h1>
      <p>{{ account.email }}</p>
      <p class="m-0 p-0">Vaults: {{ vaults.length }}</p>
      <p class="m-0 p-0">Keeps: {{ keeps.length }}</p>
    </div>

    <div class="vaults-section">
      <h2>Your Vaults</h2>

      <div v-if="vaults.length" class="row">
        <div v-for="vault in vaults" :key="vault.id" class="col-12 col-md-4 mb-4">
          <VaultCard :vault="vault" />
        </div>
      </div>
      <div v-else>
        <p>No vaults found.</p>
      </div>
    </div>

    <div class="row keeps-section">
      <h2>Your Keeps</h2>
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