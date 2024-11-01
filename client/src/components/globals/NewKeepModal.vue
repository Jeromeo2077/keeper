<script setup>
import { ref } from 'vue';
import { keepsService } from '@/services/KeepsService.js';
import Pop from '@/utils/Pop.js';
import { logger } from '@/utils/Logger.js';

const keepName = ref('');
const keepDescription = ref('');

async function createKeep() {
  try {
    await keepsService.createKeep({ name: keepName.value, description: keepDescription.value });
    Pop.success('Keep created successfully');
    // Optionally, you can reset the form fields or close the modal
  } catch (error) {
    Pop.error(error);
    logger.error(error);
  }
}
</script>


<template>
  <div class="modal fade" id="newKeepModal" tabindex="-1" aria-labelledby="newKeepModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="newKeepModalLabel">Create New Keep</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <!-- Form content for creating a new keep -->
          <form @submit.prevent="createKeep">
            <div class="mb-3">
              <label for="keepName" class="form-label">Keep Name</label>
              <input type="text" class="form-control" id="keepName" v-model="keepName" required>
            </div>
            <div class="mb-3">
              <label for="keepDescription" class="form-label">Description</label>
              <textarea class="form-control" id="keepDescription" v-model="keepDescription" required></textarea>
            </div>
            <button type="submit" class="btn btn-primary">Create Keep</button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped></style>
