namespace keeper.Controllers;


[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  public VaultsController(VaultsService vaultsService, Auth0Provider auth0Provider)
  {
    _vaultsService = vaultsService;
    _auth0Provider = auth0Provider;
  }
  private readonly VaultsService _vaultsService;
  private readonly Auth0Provider _auth0Provider;


  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Vault>> CreateVault([FromBody] VaultCreationDTO vaultCreationData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Vault vault = _vaultsService.CreateVault(vaultCreationData, userInfo);
      return Ok(vault);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}