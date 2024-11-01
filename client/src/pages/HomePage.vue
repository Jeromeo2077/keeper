<script setup>
import Pop from '@/utils/Pop.js';
import { logger } from '@/utils/Logger.js';
import { computed, onMounted, watch } from 'vue';
import { AppState } from '@/AppState.js';
import { keepsService } from '@/services/KeepsService.js';
import KeepCard from '@/components/globals/KeepCard.vue';


const keeps = computed(() => {
  return AppState.keeps;
});

onMounted(() => {
  getAllKeeps();
});

watch(keeps, () => {
  getAllKeeps();
});


async function getAllKeeps() {
  try {
    await keepsService.getAllKeeps();
  }
  catch (error) {
    Pop.error(error);
    logger.error(error);
  }
}

</script>

<template>
  <div class="container background-color masonry-grid p-0">
    <div class="row">
      <div v-for="keep in keeps" :key="keep.id" class="col-12 col-md-4">
        <KeepCard :keep="keep" />
      </div>
    </div>
  </div>

</template>

<style scoped lang="scss">
.background-color {
  background-color: #f8f9fa;
}

.masonry-grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(700px, 1fr));
  grid-template-rows: masonry;
  gap: 10px;
}
</style>
