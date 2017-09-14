using System.Collections.Generic;

namespace Domain.Entities.Home
{
    public class Home : BaseEntity
    {
        public string Description { get; set; }
        public virtual string Amenities { get; set; }
        public Price Price { get; set; }
        public string HouseRules { get; set; }
        public virtual string SleepingSpaces { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
