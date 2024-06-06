using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CashFlow.Application.UseCases.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UsersService(
            IUserRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IConfiguration config)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = config;
        }

        public async Task<string> Login(RequestLogin request)
        {
            var userExists = await _repository.GetByEmail(request.Email);

            if (userExists == null)
            {
                throw new NotFoundException(ResourceErrorMessages.USER_NOT_FOUND);
            }

            if (!PasswordService.VerifyPassword(request.Password, userExists.Password))
            {
                throw new NotFoundException("Senha inválida");
            }

            return GenerateToken(userExists);
        }

        public async Task Register(RequestCreateUser request)
        {
            var userAlreadyExists = await _repository.GetByEmail(request.Email);

            if (userAlreadyExists is not null)
            {
                throw new EntityAlreadyExists(ResourceErrorMessages.USER_ALREADY_EXISTS);
            }

            var newUser = _mapper.Map<User>(request);
            newUser.Password = PasswordService.HashPassword(request.Password);

            await _repository.Create(newUser);
            await _unitOfWork.Commit();
        }
    
        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Name),
                    new Claim(ClaimTypes.UserData, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
