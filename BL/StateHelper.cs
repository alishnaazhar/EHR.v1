using BL.DTOs.PatientDTOs;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Security.Claims;

namespace BL;
public interface IStateHelper
{
    GetPatientDTO User();
}

public class StateHelper:IStateHelper
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public StateHelper(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public GetPatientDTO User()
    {
        var result = string.Empty;
        if (_httpContextAccessor.HttpContext is not null)
            result = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.UserData).Value;

        return JsonConvert.DeserializeObject<GetPatientDTO>(result!)!;
    }


}
