namespace keeper.Repositories;


public class VaultsRepository
{
  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }

  private readonly IDbConnection _db;


}
