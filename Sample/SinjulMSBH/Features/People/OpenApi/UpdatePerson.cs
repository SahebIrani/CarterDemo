using System.Net;

using Carter.OpenApi;

using Sample.SinjulMSBH.Domain;

namespace Sample.SinjulMSBH.Features.People.OpenApi
{
	public class UpdatePerson : RouteMetaData
	{
		public override RouteMetaDataRequest[] Requests => new[]
		{
			new RouteMetaDataRequest{Request = typeof(Person)}
		};

		public override RouteMetaDataResponse[] Responses => new[]
		{
			new RouteMetaDataResponse {
				Code =  (int)HttpStatusCode.NoContent,
				Description = "Updated Person .. !!!!"
			},

			new RouteMetaDataResponse {
				Code =  (int)HttpStatusCode.UnprocessableEntity,
				Description = "Validation Errors .. !!!!"
			}
		};

		public override string Description => "Update an existing person .. !!!!";

		public override string Tag => "People";

		public override string OperationId => "updatePerson";
	}
}
