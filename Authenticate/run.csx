#r "Microsoft.WindowsAzure.Storage"
#load "IClientAuthenticationService.csx"
#load "ClientAuthenticationService.csx"
#load "IUserRepository.csx"
#load "UserRepository.csx"
#load "Result.csx"

using System.Net;
using System;

public static HttpResponseMessage Run(HttpRequestMessage req, string username, string token, TraceWriter log)
{  
    var authenticationService = new ClientAuthenticationService();

   if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(token))
    {
        var resultErrorInput = new Result { ResultCode = 3, Message = "Parameter invalid" };
        return req.CreateResponse(HttpStatusCode.BadRequest, resultErrorInput);
    }

    bool authenticated = authenticationService.Authenticate(username, token);
    if (authenticated)
    {
        // authentication ok
        var resultOk = new Result { ResultCode = 1 };
        return req.CreateResponse(HttpStatusCode.OK, resultOk);
    }

    // authentication failed
    var resultError = new Result
    {
        ResultCode = 2,
        ////Message = "whatever reason" // optional
    };
    
    return req.CreateResponse(HttpStatusCode.BadRequest, resultError);
}