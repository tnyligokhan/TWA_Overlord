namespace TWA.Web.Models
{
    public class TribeViewModel
    {
        public string TribeName { get; set; } = string.Empty;
        public string TribeTag { get; set; } = string.Empty;
        public int MemberCount { get; set; }
        public int TotalPoints { get; set; }
        public int Rank { get; set; }
        public int TotalVillages { get; set; }
    }

    public class TribeMembersViewModel
    {
        public List<TribeMember> Members { get; set; } = new List<TribeMember>();
    }

    public class TribeMember
    {
        public string PlayerName { get; set; } = string.Empty;
        public int Points { get; set; }
        public int VillageCount { get; set; }
        public string Rank { get; set; } = string.Empty;
    }
}
