import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js";
import { Vault } from "@/models/Vault.js";
import { AppState } from "@/AppState.js";

class VaultsService {


  async getVaultsByAccountId(accountId) {
    const response = await api.get(`/account/vaults`);
    const vaults = response.data.map(vaultPojo => new Vault(vaultPojo));
    AppState.vaults = vaults;
    logger.log(response.data);
  }



}

    export const vaultsService = new VaultsService();
