class VaultKeepsService {

  async createVaultKeep(vaultKeep) {
    return await dbContext.VaultKeeps.create(vaultKeep)
  }

  // async delete(vaultKeep) {
  //   return await dbContext.VaultKeeps.findOneAndDelete(vaultKeep)
  // }

}

export const vaultKeepsService = new VaultKeepsService();