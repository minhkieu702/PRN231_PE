using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PEPRN231_SU24_009909_KieuQuangMinh_FE.Models;
public partial class PremierLeagueAccount
{
    [Required]
    public string Password { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string? EmailAddress { get; set; }
}
