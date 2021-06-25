using AutoMapper;
using Investz.Data.Entities;
using Investz.Exceptions;
using Investz.Interfaces;
using Investz.Models;
using Investz.Shared.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investz.Services
{
    public class UserService : IUserService
    {
        public readonly IEnumerable<UserCredentialsDto> users;

        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserDto> GetUser(string username)
        {
            UserEntity userEntity = await userRepository.GetUser(username);

            UserDto dto = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserEntity, UserDto>();
               // cfg.ForAllMaps((map, exp) => exp.ForAllOtherMembers(opt => opt.Ignore()));
            }).CreateMapper().Map<UserDto>(userEntity);

            return dto;
        }

        public async Task ValidateCredentials(UserCredentialsDto userCredentials)
        {
            UserDto user = await GetUser(userCredentials.Username);


            if (user.Username != userCredentials.Username || user.Password != userCredentials.Password)
            {
                throw new InvalidCredentialsException();
            }
        }
    }
}
