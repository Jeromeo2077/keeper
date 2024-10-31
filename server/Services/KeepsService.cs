namespace keeper.Services;

public class KeepsService
{

  public KeepsService(KeepsRepository repository)
  {
    _repository = repository;
  }
  private readonly KeepsRepository _repository;


  internal Keep CreateKeep(KeepCreationDTO keepCreationData, Account userInfo)
  {
    return _repository.CreateKeep(keepCreationData, userInfo.Id);
  }


  internal List<Keep> GetAllKeeps()
  {
    List<Keep> keep = _repository.GetAllKeeps();
    return keep;
  }


  // internal List<Keep> GetAllKeeps(String userId)
  // {
  //   List<Keep> keep = _repository.GetAllKeeps(userId);
  //   return keep;
  // }


  internal Keep GetKeepById(int keepId)
  {
    Keep keep = _repository.GetKeepById(keepId);

    if (keep == null)
    {
      throw new Exception("Error: Invalid Keep Id");
    }
    return keep;
  }



  // internal List<Keep> GetKeepById(int keepId, string userId)
  // {
  //   List<Keep> keep = _repository.GetKeepById(keepId, userId);
  //   return keep;
  // }


  internal Keep UpdateKeepById(KeepCreationDTO keepUpdateData, int keepId, Account userInfo)
  {

    Keep keep = _repository.GetKeepById(keepId);

    if (keep.CreatorId != userInfo.Id)
    {
      throw new Exception("Invalid Access: You are not the creator of this Keep");
    }

    keep.Name = keepUpdateData.Name ?? keep.Name;
    keep.Description = keepUpdateData.Description ?? keep.Description;
    keep.Img = keepUpdateData.Img ?? keep.Img;
    keep.Views = keepUpdateData.Views;
    keep.Kept = keepUpdateData.Kept;


    keep = _repository.UpdateKeepById(keep, keepId);

    return keep;
  }


  internal String DeleteKeepById(int keepId, Account userInfo)
  {
    Keep keep = _repository.GetKeepById(keepId);

    if (keep.CreatorId != userInfo.Id)
    {
      throw new Exception("Invalid Access: You are not the creator of this Keep");
    }

    _repository.DeleteKeepById(keepId);
    return $"Keep {keep.Name} has been successfully deleted";
  }

  internal List<Keep> KeepsByAccountId(Account userInfo)
  {
    List<Keep> keeps = _repository.GetKeepsByAccountId(userInfo);
    keeps = keeps.FindAll(keep => keep.CreatorId == userInfo.Id);

    if (keeps == null)
    {
      throw new Exception("No Vaults Found");
    }

    return keeps;
  }
}