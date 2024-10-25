using System.ComponentModel.DataAnnotations;

namespace keeper.Models;

public class Keep
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
  [Required]
  public string Description { get; set; }

  [MaxLength(1000)]
  [Url]
  public string Img { get; set; }

  [Required]
  public int Views { get; set; } = 0;

  [Required]
  public int Kept { get; set; } = 0;

  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
}


public class KeepCreationDTO
{
  [MaxLength(255)]
  [Required]
  public string Name { get; set; }

  [MaxLength(1000)]
  [Required]
  public string Description { get; set; }

  [MaxLength(1000)]
  [Url]
  public string Img { get; set; }

  [Required]
  public int Views { get; set; } = 0;

  [Required]
  public int Kept { get; set; } = 0;

  public string CreatorId { get; set; }
}