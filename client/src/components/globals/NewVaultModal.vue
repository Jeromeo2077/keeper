<script setup>
import { ref } from 'vue';
import { vaultsService } from '@/services/VaultsService.js';
import Pop from '@/utils/Pop.js';
import { logger } from '@/utils/Logger.js';
import Modal from 'bootstrap/js/dist/modal.js';

const editableVaultData = ref({
  name: '',
  description: '',
  img: '',
})

async function createVault() {
  try {
    await vaultsService.createVault(editableVaultData.value);
    Modal.getInstance('#NewVaultModal').hide();
    Pop.success('Vault created successfully');
  } catch (error) {
    Pop.error(error);
    logger.error(error);
  }
}
</script>

<template>
  <div class="modal fade" id="NewVaultModal" tabindex="-1" aria-labelledby="NewVaultModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="NewVaultModalLabel">Create New Vault</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <!-- Form content for creating a new vault -->
          <form @submit.prevent="createVault">
            <div class="mb-3">
              <label for="vaultName" class="form-label">Vault Name</label>
              <input type="text" class="form-control" id="vaultName" v-model="editableVaultData.name" required>
            </div>
            <div class="mb-3">
              <label for="vaultDescription" class="form-label">Vault Description</label>
              <textarea class="form-control" id="vaultDescription" v-model="editableVaultData.description"
                required></textarea>
            </div>
            <div class="mb-3">
              <label for="vaultImage" class="form-label">Vault Image</label>
              <textarea class="form-control" id="vaultImage" v-model="editableVaultData.img" required></textarea>
            </div>
            <button type="submit" class="btn btn-primary">Create Vault</button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<style scoped></style>