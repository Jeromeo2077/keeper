<script setup>
import { Keep } from '@/models/Keep.js';
import ProfilePicture from './ProfilePicture.vue';
import { keepsService } from '@/services/KeepsService.js';
import Pop from '@/utils/Pop.js';
import { logger } from '@/utils/Logger.js';
import KeepDetailsModal from './KeepDetailsModal.vue';
import { Account } from '@/models/Account.js';
import { computed } from 'vue';
import { AppState } from '@/AppState.js';

defineProps({ keep: { type: Keep, required: true } });
const account = computed(() => AppState.account);

async function getKeepDetailsById(keepId) {
  try {
    await keepsService.getKeepDetailsById(keepId);
  }
  catch (error) {
    Pop.error(error);
    logger.error(error);
  }
}

async function deleteKeep(keepId) {
  try {
    await keepsService.deleteKeep(keepId);
    Pop.success('Keep deleted successfully');
  } catch (error) {
    Pop.error(error);
    logger.error(error);
  }
}

</script>


<template>
  <div class="keep-card btn" @click="getKeepDetailsById(keep.id)" data-bs-toggle="modal"
    data-bs-target="#KeepDetailsModal">
    <button v-if="account" type="button" class="btn btn-danger delete-button" @click.stop="deleteKeep(keep.id)">
      <i class="mdi mdi-delete"></i>
    </button>
    <img :src="keep.img" :alt="keep.name" class="img-fluid keep-img rounded border border-3 shadow">
    <h3>{{ keep.name }}</h3>
    <span>
      <ProfilePicture :profile="keep.creator" />
    </span>
    <KeepDetailsModal />
  </div>

</template>


<style lang="scss" scoped>
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

.keep-img {
  width: 100%;
  height: auto;
}

.delete-button {
  position: absolute;
  top: 10px;
  left: 10px;
  z-index: 10;
}

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
</style>