using PEPRN231_SU24_009909_KieuQuangMinh_FE.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PEPRN231_SU24_009909_KieuQuangMinh_FE.Models;
public partial class FootballPlayer
{
    [Required]
    public string FootballPlayerId { get; set; } = null!;
    [Required]
    [FullnameValidation]
    public string FullName { get; set; } = null!;
    [Required]
    [Length(9, 100)]
    public string Achievements { get; set; } = null!;
    [Required]
    [BirthdayValidation]
    public DateTime? Birthday { get; set; }
    [Required]
    public string PlayerExperiences { get; set; } = null!;
    [Required]
    [Length(9, 100)]
    public string Nomination { get; set; } = null!;
    [Required]
    public string? FootballClubId { get; set; }

    public virtual FootballClub? FootballClub { get; set; }
}
