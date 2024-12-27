using BlogApp.BL.DTOs.UserDTOs;
using BlogApp.Core.Entities;
using BlogApp.Core.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Validators.UserValidators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        readonly IUserRepository _userRepository;
        public CreateUserDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();
            RuleFor(x => x.Username)
                .NotEmpty()
                .NotNull()
                .Must(x =>
                {
                    return _userRepository.GetByUserNameAsync(x).Result == null;
                })
                .WithMessage("Username exist");
                

        }
    }
}
