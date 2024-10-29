namespace keeper.Repositories;


public class ProfilesRepository
{

  public ProfilesRepository(IDbConnection db)
  {
    _db = db;
  }

  private readonly IDbConnection _db;

}

