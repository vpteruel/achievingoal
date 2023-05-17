using Application.UseCases.CreateGroup.Dtos;

namespace Application.UseCases.CreateGroup.Abstracts
{
    public interface ICreateGroupUseCase
    {
        Task CreateAsync(CreateGroupDto groupDto, CancellationToken cancellationToken);
    }
}