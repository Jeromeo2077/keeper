<script setup>
import Pop from '@/utils/Pop.js';
import { logger } from '@/utils/Logger.js';
import { onMounted } from 'vue';
import { vaultsService } from '@/services/VaultsService.js';

onMounted(() => {
  getAllVaults();
});


async function getAllVaults() {
  try {
    await vaultsService.getAllVaults();
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
      <div class="col-12">
        <h1>Home Page</h1>
      </div>
    </div>
  </div>

</template>

<style scoped lang="scss">
.background-color {
  background-color: #f8f9fa;
}
</style>
