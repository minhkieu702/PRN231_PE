using System;
using System.Collections.Generic;

namespace PEPRN231_SU24_009909_KieuQuangMinh_FE.Models;
public partial class FootballClub
{
    public string FootballClubId { get; set; } = null!;

    public string ClubName { get; set; } = null!;

    public string ClubShortDescription { get; set; } = null!;

    public string SoccerPracticeField { get; set; } = null!;

    public string Mascos { get; set; } = null!;

    public virtual ICollection<FootballPlayer> FootballPlayers { get; set; } = new List<FootballPlayer>();
}
