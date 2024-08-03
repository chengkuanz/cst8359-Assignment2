namespace Lab5.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public int FanId { get; set; }
        public string SportClubId { get; set; }

        // Navigational properties
        public Fan Fan { get; set; }
        public SportClub SportClub { get; set; }


    }
}
