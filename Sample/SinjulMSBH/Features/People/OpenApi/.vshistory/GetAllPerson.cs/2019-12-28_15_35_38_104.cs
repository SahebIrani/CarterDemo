using System.Collections.Generic;
using System.Net;

using Carter.OpenApi;

using Sample.SinjulMSBH.Domain;

namespace Sample.SinjulMSBH.Features.People.OpenApi
{
	public class GetAllPerson : RouteMetaData
	{
		public override RouteMetaDataResponse[] Responses { get; } =
		{
			new RouteMetaDataResponse
			{
				Code = (int)HttpStatusCode.OK,
				Description = $"A list of people .. !!!!",
				Response = typeof(IEnumerable<Person>)
			}
		};

		public override string Description { get; } = "Returns a list of persons .. !!!!";

		public override string Tag { get; } = "People";

		public override string OperationId { get; } = "GetAllPerson";
	}
}
