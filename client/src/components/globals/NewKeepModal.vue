<script setup>
import { ref } from 'vue';
import { keepsService } from '@/services/KeepsService.js';
import Pop from '@/utils/Pop.js';
import { logger } from '@/utils/Logger.js';
import Modal from 'bootstrap/js/dist/modal.js';


const editableKeepData = ref({
  name: '',
  description: '',
  image: '',
})


async function createKeep() {
  try {
    await keepsService.createKeep(editableKeepData.value);
    Modal.getInstance('#NewKeepModal').hide();
    Pop.success('Keep created successfully');
  } catch (error) {
    Pop.error(error);
    logger.error(error);
  }
}
</script>


<template>
  <div class="modal fade" id="NewKeepModal" tabindex="-1" aria-labelledby="NewKeepModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="NewKeepModalLabel">Create New Keep</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">

          <form @submit.prevent="createKeep">
            <div class="mb-3">
              <label for="keepName" class="form-label">Keep Name</label>
              <input type="text" class="form-control" id="keepName" v-model="editableKeepData.name" required>
            </div>
            <div class="mb-3">
              <label for="keepDescription" class="form-label">Keep Description</label>
              <textarea class="form-control" id="keepDescription" v-model="editableKeepData.description"
                required></textarea>
            </div>
            <div class="mb-3">
              <label for="keepImage" class="form-label">Keep Imageg</label>
              <textarea class="form-control" id="keepImage" v-model="editableKeepData.image" required></textarea>
            </div>
            <button type="submit" class="btn btn-primary">Create Keep</button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped></style>
