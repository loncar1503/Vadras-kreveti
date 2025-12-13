using API_Vadras.DTO.Radnik;
using Domain;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace API_Vadras.Repository.RadniciRepo
{
    public interface IRadnici
    {
        Task<Radnik?> VratiRadnika(string username, string password);
    }
}
