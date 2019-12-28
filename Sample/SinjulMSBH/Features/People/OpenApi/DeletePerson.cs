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

		public override string Description => "Delete an perosn .. !!!!";

		public override string Tag => "People";

		public override string OperationId => "deletePerson";
	}
}
