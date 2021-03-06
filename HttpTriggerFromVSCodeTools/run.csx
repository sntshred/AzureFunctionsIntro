#load "../Shared/Helper.csx"
using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    // parse query parameter
    // string name = req.GetQueryNameValuePairs()
    //     .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
    //     .Value;

    // // Get request body
    // dynamic data = await req.Content.ReadAsAsync<object>();

    // // Set name to query string or body data
    // name = name ?? data?.name;
    var name = await GetName(req);
    return name == null
        ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
        : req.CreateResponse(HttpStatusCode.OK, "Helper says hello " + name);
}
