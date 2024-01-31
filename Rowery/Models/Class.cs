
using System.ComponentModel.DataAnnotations;

namespace Rowery.Models;

public class Rower
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public long Price { get; set; }
    [Display(Name = "Is Available")]
    public bool IsAvailable { get; set; }
    public string? url_img { get; set; }
    public string? brand { get; set; }
    public int Weight { get; set; }

    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime RentDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReturnDate { get; set; }
}