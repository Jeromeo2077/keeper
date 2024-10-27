using System.ComponentModel.DataAnnotations;

namespace keeper.Models;

public class VaultKeep
{
  [Required]
  public int Id { get; set; }

  [Required]
  public int VaultId { get; set; }

  [Required]
  public int KeepId { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }

}