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
  public string Img { get; set; }

  public int Views { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
}


public class KeepCreationDTO
{
  public string Name { get; set; }
  public string Description { get; set; }
  public string Img { get; set; }
  public int Views { get; set; }
  public string CreatorId { get; set; }
}