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
				Response = typeof(Actor)
			},
			new RouteMetaDataResponse
			{
				Code = 404,
				Description = $"{nameof(Actor)} not found"
			}
		};

		public override string Description => "Data for a specific actor";

		public override string Tag => "Actors";

		public override string OperationId => "getActorById";
	}
}
