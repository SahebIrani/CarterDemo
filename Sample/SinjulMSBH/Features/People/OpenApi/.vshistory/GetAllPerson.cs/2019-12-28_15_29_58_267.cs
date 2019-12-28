using System.Collections.Generic;

using Carter.OpenApi;

using Sample.SinjulMSBH.Domain;

namespace Sample.SinjulMSBH.Features.People.OpenApi
{
	public class GetPeople : RouteMetaData
	{
		public override RouteMetaDataResponse[] Responses { get; } =
		{
			new RouteMetaDataResponse
			{
				Code = 200,
				Description = $"A list of people .. !!!!",
				Response = typeof(IEnumerable<Person>)
			}
		};

		public override string Description { get; } = "Returns a list of people .. !!!!";

		public override string Tag { get; } = "People";

		public override string OperationId { get; } = "People_GetPeople";
	}
}
