using Application.UseCases.CreateUser.Dtos;

namespace Application.UseCases.CreateUser.Abstracts
{
    public interface ICreateUserUseCase
    {
        Task CreateAsync(CreateUserDto userDto, CancellationToken cancellationToken);
    }
}