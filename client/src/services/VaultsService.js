import { AppState } from "@/AppState.js";
import { api } from "./AxiosService.js";
import { Vault } from "@/models/Vault.js";
import { logger } from "@/utils/Logger.js";


class VaultsService {


    async getAllVaults() {
      const response = await api.get('/vaults');
      const vaults = response.data.map(vaultPojo => new Vault(vaultPojo));
      logger.log(response.data)
      AppState.vaults = vaults;
    }
    }

    export const vaultsService = new VaultsService();
