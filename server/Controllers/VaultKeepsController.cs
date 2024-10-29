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
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext) ?? new Account();
      VaultKeep vaultKeep = _vaultKeepsService.CreateVaultKeep(vaultKeepCreationData, userInfo);
      return Ok(vaultKeep);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }


  [Authorize]
  [HttpDelete("{vaultKeepId}")]
  public async Task<ActionResult<string>> DeleteKeepVault(int vaultKeepId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext) ?? new Account();
      _vaultKeepsService.DeleteKeepVault(vaultKeepId, userInfo);
      return Ok("You are no longer following this Keep");
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}