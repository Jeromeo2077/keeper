namespace keeper.Controllers;


public class ProfilesController : ControllerBase
{

  public ProfilesController(ProfilesService profilesService)
  {
    _profilesService = profilesService;
  }

  private readonly ProfilesService _profilesService;

}