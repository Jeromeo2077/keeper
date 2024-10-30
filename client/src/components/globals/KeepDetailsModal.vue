.
<script setup>
import { AppState } from '@/AppState.js';
import { computed } from 'vue';


const activeKeep = computed(() => {
  return AppState.activeKeep;
});

</script>


<template>

  <div class="modal fade" id="KeepDetailsModal" tabindex="-1" aria-labelledby="Keep Details" aria-hidden="true">
    <div class="modal-dialog">
      <div v-if="activeKeep" class="modal-content">
        <div class="modal-header">
          <div>
            <img :src="activeKeep.img" :alt="activeKeep.name" class="img-fluid rounded border border-3 shadow">
          </div>
          <div>
            <h1 class="modal-title fs-5" id="active_keep_name">{{ activeKeep.name }}</h1>
          </div>
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


<style lang="scss" scoped></style>