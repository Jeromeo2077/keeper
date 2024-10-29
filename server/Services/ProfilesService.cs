

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

  internal List<Vault> GetVaultsByProfile(string profileId, Account account)
  {

    if (profileId == null)
    {
      throw new Exception("Error: Invalid Profile Id");
    }


    List<Vault> vaults = _profilesRepository.GetVaultsByProfile(profileId);

    if (vaults == null || vaults.Count == 0)
    {
      throw new Exception("Profile has no Vaults");
    }

    List<Vault> resultVaults;

    if (account.Id != profileId)
    {
      resultVaults = vaults.FindAll(vault => !vault.IsPrivate);
    }
    else
    {
      resultVaults = vaults.ToList();
    }

    if (resultVaults == null || resultVaults.Count == 0)
    {
      throw new Exception("Profile has no Vaults");
    }

    return resultVaults;
  }
}

