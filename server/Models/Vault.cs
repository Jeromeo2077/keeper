using System.ComponentModel.DataAnnotations;

namespace keeper.Models
{
  public class Vault
  {
    [Required]
    public int Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; }

    [MaxLength(255)]
    [Required]
    public string Name { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }

    [MaxLength(1000)]
    [Url]
    public string Img { get; set; }

    [Required]
    public bool IsPrivate { get; set; } = false;
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
    public List<VaultKeep> VaultKeeps { get; set; }
  }

  public class VaultCreationDTO
  {
    [MaxLength(255)]
    public string Name { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }

    [MaxLength(1000)]
    [Url]
    public string Img { get; set; }

    public bool IsPrivate { get; set; } = false;
    public string CreatorId { get; set; }
  }
}