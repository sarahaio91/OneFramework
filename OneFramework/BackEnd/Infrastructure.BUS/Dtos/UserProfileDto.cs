using System;

namespace Application.Dtos
{
    public class UserProfileDto : Application.Dtos.BaseDto
    {
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string CurrentlyResidingIn { get; set; }
        public string State { get; set; }
        public string MonthlySalaryExpectation { get; set; }
        public virtual Application.Dtos.UserDto User { get; set; }
        public Guid UserId { get; set; }
    }
}
