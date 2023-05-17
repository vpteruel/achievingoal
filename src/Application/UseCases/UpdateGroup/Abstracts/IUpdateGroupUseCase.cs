using Application.UseCases.UpdateGroup.Dtos;

namespace Application.UseCases.UpdateGroup.Abstracts
{
    public interface IUpdateGroupUseCase
    {
        Task UpdateAsync(UpdateGroupDto groupDto, CancellationToken cancellationToken);
    }
}