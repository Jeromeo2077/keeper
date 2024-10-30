import { Keep } from "@/models/Keep.js";
import { api } from "./AxiosService.js";
import { logger } from "@/utils/Logger.js";
import { AppState } from "@/AppState.js";

class KeepsService{
  
  async getAllKeeps() {
    const response = await api.get('api/keeps');
    const keeps = response.data.map(keepPojo => new Keep(keepPojo));
    logger.log(response.data)
    AppState.keeps = keeps;
  }
  

  async getKeepDetailsById(keepId) {
    AppState.activeKeep = null;
    const response = await api.get('api/keeps/' + keepId);
    const keep = new Keep(response.data);
    AppState.activeKeep = keep;
  }
}

export const keepsService = new KeepsService();