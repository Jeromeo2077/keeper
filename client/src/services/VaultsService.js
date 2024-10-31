import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js";
import { Vault } from "@/models/Vault.js";
import { AppState } from "@/AppState.js";

class VaultsService {
  getVaultDetailsById(keepId) {
    throw new Error('Method not implemented.');
  }


  async getVaultsByAccountId(accountId) {
    const response = await api.get(`/account/vaults`);
    const vaults = response.data.map(vaultPojo => new Vault(vaultPojo));
    AppState.accountVaults = vaults;
  }
}

    export const vaultsService = new VaultsService();
