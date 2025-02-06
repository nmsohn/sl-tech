using FluentValidation;

namespace Vanilla.Application.Features.User;

// public class UserValidator : AbstractValidator<CreateUserRequestDto>
// {
//     public UserValidator()
//     {
//         RuleLevelCascadeMode = ClassLevelCascadeMode;
//         
//         RuleFor(u => u.Email)
//             .NotEmpty()
//             .NotNull()
//             .MaximumLength(320);
//     }
// }