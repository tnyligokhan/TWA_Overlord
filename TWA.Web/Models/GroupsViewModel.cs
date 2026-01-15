namespace TWA.Web.Models
{
    public class GroupsViewModel
    {
        public List<VillageGroup> Groups { get; set; } = new List<VillageGroup>();
    }

    public class VillageGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Color { get; set; } = "#007bff";
        public int VillageCount { get; set; }
        public List<int> VillageIds { get; set; } = new List<int>();
    }
}
