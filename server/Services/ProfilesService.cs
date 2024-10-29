

namespace keeper.Services;


public class ProfilesService
{

  public ProfilesService(ProfilesRepository profilesRepository)
  {

    _profilesRepository = profilesRepository;

  }

  private readonly ProfilesRepository _profilesRepository;

  internal Profile GetProfile(string profileId)
  {
    Profile profile = _profilesRepository.GetProfile(profileId);

    if (profile == null)
    {
      throw new Exception("Invalid Profile Id");
    }
    return profile;
  }

  internal List<Keep> GetKeepsByProfile(string profileId, Account account)
  {
    List<Keep> keeps = _profilesRepository.GetKeepsByProfile(profileId, account);

    if (keeps == null)

    {
      throw new Exception("Profile has no Keeps");
    }

    if (profileId == null)
    {
      throw new Exception("Error: Invalid Profile Id");
    }

    return keeps;
  }
}

