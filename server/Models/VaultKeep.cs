namespace keeper.Models;

public class VaultKeep
{
  public int Id { get; set; }

  public int VaultId { get; set; }

  public int KeepId { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
  public Keep Keep { get; set; }
  public Vault Vault { get; set; }
}

public class VaultKeep_Keep : Keep
{
  public int VaultKeepId { get; set; }
}