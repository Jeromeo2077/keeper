namespace keeper.Services;

public class VaultKeepsService
{
  public VaultKeepsService(VaultKeepsRepository repository)
  {
    _repository = repository;
  }

  private readonly VaultKeepsRepository _repository;

}