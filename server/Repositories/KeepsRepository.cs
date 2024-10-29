namespace keeper.Repositories;

public class KeepsRepository
{

  public KeepsRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal Keep CreateKeep(KeepCreationDTO keepCreationData, string creatorId)
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

    return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
    {
      keep.Creator = profile;
      return keep;
    }, new { keepCreationData.Name, keepCreationData.Description, keepCreationData.Img, keepCreationData.Views, keepCreationData.Kept, creatorId }).FirstOrDefault();
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

  internal Keep UpdateKeepById(Keep keep, int keepId)
  {
    string sql = @"
        UPDATE keeps
        SET
          name = @Name,
          description = @Description,
          img = @Img,
          views = @Views,
          kept = @Kept
        WHERE id = @KeepId;
        SELECT
          keeps.*,
          accounts.*
        FROM
          keeps
        JOIN 
          accounts ON keeps.creatorId = accounts.id
        WHERE keeps.id = @KeepId;";

    return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
    {
      keep.Creator = profile;
      return keep;
    }, new { keep.Name, keep.Description, keep.Img, keep.Views, keep.Kept, keepId }).FirstOrDefault();
  }

  internal void DeleteKeepById(int keepId)
  {
    string sql = @"
        DELETE FROM keeps
        WHERE id = @keepId
        LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { keepId });

    if (rowsAffected == 0)
    {
      throw new Exception("Error: No Keep Found");
    }

    if (rowsAffected > 1)
    {
      throw new Exception("Error: More than one Keep Deleted");
    }
  }
}