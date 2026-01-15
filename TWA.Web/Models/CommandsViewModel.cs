namespace TWA.Web.Models
{
    public class CommandsViewModel
    {
        public string SelectedType { get; set; } = "outgoing"; // outgoing, incoming
        public List<CommandItem> Commands { get; set; } = new List<CommandItem>();
        public int TotalCount { get; set; }
    }

    public class CommandItem
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty; // attack, support, return
        public string OriginVillage { get; set; } = string.Empty;
        public string TargetVillage { get; set; } = string.Empty;
        public DateTime ArrivalTime { get; set; }
        public bool CanCancel { get; set; }
        public string Icon { get; set; } = string.Empty;
        public string ColorClass { get; set; } = string.Empty;
    }
}
