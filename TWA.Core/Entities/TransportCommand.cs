namespace TWA.Core.Entities
{
    public class TransportCommand
    {
        public int SourceId { get; set; }
        public int TargetX { get; set; }
        public int TargetY { get; set; }
        public int Wood { get; set; }
        public int Stone { get; set; }
        public int Iron { get; set; }
    }
}
