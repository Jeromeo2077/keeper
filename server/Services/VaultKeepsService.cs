

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
    Vault vault = _vaultsService.GetVaultById(vaultKeepCreationData.VaultId, userInfo);

    if (vault.CreatorId != userInfo.Id)
    {
      throw new Exception("Invalid Access: You are not the creator of this Vault");
    }

    VaultKeep vaultKeep = _repository.CreateVaultKeep(vaultKeepCreationData, userInfo.Id);
    return vaultKeep;
  }


  internal List<VaultKeep_Keep> GetKeepsByVaultId(int vaultId, Account userInfo)
  {
    _vaultsService.GetVaultById(vaultId, userInfo);

    return GetKeepsByVaultId(vaultId);
  }


  private List<VaultKeep_Keep> GetKeepsByVaultId(int vaultId)
  {
    return _repository.GetKeepsByVaultId(vaultId);
  }

  internal void DeleteKeepVault(int vaultKeepId, Account userInfo)
  {
    VaultKeep vaultKeep = GetVaultKeepById(vaultKeepId);

    if (vaultKeep.CreatorId != userInfo.Id)
    {
      throw new Exception("Invalid Access: You are not the creator of this VaultKeep");
    }
    _repository.DeleteKeepVault(vaultKeepId);
  }

  private VaultKeep GetVaultKeepById(int vaultKeepId)
  {
    VaultKeep vaultKeep = _repository.GetVaultKeepById(vaultKeepId);

    if (vaultKeep == null)
    {
      throw new Exception("Error: Invalid VaultKeep Id");
    }

    return vaultKeep;
  }
}