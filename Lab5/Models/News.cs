using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
   

    public class News
    {
        [Key]
        public int NewsId { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        [Required]
        public string SportClubId { get; set; }

        [Required]
        public SportClub SportClub { get; set; }



    }
}
