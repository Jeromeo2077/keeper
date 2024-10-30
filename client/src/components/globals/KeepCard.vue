<script setup>
import { Keep } from '@/models/Keep.js';
import ProfilePicture from './ProfilePicture.vue';
import { keepsService } from '@/services/KeepsService.js';
import Pop from '@/utils/Pop.js';
import { logger } from '@/utils/Logger.js';
import KeepDetailsModal from './KeepDetailsModal.vue';

defineProps({ keep: { type: Keep, required: true } });

async function getKeepDetailsById(keepId) {
  try {
    await keepsService.getKeepDetailsById(keepId);
  }
  catch (error) {
    Pop.error(error);
    logger.error(error);
  }
}

</script>


<template>
  <div type="button" class="keep-card btn" @click="getKeepDetailsById(keep.id)" data-bs-toggle="modal"
    data-bs-target="#KeepDetailsModal">
    <img :src="keep.img" :alt="keep.name" class="img-fluid keep-img rounded border border-3 shadow">
    <h3>{{ keep.name }}</h3>
    <span>
      <ProfilePicture :profile="keep.creator" />
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