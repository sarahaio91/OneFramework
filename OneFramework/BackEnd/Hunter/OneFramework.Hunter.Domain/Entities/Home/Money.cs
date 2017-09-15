namespace OneFramework.Hunter.Domain.Entities.Home
{
    public class Money : BaseEntity
    {
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
    }
}
