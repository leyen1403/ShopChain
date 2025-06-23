using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopChain.Application.Commons;
using ShopChain.Application.Dtos;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Commands.UserClientCommands
{
    public class LoginUserClientRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginUserClientCommandValidator : AbstractValidator<LoginUserClientCommand>
    {
        public LoginUserClientCommandValidator()
        {
            // 1. Username must not be empty or whitespace
            RuleFor(x => x.request.Username)
                .NotEmpty()
                .WithMessage("Username must not be empty.")
                .Must(username => !string.IsNullOrWhiteSpace(username))
                .WithMessage("Username must not consist only of whitespace.");

            // 2. Password must not be empty or whitespace
            RuleFor(x => x.request.Password)
                .NotEmpty()
                .WithMessage("Password must not be empty.")
                .Must(password => !string.IsNullOrWhiteSpace(password))
                .WithMessage("Password must not consist only of whitespace.");
        }
    }


    public record LoginUserClientCommand(LoginUserClientRequest request) : IRequest<Result<LoginResponseDto>>;

    public class LoginUserClientCommandHandler : IRequestHandler<LoginUserClientCommand, Result<LoginResponseDto>>
    {
        private readonly IUserClientRepository _userClientRepository;

        private readonly IPasswordHasher _passwordHasher;

        private readonly ILogger<LoginUserClientCommandHandler> _logger;

        private readonly IValidator<LoginUserClientCommand> _validator;

        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginUserClientCommandHandler(IUserClientRepository userClientRepository, IPasswordHasher passwordHasher, ILogger<LoginUserClientCommandHandler> logger, IValidator<LoginUserClientCommand> validator, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userClientRepository = userClientRepository ?? throw new ArgumentNullException(nameof(userClientRepository));

            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _validator = validator ?? throw new ArgumentNullException(nameof(validator));

            _jwtTokenGenerator = jwtTokenGenerator ?? throw new ArgumentNullException(nameof(jwtTokenGenerator));
        }

        public async Task<Result<LoginResponseDto>> Handle(LoginUserClientCommand request, CancellationToken cancellationToken)
        {
            // 1. Validate input
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result<LoginResponseDto>.Failure(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));

            // 2. Tìm user theo username
            var user = await _userClientRepository.GetByUsernameAsync(request.request.Username, cancellationToken);
            if (user == null)
                return Result<LoginResponseDto>.Failure("Username or password is incorrect.");

            // 3. Kiểm tra password
            if (!_passwordHasher.VerifyPassword(request.request.Password, user.PasswordHash))
                return Result<LoginResponseDto>.Failure("Username or password is incorrect.");

            // 4. Sinh JWT
            var token = _jwtTokenGenerator.GenerateToken(user);

            // 5. Mapping kết quả trả về
            var dto = new LoginResponseDto
            {
                Username = user.Username,
                FullName = user.FullName,
                Token = token
            };

            return Result<LoginResponseDto>.Success(dto);
        }
    }
}
