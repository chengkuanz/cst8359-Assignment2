using System.Collections.Generic;

namespace Lab5.Models.ViewModels
{
    public class FanViewModel
    {
        public IEnumerable<Fan> Fans { get; set; }
        public IEnumerable<Subscription> Subscriptions { get; set; }
        public IEnumerable<SportClub> SportClubs { get; set; }
    }
}

