using System.Collections.Generic;

namespace Lab5.Models.ViewModels
{
    public class NewsViewModel
    {
       public IEnumerable<News> News { get; set; }
        
        public SportClub SportClub { get; set; }
    }
}
