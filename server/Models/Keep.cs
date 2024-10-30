using System.ComponentModel.DataAnnotations;

namespace keeper.Models;

public class Keep
{
  public int Id { get; set; }

  public DateTime CreatedAt { get; set; }

  public DateTime UpdatedAt { get; set; }

  [MaxLength(255)]
  public string Name { get; set; }

  [MaxLength(1000)]
  public string Description { get; set; }

  [MaxLength(1000)]
  [Url]
  public string Img { get; set; }

  public int Views { get; set; } = 0;

  public int Kept { get; set; } = 0;

  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
  public Vault Vault { get; set; }
}


public class KeepCreationDTO
{
  [MaxLength(255)]
  public string Name { get; set; }

  [MaxLength(1000)]
  public string Description { get; set; }

  [MaxLength(1000)]
  [Url]
  public string Img { get; set; }

  public int Views { get; set; } = 0;

  public int Kept { get; set; } = 0;

  public string CreatorId { get; set; }
}