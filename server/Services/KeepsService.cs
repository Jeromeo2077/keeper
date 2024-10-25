


namespace keeper.Services;

public class KeepsService
{
  private readonly KeepsRepository _repository;

  public KeepsService(KeepsRepository repository)
  {
    _repository = repository;
  }


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

    if (keep == null)
    {
      throw new Exception("Error: Invalid Keep Id");
    }

    if (keep.CreatorId != userInfo.Id)
    {
      throw new Exception("Invalid Access: You are not the creator of this Keep");
    }

    keep = _repository.UpdateKeepById(keepUpdateData, keepId);

    return keep;
  }

}