<script setup>
import { Keep } from '@/models/Keep.js';
import ProfilePicture from './ProfilePicture.vue';
import { computed, onMounted } from 'vue';
import { AppState } from '@/AppState.js';
import { keepsService } from '@/services/KeepsService.js';
import { useRoute } from 'vue-router';
import Pop from '@/utils/Pop.js';
import { logger } from '@/utils/Logger.js';


const activeKeep = computed(() => {
  return AppState.activeKeep;
});


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
    data-bs-target="#KeepDetails">
    <img :src="keep.img" :alt="keep.name" class="img-fluid keep-img rounded border border-3 shadow">
    <h3>{{ keep.name }}</h3>
    <span>
      <ProfilePicture :profile="keep.creator" />
    </span>
  </div>

  <div class="modal fade" id="KeepDetails" tabindex="-1" aria-labelledby="Keep Details" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="exampleModalLabel">Keep Name</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          ...
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          <button type="button" class="btn btn-primary">Save changes</button>
        </div>
      </div>
    </div>
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