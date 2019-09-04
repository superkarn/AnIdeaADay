using AIAD.Library.Models;

namespace AIAD.Library.Services.Interfaces
{
    public interface IJwtService
    {
        JwtUser Authenticate(string apiToken);
    }
}
