namespace keeper.Services;


public class ProfilesService
{

  public ProfilesService(ProfilesRepository profilesRepository)
  {

    _profilesRepository = profilesRepository;

  }

  private readonly ProfilesRepository _profilesRepository;

}

