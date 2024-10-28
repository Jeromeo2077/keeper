

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

  internal List<VaultKeep_Keep> GetKeepsByVaultId(int vaultId)
  {
    string sql = @"
      SELECT 
        keeps.*,
        vaultkeeps.*,
        accounts.*
      FROM 
        vaultkeeps
      JOIN 
        keeps ON vaultkeeps.keepId = keeps.id
      JOIN
        accounts ON vaultkeeps.creatorId = accounts.id
      WHERE 
        vaultkeeps.vaultId = @vaultId;";

    List<VaultKeep_Keep> vaultKeep_Keeps = _db.Query<Keep, VaultKeep_Keep, Account, VaultKeep_Keep>(sql, (keep, vaultKeep, profile) =>
    {
      vaultKeep.Creator = profile;
      vaultKeep.Id = keep.Id;
      vaultKeep.Name = keep.Name;
      vaultKeep.Description = keep.Description;
      vaultKeep.Img = keep.Img;
      vaultKeep.Views = keep.Views;
      vaultKeep.Kept = keep.Kept;
      vaultKeep.CreatorId = keep.CreatorId;
      return vaultKeep;
    }, new { vaultId }).ToList();

    return vaultKeep_Keeps;
  }
}