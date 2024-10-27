
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
}