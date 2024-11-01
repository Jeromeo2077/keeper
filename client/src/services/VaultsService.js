import { api } from "./AxiosService.js";
import { Vault } from "@/models/Vault.js";
import { AppState } from "@/AppState.js";

class VaultsService {

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
