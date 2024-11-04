using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Repositories;

public partial class PremierLeagueAccount
{
    [JsonIgnore]
    public int AccId { get; set; }
    [Required]
    public string Password { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string? EmailAddress { get; set; }
    [JsonIgnore]
    public string Description { get; set; } = null!;
    [JsonIgnore]
    public int? Role { get; set; }
}
