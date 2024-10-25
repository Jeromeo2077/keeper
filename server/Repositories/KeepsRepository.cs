

namespace keeper.Repositories;

public class KeepsRepository
{

  public KeepsRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal Keep CreateKeep(KeepCreationDTO keepCreationData, string CreatorId)
  {
    string sql = @"
      INSERT INTO keeps
      (name, description, img, views, kept, creatorId)
      VALUES
      (@Name, @Description, @Img, @Views, @kept, @CreatorId);

      SELECT
        keeps.*,
        accounts.*
      FROM 
        keeps
      JOIN 
        accounts ON keeps.creatorId = accounts.id
      WHERE keeps.id = LAST_INSERT_ID();";

    return _db.Query<Keep, Account, Keep>(sql, (keep, profile) =>
    {
      keep.Creator = profile;
      return keep;
    }, new { keepCreationData.Name, keepCreationData.Description, keepCreationData.Img, keepCreationData.Views, keepCreationData.Kept, CreatorId }).FirstOrDefault();
  }


  internal List<Keep> GetAllKeeps()
  {
    string sql = @"
      SELECT
        keeps.*,
        accounts.*
      FROM
        keeps
      JOIN 
        accounts ON keeps.creatorId = accounts.id;";

    return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
    {
      keep.Creator = profile;
      return keep;
    }).ToList();
  }


  // internal List<Keep> GetAllKeeps(Account userInfo)
  // {
  //   string sql = @"
  //     SELECT
  //       keeps.*,
  //       accounts.*
  //     FROM
  //       keeps
  //     JOIN 
  //       accounts ON keeps.creatorId = accounts.id;";

  //   return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
  //   {
  //     keep.Creator = profile;
  //     return keep;
  //   }).ToList();
  // }


  internal Keep GetKeepById(int keepId)
  {
    string sql = @"
      SELECT
        keeps.*,
        accounts.*
      FROM
        keeps
      JOIN 
        accounts ON keeps.creatorId = accounts.id
      WHERE keeps.id = @keepId;";

    Keep keep = _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
    {
      keep.Creator = profile;
      return keep;
    }, new { keepId }).FirstOrDefault();
    return keep;
  }
}