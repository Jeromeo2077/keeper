import { Keep } from "@/models/Keep.js";
import { api } from "./AxiosService.js";
import { AppState } from "@/AppState.js";

class KeepsService{
  async deleteKeep(keepId) {
    await api.delete('api/keeps/' + keepId);
    AppState.keeps = AppState.keeps.filter(keep => keep.id !== keepId);
    AppState.accountKeeps = AppState.accountKeeps.filter(keep => keep.id !== keepId);
  }

  async getKeepsByAccountId(accountId) {
    AppState.accountKeeps = []
    const response = await api.get(`api/account/keeps`);
    const keeps = response.data.map(keepPojo => new Keep(keepPojo));
    AppState.accountKeeps = keeps;
  }
  
  async getAllKeeps() {
    const response = await api.get('api/keeps');
    const keeps = response.data.map(keepPojo => new Keep(keepPojo));
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