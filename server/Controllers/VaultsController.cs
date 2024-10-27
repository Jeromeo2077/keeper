namespace keeper.Controllers;


[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  public VaultsController(VaultsService vaultsService)
  {
    _vaultsService = vaultsService;
  }
  private readonly VaultsService _vaultsService;


}