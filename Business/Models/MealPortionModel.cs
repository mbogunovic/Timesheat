namespace TimeshEAT.Business.Models
{
    public class MealPortionModel
    {
        public MealModel Meal { get; set; }
        public PortionModel Portion { get; set; }
        public int Price { get; set; }
    }
}
