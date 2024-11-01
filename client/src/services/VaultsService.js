import { api } from "./AxiosService.js";
import { Vault } from "@/models/Vault.js";
import { AppState } from "@/AppState.js";

class VaultsService {

  async getVaultDetailsById(vaultId) {
    const response = await api.get('api/vaults/' + vaultId);
    AppState.activeVault = response.data;
  }

  async createVault(newVaultData) {
    const response = await api.post('api/vaults', newVaultData);
    const newVault = new Vault(response.data);
    AppState.accountVaults.unshift(newVault);
  }

  async deleteVault(vaultId) {
    await api.delete('api/vaults/' + vaultId);
    AppState.accountVaults = AppState.accountVaults.filter(vault => vault.id !== vaultId);
  }

  async getVaultsByAccountId(accountId) {
    AppState.accountVaults = []
    const response = await api.get(`/account/vaults`);
    const vaults = response.data.map(vaultPojo => new Vault(vaultPojo));
    AppState.accountVaults = vaults;
  }
}

export const vaultsService = new VaultsService();
