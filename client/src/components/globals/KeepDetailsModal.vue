.
<script setup>
import { AppState } from '@/AppState.js';
import { Keep } from '@/models/Keep.js';
import { computed } from 'vue';

const activeKeep = computed(() => {
  return AppState.activeKeep;
});

</script>


<template>

  <div class="modal fade" id="KeepDetailsModal" tabindex="-1" aria-labelledby="KeepDetailsModalLabel"
    aria-hidden="true">
    <div class="modal-dialog modal-lg">
      <div v-if="activeKeep" class="modal-content">
        <div class="modal-body">
          <div class="row">
            <div class="col-md-6">
              <img :src="activeKeep.img" :alt="activeKeep.name" class="img-fluid rounded border border-3 shadow">
            </div>
            <div class="col-md-6">
              <div>
                <i class="mdi mdi-eye p-3">&nbsp; {{ activeKeep.views }} </i>
                <i class="mdi mdi-lock p-3">&nbsp; {{ activeKeep.kept }} </i>
              </div>
              <h3 class="mt-3">{{ activeKeep.name }}</h3>
              <p>{{ activeKeep.description }}</p>
            </div>
          </div>
        </div>

        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          <span>
            <ProfilePicture :profile="activeKeep.creator" />
          </span>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.modal-body {
  display: flex;
  align-items: center;
  padding: 1;
}

.img-fluid {
  max-width: 100%;
  height: 100%;
  object-fit: cover;
}

.modal-title {
  margin-bottom: 0;
}

.modal-footer {
  display: flex;
  justify-content: space-between;
}
</style>