using System;

namespace JobLineCoreAPI.Models
{
    public class UserProfileModel : BaseModel
    {
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string CurrentlyResidingIn { get; set; }
        public string State { get; set; }
        public string MonthlySalaryExpectation { get; set; }
        public UserModel User { get; set; }
        public Guid UserId { get; set; }
    }
}