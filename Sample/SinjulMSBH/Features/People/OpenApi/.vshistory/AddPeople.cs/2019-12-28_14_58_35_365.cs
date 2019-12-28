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

		public override RouteMetaDataResponse[] Responses { get; } = { new RouteMetaDataResponse { Code = 201, Description = "Created Actors" } };

		public override string Description { get; } = "Create an people in the system .. !!!!";

		public override string Tag { get; } = "People";

		public override string OperationId { get; } = "People_AddPeople";
	}
}
