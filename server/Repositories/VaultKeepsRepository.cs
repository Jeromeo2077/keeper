

namespace keeper.Repositories;


public class VaultKeepsRepository
{
  public VaultKeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  private readonly IDbConnection _db;

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepCreationData, string creatorId)
  {
    string sql = @"
      INSERT INTO vaultkeeps
      (vaultId, keepId, creatorId)
      VALUES
      (@VaultId, @KeepId, @CreatorId);

      SELECT
        vaultkeeps.*,
        accounts.*
      FROM
        vaultkeeps
      JOIN
        accounts ON vaultkeeps.creatorId = accounts.id
      WHERE vaultkeeps.id = LAST_INSERT_ID();";


    return _db.Query<VaultKeep, Account, VaultKeep>(sql, (vaultKeep, profile) =>
    {
      vaultKeep.Creator = profile;
      return vaultKeep;
    }, new { vaultKeepCreationData.VaultId, vaultKeepCreationData.KeepId, creatorId }).FirstOrDefault();
  }

  internal List<VaultKeep> GetKeepsByVaultId(int vaultId)
  {
    string sql = @"
      SELECT * FROM 
        vaultkeeps
      JOIN 
        accounts ON vaultkeeps.creatorId = accounts.id
      WHERE 
        vaultkeeps.vaultId = @vaultId;";

    return _db.Query<VaultKeep, Account>(sql, (VaultKeep, profile) =>
    {
      VaultKeep.Creator = profile;
      return VaultKeep;
    }, new { vaultId }).ToList();
  }
}