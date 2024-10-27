
namespace keeper.Services;

public class VaultKeepsService
{
  public VaultKeepsService(VaultKeepsRepository repository)
  {
    _repository = repository;
  }

  private readonly VaultKeepsRepository _repository;

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepCreationData, Account userInfo)
  {
    VaultKeep vaultKeep = _repository.CreateVaultKeep(vaultKeepCreationData, userInfo.Id);
    return vaultKeep;
  }
}