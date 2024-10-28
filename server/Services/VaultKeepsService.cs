
namespace keeper.Services;

public class VaultKeepsService
{
  public VaultKeepsService(VaultKeepsRepository repository, VaultsService vaultsService)
  {
    _repository = repository;
    _vaultsService = vaultsService;
  }

  private readonly VaultKeepsRepository _repository;
  private readonly VaultsService _vaultsService;


  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepCreationData, Account userInfo)
  {
    VaultKeep vaultKeep = _repository.CreateVaultKeep(vaultKeepCreationData, userInfo.Id);
    return vaultKeep;
  }


  internal List<VaultKeep_Vault> GetKeepsByVaultId(int vaultId, Account userInfo)
  {
    _vaultsService.GetVaultById(vaultId, userInfo);

    return GetKeepsByVaultId(vaultId);
  }


  private List<VaultKeep_Vault> GetKeepsByVaultId(int vaultId)
  {
    return _repository.GetKeepsByVaultId(vaultId);
  }
}