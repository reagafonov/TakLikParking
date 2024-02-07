using Microsoft.AspNetCore.Mvc;

namespace WebApi.Contracts.Requests;

public class GetBookingByIdRequest
{
    [FromRoute]
    public int Id { get; set; }
}