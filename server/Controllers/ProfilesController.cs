namespace keeper.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{

  public ProfilesController(ProfilesService profilesService, Auth0Provider auth0Provider)
  {
    _profilesService = profilesService;
    _auth0Provider = auth0Provider;
  }

  private readonly Auth0Provider _auth0Provider;
  private readonly ProfilesService _profilesService;


  [HttpGet("{profileId}")]
  public ActionResult<Profile> GetProfile(string profileId)
  {
    try
    {
      Profile profile = _profilesService.GetProfile(profileId);
      return Ok(profile);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }


  [HttpGet("{profileId}/keeps")]
  public async Task<ActionResult<List<Keep>>> GetKeepsByProfile(string profileId)
  {
    try
    {
      Account account = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Keep> keeps = _profilesService.GetKeepsByProfile(profileId, account);
      return Ok(keeps);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }


  [HttpGet("{profileId}/vaults")]
  public async Task<ActionResult<List<Vault>>> GetVaultsByProfile(string profileId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Vault> vaults = _profilesService.GetVaultsByProfile(profileId, userInfo);
      return Ok(vaults);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

}