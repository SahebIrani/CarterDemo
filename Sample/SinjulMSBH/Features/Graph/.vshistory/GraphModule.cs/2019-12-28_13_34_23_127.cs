using System.IO;

using Carter;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Internal;

namespace Sample.SinjulMSBH.Features.Graph
{
	public class GraphModule : CarterModule
	{
		public GraphModule(DfaGraphWriter graphWriter, EndpointDataSource endpointDataSource)
		{
			this.Get("/graph", async context =>
			{
				var sw = new StringWriter();
				graphWriter.Write(endpointDataSource, sw);
				await context.Response.WriteAsync(sw.ToString());
			});
		}
	}
}
