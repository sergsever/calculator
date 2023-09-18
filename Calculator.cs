using calculator.Data;

namespace calculator
{
	public class Calculator : ICalculator
	{
		private readonly DataContext dbcontext;
		public float Compute(int weight, int height, int lenght, int width, string FiasFrom, string FiasTo)
		{
			City cityFrom = dbcontext.cities.Where(e => e.FiasCode == FiasFrom).FirstOrDefault<City>();
			City cityTo = dbcontext.cities.Where(c => c.FiasCode == FiasTo).FirstOrDefault<City>();
			/* Стоимость на основе географического положения отправителя и получателя. */
			/*Коэфициенты на вес и габариты*/
			return 100.0F;

		}
		public Calculator(DataContext dbcontext)
		{
			this.dbcontext = dbcontext;

//			dbcontext.init();
		}

//		public Calculator() { }
}
}
