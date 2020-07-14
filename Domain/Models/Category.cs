namespace TimeshEAT.Domain.Models
{
	public class Category : Entity
	{
        public Category()
        {
            
        }

		public Category(int id, string name, bool applicableDailyDiscount, long version) : base(id, version)
		{
			Name = name;
			ApplicableDailyDiscount = applicableDailyDiscount;
		}

		public string Name { get; set; }
		public bool ApplicableDailyDiscount { get; set; }
	}
}
