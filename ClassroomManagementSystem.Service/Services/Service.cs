using ClassroomManagementSystem.Core.Dtos;
using ClassroomManagementSystem.Core.Model;
using ClassroomManagementSystem.Core.Repositories;
using ClassroomManagementSystem.Core.Services;
using ClassroomManagementSystem.Core.UnitOfWorks;
using ClassroomManagementSystem.Service.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ClassroomManagementSystem.Service.Services
{
    public class Service<Entity, Dto> : IService<Entity, Dto> where Entity : BaseEntity where Dto : class
    {
        private readonly IGenericRepository<Entity> _genericRepository;
        protected readonly IUnitOfWorks _unitOfWorks;

        public Service(IGenericRepository<Entity> genericRepository, IUnitOfWorks unitOfWorks)
        {
            _genericRepository = genericRepository;
            _unitOfWorks = unitOfWorks;
        }

        public async Task<ResponseDto<NoContentDto>> AddAsync(Dto dto)
        {
            var newEntity = ObjectMapper.Mapper.Map<Entity>(dto);
            await _genericRepository.AddAsync(newEntity);
            await _unitOfWorks.CommitAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<IEnumerable<Dto>>> GetAllAsync()
        {

            var entites = await _genericRepository.GetAll().ToListAsync();
            var dtos = ObjectMapper.Mapper.Map<IEnumerable<Dto>>(entites);
            return ResponseDto<IEnumerable<Dto>>.Success(StatusCodes.Status200OK, dtos);
        }

        public async Task<ResponseDto<Dto>> GetByIdAsync(int id)
        {

            if (!await AnyAsync(id))
            {
                return ResponseDto<Dto>.Fail(StatusCodes.Status404NotFound,"Id Not Found");
            }
            var entity = await _genericRepository.GetByIdAsync(id);
            var dto = ObjectMapper.Mapper.Map<Dto>(entity);
            return ResponseDto<Dto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ResponseDto<NoContentDto>> RemoveAsync(int id)
        {
            if (!await AnyAsync(id))
            {
                return ResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound, "Id Not Found");
            }
            var entity = await _genericRepository.GetByIdAsync(id);
            _genericRepository.Remove(entity);
            await _unitOfWorks.CommitAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }

        public async Task<ResponseDto<NoContentDto>> UpdateAsync(Dto dto)
        {
            var entity = ObjectMapper.Mapper.Map<Entity>(dto);
            _genericRepository.UpdateAsync(entity);
            await _unitOfWorks.CommitAsync();
            return ResponseDto<NoContentDto>.Success(StatusCodes.Status200OK);
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _genericRepository.AnyAsync(id);
        }
    }
}
