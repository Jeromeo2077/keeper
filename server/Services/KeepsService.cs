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
}