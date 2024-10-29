
namespace keeper.Services;


public class ProfilesService
{

  public ProfilesService(ProfilesRepository profilesRepository)
  {

    _profilesRepository = profilesRepository;

  }

  private readonly ProfilesRepository _profilesRepository;

  internal Profile GetProfile(string profileId, Account account)
  {
    Profile profile = _profilesRepository.GetProfile(profileId);

    if (profile == null)
    {
      throw new Exception("Invalid Profile Id");
    }
    return profile;
  }
}

