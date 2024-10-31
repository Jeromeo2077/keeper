<script setup>
import ProfilePicture from './ProfilePicture.vue';
import Pop from '@/utils/Pop.js';
import { logger } from '@/utils/Logger.js';
import KeepDetailsModal from './KeepDetailsModal.vue';
import { Vault } from '@/models/Vault.js';
import { vaultsService } from '@/services/VaultsService.js';

defineProps({ vault: { type: Vault, required: true } });

async function getVaultDetailsById() {
  try {
    // await vaultsService.getVaultDetailsById(vault.id);
  }
  catch (error) {
    Pop.error(error);
    logger.error(error);
  }
}

</script>


<template>
  <div type="button" class="keep-card btn" @click="getVaultDetailsById()" data-bs-toggle="modal"
    data-bs-target="#VaultDetailsModal">
    <img :src="vault.img" :alt="vault.name" class="img-fluid keep-img rounded border border-3 shadow">
    <h3>{{ vault.name }}</h3>
    <span>
      <ProfilePicture :profile="vault.creator" />
    </span>

    <KeepDetailsModal />
  </div>


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
</style>