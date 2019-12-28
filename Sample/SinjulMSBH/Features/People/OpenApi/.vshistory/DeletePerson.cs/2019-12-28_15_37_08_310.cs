using System.Net;

using Carter.OpenApi;

namespace Sample.SinjulMSBH.Features.People.OpenApi
{
	public class DeletePerson : RouteMetaData
	{
		public override RouteMetaDataResponse[] Responses => new[]
		{
			new RouteMetaDataResponse {
				Code =  (int)HttpStatusCode.NoContent,
				Description = "Deleted Person .. !!!!"
			}
		};

		public override string Description => "Delete an actor";

		public override string Tag => "Actors";

		public override string OperationId => "deleteActor";
	}
}
