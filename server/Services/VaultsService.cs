

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

  internal Vault GetVaultById(int vaultId)
  {
    Vault vault = _repository.GetVaultById(vaultId);
    if (vault == null)
    {
      throw new Exception("Error: Invalid Vault Id");
    }
    return vault;
  }
}