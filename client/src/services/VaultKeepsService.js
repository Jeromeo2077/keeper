import { api } from "./AxiosService.js";

class VaultKeepsService {

  async createVaultKeep(vaultKeepData) {
    const response = await api.post('api/vaultkeeps', vaultKeepData)
    return response.data
  }

  // async delete(vaultKeep) {
  //   return await dbContext.VaultKeeps.findOneAndDelete(vaultKeep)
  // }

}

export const vaultKeepsService = new VaultKeepsService();