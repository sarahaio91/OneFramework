using System;

namespace Contract.DAL.Entities
{
    public class UserProfile : BaseEntity
    {
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string CurrentlyResidingIn { get; set; }
        public string State { get; set; }
        public string MonthlySalaryExpectation { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }

    }
}
