using Microsoft.AspNetCore.Builder;

namespace Lab5.Models.ViewModels
{
    public class SubscriptionViewModel
    {
        public string SportClubName { get; set; }
        public string SportClubId { get; set; }

        public Fan Fan { get; set; }
        public List<SubscriptionViewModel> Subscriptions { get; set; }
        public List<SportClub> AllClubs { get; set; }
    }
}
//edit subscription
