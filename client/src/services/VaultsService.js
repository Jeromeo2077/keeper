import { AppState } from "@/AppState.js";
import { api } from "./AxiosService.js";
import { logger } from "@/utils/Logger.js";
import { Keep } from "@/models/Keep.js";


class VaultsService {


    async getAllKeeps() {
      const response = await api.get('api/keeps');
      const keeps = response.data.map(keepPojo => new Keep(keepPojo));
      logger.log(response.data)
      AppState.keeps = keeps;
    }
    }

    export const vaultsService = new VaultsService();
