namespace Sample.SinjulMSBH.Domain
{
	public class OpenApi
	{
		public string DocumentTitle { get; set; }
	}

	public class CarterOptions
	{
		public OpenApi OpenApi { get; set; }
	}

	public class AppConfiguration
	{
		public CarterOptions CarterOptions { get; set; }
	}
}
