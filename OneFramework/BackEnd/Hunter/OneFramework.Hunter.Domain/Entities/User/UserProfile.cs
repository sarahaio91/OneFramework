using System;

namespace OneFramework.Hunter.Domain.Entities.User
{
    public class UserProfile : BaseEntity
    {
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string CurrentlyResidingIn { get; set; }
        public string State { get; set; }
        public string MonthlySalaryExpectation { get; set; }
        public virtual Hunter.Domain.Entities.User.User User { get; set; }
        public Guid UserId { get; set; }

    }
}
