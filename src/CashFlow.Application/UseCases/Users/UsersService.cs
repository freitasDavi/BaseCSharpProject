using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Requests.Auth;
using CashFlow.Communication.Requests.Users;
using CashFlow.Communication.Responses;
using CashFlow.Communication.Responses.Users;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Security;
using CashFlow.Domain.Services.LoggedUser;
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
        private readonly ILoggedUser _loggedUser;
        public UsersService(
            IUserRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPasswordEncripter passwordEncripter,
            IAccessTokenGenerator accessTokenGenerator,
            ILoggedUser loggedUser)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accessTokenGenerator = accessTokenGenerator;
            _passwordEncripter = passwordEncripter;
            _loggedUser = loggedUser;
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

        public async Task<User> GetUserByToken(string token)
        {
            var identifier = _accessTokenGenerator.GetUserFromToken(token);
            var user = await _repository.GetUserByIdentifier(identifier) ?? throw new NotFoundException("???? ta de roleplay?");

            return user;
        }

        public async Task<ResponseUserProfileJson> Get()
        {
            var user = await _loggedUser.Get();

            return _mapper.Map<ResponseUserProfileJson>(user);  
        }

        public async Task Update(RequestUpdateUserJson request)
        {
            var loggedUser = await _loggedUser.Get();

            await Validate(request, loggedUser.Email);

            var user = await _repository.GetUserById(loggedUser.Id);    

            user.Name = request.Name;
            user.Email = request.Email;

            _repository.Update(user);

            await _unitOfWork.Commit();
        }

        private async Task Validate(RequestUpdateUserJson request, string currentEmail)
        {
            var validator = new UpdateUserValidator();

            var result = validator.Validate(request);

            if (currentEmail.Equals(request.Email) == false)
            {
                var userExists = await _repository.ExistActiveUserWithEmail(request.Email);

                if (userExists)
                    result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_EXISTS));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }

        public async Task ChangePassword(RequestChangePasswordJson request)
        {
            var loggedUser = await _loggedUser.Get();

            Validate(request, loggedUser);

            var user = await _repository.GetUserById(loggedUser.Id);

            user.Password = _passwordEncripter.Encrypt(request.NewPassword);

            _repository.Update(user);

            await _unitOfWork.Commit(); 
        }

        private void Validate(RequestChangePasswordJson request, User loggedUser)
        {
            var validator = new ChangePasswordValidator();

            var result = validator.Validate(request);

            var passwordMatch = _passwordEncripter.Verify(request.Password, loggedUser.Password);

            if (passwordMatch == false) 
            {
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.PASSWORD_DIFFERENT_CURRENT_PAST));
            }

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();    
                
                throw new ErrorOnValidationException(errors);
            }
        }

        public async Task DeleteUserAccount()
        {
            var user = await _loggedUser.Get();

            await _repository.Delete(user);

            await _unitOfWork.Commit();
        }

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
