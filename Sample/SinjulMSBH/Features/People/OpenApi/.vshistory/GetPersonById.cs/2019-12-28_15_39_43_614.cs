using System.Net;

using Carter.OpenApi;

using Sample.SinjulMSBH.Domain;

namespace Sample.SinjulMSBH.Features.People.OpenApi
{
	public class GetPersonById : RouteMetaData
	{
		public override RouteMetaDataResponse[] Responses => new[]
		{
			new RouteMetaDataResponse
			{
				Code = (int)HttpStatusCode.OK,
				Description = $"An {nameof(Person)} .. !!!!",
				Response = typeof(Person)
			},

			new RouteMetaDataResponse
			{
				Code = (int)HttpStatusCode.NotFound,
				Description = $"{nameof(Person)} not found .. !!!!"
			}
		};

		public override string Description => "Data for a specific person";

		public override string Tag => "People";

		public override string OperationId => "getPersonById";
	}
}
