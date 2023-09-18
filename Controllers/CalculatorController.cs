using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace calculator.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CalculatorController : ControllerBase
	{
		private readonly ICalculator _calculator;
		public CalculatorController(ICalculator calculator)
		{
			this._calculator = calculator;
		}
		// GET: api/<CalculatorController>
		[HttpGet]
		public float Get(int weight, int height, int lenght, int width, string FiasFrom, string FiasTo )
		{
			return _calculator.Compute(weight,height, lenght, width, FiasFrom, FiasTo);
		}

		// GET api/<CalculatorController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<CalculatorController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<CalculatorController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<CalculatorController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
