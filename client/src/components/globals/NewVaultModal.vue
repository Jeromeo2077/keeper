<script setup>
import { ref } from 'vue';
import { vaultsService } from '@/services/VaultsService.js';
import Pop from '@/utils/Pop.js';
import { logger } from '@/utils/Logger.js';

const vaultName = ref('');
const vaultDescription = ref('');

async function createVault() {
  try {
    await vaultsService.createVault({ name: vaultName.value, description: vaultDescription.value });
    Pop.success('Vault created successfully');
    // Optionally, you can reset the form fields or close the modal
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
              <input type="text" class="form-control" id="vaultName" v-model="vaultName" required>
            </div>
            <div class="mb-3">
              <label for="vaultDescription" class="form-label">Description</label>
              <textarea class="form-control" id="vaultDescription" v-model="vaultDescription" required></textarea>
            </div>
            <button type="submit" class="btn btn-primary">Create Vault</button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<style scoped></style>