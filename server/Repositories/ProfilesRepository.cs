


namespace keeper.Repositories;


public class ProfilesRepository
{

  public ProfilesRepository(IDbConnection db)
  {
    _db = db;
  }

  private readonly IDbConnection _db;

  internal Profile GetProfile(string profileId)
  {
    string sql = @"
    SELECT
      id,
      createdAt,
      updatedAt,
      name,
      picture
    FROM 
      accounts 
    WHERE id = @profileId;";

    return _db.Query<Profile>(sql, new { profileId }).FirstOrDefault();
  }

  internal List<Keep> GetKeepsByProfile(string profileId, Account account)
  {
    string sql = @"
    SELECT
      keeps.*,
      accounts.*
    FROM 
      keeps
    JOIN 
      accounts ON keeps.creatorId = accounts.id
    WHERE 
      keeps.creatorId = @profileId;";

    return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
    {
      keep.Creator = profile;
      return keep;
    }, new { profileId }).ToList();
  }

  internal List<Vault> GetVaultsByProfile(string profileId, Account account)
  {
    string sql = @"
    SELECT
      vaults.*,
      accounts.*
    FROM
      vaults
    JOIN
      accounts ON vaults.creatorId = accounts.id
    WHERE
      vaults.creatorId = @profileId;";

    return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
    {
      vault.Creator = profile;
      return vault;
    }, new { profileId }).ToList();
  }
}

