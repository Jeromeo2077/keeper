namespace keeper.Services;

public class VaultsService
{
  public VaultsService(VaultsRepository repository)
  {
    _repository = repository;
  }
  private readonly VaultsRepository _repository;


}