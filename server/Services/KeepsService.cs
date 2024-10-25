

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
    return keep;
  }


  // internal List<Keep> GetKeepById(int keepId, string userId)
  // {
  //   List<Keep> keep = _repository.GetKeepById(keepId, userId);
  //   return keep;
  // }
}