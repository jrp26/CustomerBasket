
namespace Price.Entities
{
    public sealed class Offer
    {
        public string Title { get; set; }
        public Trigger Trigger { get; set; }
        public Reward Reward { get; set; }
        
        public Offer(string title, Trigger trigger, Reward reward)
        {
            Title = title;
            Trigger = trigger;
            Reward = reward;
        }
    }
}
