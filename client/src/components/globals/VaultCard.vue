<script setup>
import ProfilePicture from './ProfilePicture.vue';
import Pop from '@/utils/Pop.js';
import { logger } from '@/utils/Logger.js';
import { Vault } from '@/models/Vault.js';
import { vaultsService } from '@/services/VaultsService.js';
import { keepsService } from '@/services/KeepsService.js';
import { Account } from '@/models/Account.js';
import { computed } from 'vue';
import { AppState } from '@/AppState.js';

defineProps({ vault: { type: Vault, required: true } });
const account = computed(() => AppState.account);

async function getVaultDetailsById() {
  try {
    // await vaultsService.getVaultDetailsById(vault.id);
  }
  catch (error) {
    Pop.error(error);
    logger.error(error);
  }
}

async function deleteVault(vaultId) {
  try {
    await vaultsService.deleteVault(vaultId);
    Pop.success('Vault deleted successfully');
  } catch (error) {
    Pop.error(error);
    logger.error(error);
  }
}


</script>


<template>
  <RouterLink :to="{ name: 'VaultDetails', params: { vaultId: vault.id } }">
    <div class="keep-card">
      <button v-if="account" type="button" class="btn btn-danger delete-button" @click.stop="deleteVault(vault.id)">
        <i class="mdi mdi-delete"></i>
      </button>
      <img :src="vault.img" :alt="vault.name" class="img-fluid keep-img rounded border border-3 shadow">
      <h3>{{ vault.name }}</h3>
      <span>
        <ProfilePicture :profile="vault.creator" />
      </span>
    </div>
  </RouterLink>
</template>


<style lang="scss" scoped>
h3 {
  position: absolute;
  top: 87%;
  left: 10%;
  color: white;
  text-shadow: 2px 2px 4px #000000;
  padding: 0;
}

span {
  position: absolute;
  top: 85%;
  right: 10%;
  padding: 0;
}

.keep-card {
  position: relative;
  break-inside: avoid;
  border-radius: 10px;
  margin: 5px;
  padding: 0;
}

.keep-img {
  width: 100%;
  aspect-ratio: 1/1;
  object-fit: cover;
}

.delete-button {
  position: absolute;
  top: 10px;
  left: 10px;
  z-index: 10;
}
</style>