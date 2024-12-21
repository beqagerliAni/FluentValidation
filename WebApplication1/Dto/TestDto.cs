using FluentValidation;
using WebApplication1.Dto;

namespace WebApplication1.Dto
{
    public class TestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}

public class TestDtoValidator : AbstractValidator<TestDto>
{
    public TestDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name must not be empty")
            .NotNull();

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("email must not be empty")
            .EmailAddress()
            .WithMessage("email must be valid");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("New password is required.")
            .MinimumLength(8)
            .WithMessage("New password must be at least 8 characters long.")
            .Matches("[A-Z]")
            .WithMessage("New password must contain at least one uppercase letter.")
            .Matches("[a-z]")
            .WithMessage("New password must contain at least one lowercase letter.")
            .Matches("[0-9]")
            .WithMessage("New password must contain at least one digit.")
            .Matches("[^a-zA-Z0-9]")
            .WithMessage("New password must contain at least one special character.");

        RuleFor(command => command.RePassword)
            .NotEmpty()
            .WithMessage("Re-entering the new password is required.")
            .Equal(command => command.Password)
            .WithMessage("RePassword must match NewPassword.");
    }
}
