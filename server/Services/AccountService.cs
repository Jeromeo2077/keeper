namespace keeper.Services;

public class AccountService
{
  private readonly AccountsRepository _repo;

  public AccountService(AccountsRepository repo)
  {
    _repo = repo;
  }

  private Account GetAccount(string accountId)
  {
    Account account = _repo.GetById(accountId);
    if (account == null)
    {
      throw new Exception("Invalid Account Id");
    }
    return account;
  }

  internal Account GetOrCreateAccount(Account userInfo)
  {
    Account account = _repo.GetById(userInfo.Id);
    if (account == null)
    {
      return _repo.Create(userInfo);
    }
    return account;
  }

  internal Account EditAccount(Account editAccountData, string accountId)
  {
    Account original = GetAccount(accountId);
    original.Name = editAccountData.Name ?? editAccountData.Name;
    original.Picture = editAccountData.Picture ?? editAccountData.Picture;
    original.CoverImg = editAccountData.CoverImg ?? editAccountData.CoverImg;
    return _repo.Edit(original);
  }
}
