

namespace keeper.Repositories;


public class VaultsRepository
{
  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }

  private readonly IDbConnection _db;

  internal Vault CreateVault(VaultCreationDTO vaultCreationData, string creatorId)
  {
    string sql = @"
    INSERT INTO vaults
    (name, description, img, isPrivate, creatorId)
    VALUES
    (@Name, @Description, @Img, @IsPrivate, @CreatorId);

    SELECT
      vaults.*,
      accounts.*
    FROM
      vaults
    JOIN 
      accounts ON vaults.creatorId = accounts.id
    WHERE vaults.id = LAST_INSERT_ID();";

    return _db.Query<Vault, Account, Vault>(sql, (vault, profile) =>
    {
      vault.Creator = profile;
      return vault;
    }, new { vaultCreationData.Name, vaultCreationData.Description, vaultCreationData.Img, vaultCreationData.IsPrivate, creatorId }).FirstOrDefault();
  }


  internal Vault GetVaultById(int vaultId)
  {
    string sql = @"
      SELECT
        vaults.*,
        accounts.*
      FROM
        vaults
      JOIN
        accounts ON vaults.creatorId = accounts.id
      WHERE vaults.id = @vaultId;";

    return _db.Query<Vault, Account, Vault>(sql, (vault, profile) =>
    {
      vault.Creator = profile;
      return vault;
    }, new { vaultId }).FirstOrDefault();
  }
}
