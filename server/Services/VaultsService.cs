namespace keeper.Services;

public class VaultsService
{
  public VaultsService(VaultsRepository repository)
  {
    _repository = repository;
  }
  private readonly VaultsRepository _repository;

  internal Vault CreateVault(VaultCreationDTO vaultCreationData, Account userInfo)
  {
    Vault vault = _repository.CreateVault(vaultCreationData, userInfo.Id);
    return vault;
  }


  internal Vault GetVaultById(int vaultId, Account userInfo)
  {
    Vault vault = _repository.GetVaultById(vaultId);

    if (vault == null)
    {
      throw new Exception("Error: Invalid Vault Id");
    }

    if (vault.IsPrivate == true && vault.CreatorId != userInfo.Id)
    {
      throw new Exception("Error: This Vault is Private");
    }
    return vault;
  }


  internal Vault UpdateVaultById(VaultCreationDTO vaultUpdateData, int vaultId, Account userInfo)
  {
    Vault vault = _repository.GetVaultById(vaultId);

    if (vault.CreatorId != userInfo.Id)
    {
      throw new Exception("Invalid Access: You are not the creator of this Vault");
    }

    vault.Name = vaultUpdateData.Name ?? vault.Name;
    vault.Description = vaultUpdateData.Description ?? vault.Description;
    vault.Img = vaultUpdateData.Img ?? vault.Img;
    vault.IsPrivate = vaultUpdateData.IsPrivate;
    vault.CreatorId = vault.CreatorId;

    vault = _repository.UpdateVaultById(vault, vaultId);
    return vault;
  }


  internal string DeleteVaultById(int vaultId, Account userInfo)
  {
    Vault vault = _repository.GetVaultById(vaultId);

    if (vault.CreatorId != userInfo.Id)
    {
      throw new Exception("Invalid Access: You are not the creator of this Vault");
    }

    _repository.DeleteVaultById(vaultId);
    return $"Vault {vault.Name} has been successfully deleted";
  }


  internal List<Vault> GetVaultsByAccountId(Account userInfo)
  {
    List<Vault> vaults = _repository.GetVaultsByAccountId(userInfo);
    vaults = vaults.FindAll(vault => vault.CreatorId == userInfo.Id);

    if (vaults == null)
    {
      throw new Exception("No Vaults Found");
    }

    return vaults;

  }
}