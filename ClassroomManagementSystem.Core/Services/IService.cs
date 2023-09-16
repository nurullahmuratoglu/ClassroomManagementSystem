using ClassroomManagementSystem.Core.Dtos;
using ClassroomManagementSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomManagementSystem.Core.Services
{
    public interface IService<Entity,Dto> where Entity : BaseEntity where Dto : class
    {
        Task<ResponseDto<NoContentDto>> AddAsync(Dto dto);
        Task<ResponseDto<NoContentDto>> UpdateAsync(Dto dto);
        Task<ResponseDto<NoContentDto>> RemoveAsync(int id);
        Task<ResponseDto<Dto>> GetByIdAsync(int id);
        Task<ResponseDto<IEnumerable<Dto>>> GetAllAsync();
        Task<bool> AnyAsync(int id);
    }
}
