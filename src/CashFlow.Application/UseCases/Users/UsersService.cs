using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Requests.Auth;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Security;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using FluentValidation.Results;

namespace CashFlow.Application.UseCases.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAccessTokenGenerator _accessTokenGenerator;
        private readonly IPasswordEncripter _passwordEncripter;
        public UsersService(
            IUserRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPasswordEncripter passwordEncripter,
            IAccessTokenGenerator accessTokenGenerator)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accessTokenGenerator = accessTokenGenerator;
            _passwordEncripter = passwordEncripter;
        }

        #region NovoLogin
        public async Task<ResponseRegisteredUserJson> Register(RequestRegisterUserJson request)
        {
            await Validate(request);

            var user = _mapper.Map<User>(request);

            user.Password = _passwordEncripter.Encrypt(request.Password);
            user.UserIdentifier = Guid.NewGuid();

            await _repository.Create(user);
            await _unitOfWork.Commit();

            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
                Token = _accessTokenGenerator.Generate(user)
            };
        }

        public async Task<ResponseRegisteredUserJson> Login(RequestLogin request)
        {
            var user = await _repository.GetByEmail(request.Email) ?? throw new InvalidLoginException();

            if (!_passwordEncripter.Verify(request.Password, user.Password))
            {
                throw new InvalidLoginException();
            }

            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
                Token = _accessTokenGenerator.Generate(user)
            };
        }

        private async Task Validate(RequestRegisterUserJson request)
        {
            var result = new RegisterUserValidator().Validate(request);
            var emailAlreadyExists = await _repository.ExistActiveUserWithEmail(request.Email);

            if (emailAlreadyExists)
            {
                result.Errors.Add(new ValidationFailure("Email", ResourceErrorMessages.EMAIL_ALREADY_EXISTS));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
        #endregion

        #region LoginVelho

        //public async Task<string> Login(RequestLogin request)
        //{
        //    var userExists = await _repository.GetByEmail(request.Email);

        //    if (userExists == null)
        //    {
        //        throw new NotFoundException(ResourceErrorMessages.USER_NOT_FOUND);
        //    }

        //    if (!PasswordService.VerifyPassword(request.Password, userExists.Password))
        //    {
        //        throw new NotFoundException("Senha inválida");
        //    }

        //    return GenerateToken(userExists);
        //}

        //public async Task Register(RequestCreateUser request)
        //{
        //    var userAlreadyExists = await _repository.GetByEmail(request.Email);

        //    if (userAlreadyExists is not null)
        //    {
        //        throw new EntityAlreadyExists(ResourceErrorMessages.USER_ALREADY_EXISTS);
        //    }

        //    var newUser = _mapper.Map<User>(request);
        //    newUser.Password = PasswordService.HashPassword(request.Password);

        //    await _repository.Create(newUser);
        //    await _unitOfWork.Commit();
        //}

        //private string GenerateToken(User user)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.NameIdentifier, user.Name),
        //            new Claim(ClaimTypes.UserData, user.Id.ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(1),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        //        Issuer = _configuration["Jwt:Issuer"],
        //        Audience = _configuration["Jwt:Audience"]
        //    };

        //    var token = tokenHandler.CreateToken(tokenDescriptor);

        //    return tokenHandler.WriteToken(token);
        //}

        #endregion
    }
}
