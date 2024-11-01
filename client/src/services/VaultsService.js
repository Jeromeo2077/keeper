import { api } from "./AxiosService.js";
import { Vault } from "@/models/Vault.js";
import { AppState } from "@/AppState.js";
import App from "@/App.vue";

class VaultsService {

  async getVaultsByAccountId(accountId) {
    AppState.accountVaults = []
    const response = await api.get(`/account/vaults`);
    const vaults = response.data.map(vaultPojo => new Vault(vaultPojo));
    AppState.accountVaults = vaults;
  }
}

    export const vaultsService = new VaultsService();
