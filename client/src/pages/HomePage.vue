<script setup>
import Pop from '@/utils/Pop.js';
import { logger } from '@/utils/Logger.js';
import { computed, onMounted } from 'vue';
import { AppState } from '@/AppState.js';
import { keepsService } from '@/services/KeepsService.js';


const keeps = computed(() => {
  return AppState.keeps;
});

onMounted(() => {
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
  <div class="container background-color">
    <div class="row">
      <div v-for="keep in keeps" :key="keep.id" class="col-12 col-md-4">
        <h1>{{ keeps }}</h1>
      </div>
    </div>
  </div>

</template>

<style scoped lang="scss">
.background-color {
  background-color: #f8f9fa;
}
</style>
