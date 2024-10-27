namespace keeper.Controllers;


[ApiController]
[Route("api/[controller]")]
public class VaultKeepsController : ControllerBase
{
  public VaultKeepsController(VaultKeepsService vaultKeepsService, Auth0Provider auth0Provider)
  {
    _vaultKeepsService = vaultKeepsService;
    _auth0Provider = auth0Provider;
  }

  private readonly VaultKeepsService _vaultKeepsService;
  private readonly Auth0Provider _auth0Provider;


  [Authorize]
  [HttpPost]
  public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep vaultKeepCreationData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      VaultKeep vaultKeep = _vaultKeepsService.CreateVaultKeep(vaultKeepCreationData, userInfo);
      return Ok(vaultKeep);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }


}