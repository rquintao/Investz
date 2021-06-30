using AutoMapper;
using Investz.Data.Entities;
using Investz.Exceptions;
using Investz.Interfaces;
using Investz.Models;
using Investz.Shared.Interfaces.Repositories;
using Investz.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investz.Services
{
    public class UserService : Service<UserEntity> ,IUserService
    {
        public readonly IEnumerable<UserCredentialsDto> users;

        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            
        }

        public async Task<ResponseSingleDto<UserDto>> GetUser(string username)
        {
            UserEntity userEntity = await userRepository.GetUser(username);

            UserDto dto = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserEntity, UserDto>();

            }).CreateMapper().Map<UserDto>(userEntity);

            return new ResponseSingleDto<UserDto>() { Entity = dto};
        }

        public async Task ValidateCredentials(UserCredentialsDto userCredentials)
        {
            ResponseSingleDto<UserDto> user = await GetUser(userCredentials.Username);

            if (user.Entity is null) {
                throw new InvalidLoginException("User does not exist");
            }

            if (user.Entity.Username != userCredentials.Username || user.Entity.Password != userCredentials.Password)
            {
                throw new InvalidCredentialsException();
            }
        }
    }
}
