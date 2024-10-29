
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
}

