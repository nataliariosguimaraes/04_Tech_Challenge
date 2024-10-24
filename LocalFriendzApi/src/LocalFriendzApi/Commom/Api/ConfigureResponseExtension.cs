using LocalFriendzApi.Core.Models;
using LocalFriendzApi.Core.Responses;

namespace LocalFriendzApi.Commom.Api
{
    public static class ConfigureResponseExtension
    {
        public static IResult ConfigureResponseStatus(this PagedResponse<List<Contact>?> response)
        {
            return response.Code switch
            {
                200 => Results.Ok(response),
                201 => Results.Created(response.Data.FirstOrDefault()?.ToString() ?? string.Empty, response),
                400 => Results.BadRequest(response),
                404 => Results.NotFound(response),
                500 => Results.Problem(response.Message, statusCode: StatusCodes.Status500InternalServerError),
                _ => Results.NoContent(),
            };
        }

        public static IResult ConfigureResponseStatus(this Response<Contact>? response)
        {
            return response?.Code switch
            {
                200 => Results.Ok(response),
                201 => Results.Created(response.Data?.ToString() ?? string.Empty, response),
                400 => Results.BadRequest(response),
                404 => Results.NotFound(response),
                500 => Results.Problem(response.Message, statusCode: StatusCodes.Status500InternalServerError),
                _ => Results.NoContent(),
            };
        }
    }
}
