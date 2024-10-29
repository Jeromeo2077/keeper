
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
    string sql = "SELECT * FROM profiles WHERE id = @profileId";

    return _db.QueryFirstOrDefault<Profile>(sql, new { profileId });
  }
}

