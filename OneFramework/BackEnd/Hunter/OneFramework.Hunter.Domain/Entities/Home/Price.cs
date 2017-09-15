namespace OneFramework.Hunter.Domain.Entities.Home
{
    public class Price : BaseEntity
    {
        public Money PricePerNight { get; set; }
        public Money CleaningFee { get; set; }
        public Money WeekendPrice { get; set; }
    }
}
