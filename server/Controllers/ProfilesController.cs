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
  public async Task<ActionResult<Profile>> GetProfile(string profileId)
  {
    try
    {
      Account account = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Profile profile = _profilesService.GetProfile(profileId, account);
      return Ok(profile);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

}