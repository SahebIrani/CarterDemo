using System.Net;

using Carter.OpenApi;

namespace Sample.SinjulMSBH.Features.People.OpenApi
{
	public class AddPeople : RouteMetaData
	{

		public override RouteMetaDataRequest[] Requests { get; } =
		{
			new RouteMetaDataRequest
			{
				Request = typeof(Actor),
			}
		};

		public override RouteMetaDataResponse[] Responses { get; }
			= { new RouteMetaDataResponse { Code = (int)HttpStatusCode.Created, Description = "Created Person" } };

		public override string Description { get; } = "Create an person in the system .. !!!!";

		public override string Tag { get; } = "Person";

		public override string OperationId { get; } = "People_AddPerson";
	}
}
