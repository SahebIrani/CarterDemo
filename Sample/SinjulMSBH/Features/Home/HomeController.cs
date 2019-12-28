using Microsoft.AspNetCore.Mvc;

namespace Sample.SinjulMSBH.MVC
{
	public class HomeController : Controller
	{
		public string Index() =>
			$"Hello SinjulMSBH from {nameof(HomeController)} and {nameof(Index)} method .. !!!!";
	}
}
