using Application.UseCases.GetGroups.Dtos;

namespace Application.UseCases.GetGroups.Abstracts
{
    public interface IGetGroupsUseCase
    {
        Task<IEnumerable<GetGroupsDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}