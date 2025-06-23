using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopChain.Application.Commons;
using ShopChain.Application.Dtos;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;

namespace ShopChain.Application.Commands.UserClientCommands
{
    /// <summary>
    /// 
    /// </summary>
    public class RegisterUserClientRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }

    public record RegisterUserClientCommand(RegisterUserClientRequest request) : IRequest<Result<UserClientDto>>;

    public class RegisterUserClientCommandValidator : AbstractValidator<RegisterUserClientCommand>
    {
        public RegisterUserClientCommandValidator()
        {
            RuleFor(x => x.request.Username)
             .NotEmpty().WithMessage("Username is required.")
             .Length(3, 50).WithMessage("Username must be between 3 and 50 characters.");

            RuleFor(x => x.request.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(x => x.request.FullName)
                .NotEmpty().WithMessage("Full name is required.")
                .MaximumLength(100).WithMessage("Full name cannot exceed 100 characters.");
        }
    }

    public class RegisterUserClientCommandHandler : IRequestHandler<RegisterUserClientCommand, Result<UserClientDto>>
    {
        private readonly IUserClientRepository _userClientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RegisterUserClientCommandHandler> _logger;
        private readonly IValidator<RegisterUserClientCommand> _validator;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserClientCommandHandler(IUserClientRepository userClientRepository, IMapper mapper, ILogger<RegisterUserClientCommandHandler> logger, IValidator<RegisterUserClientCommand> validator, IPasswordHasher passwordHasher)
        {
            _userClientRepository = userClientRepository ?? throw new ArgumentNullException(nameof(userClientRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }

        public async Task<Result<UserClientDto>> Handle(RegisterUserClientCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling RegisterUserClientCommand for {Username}", request.request.Username);

            // 1. Input Validation
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                _logger.LogWarning("Validation failed for RegisterUserClientCommand: {Errors}", errors);
                return Result<UserClientDto>.Failure($"Validation failed: {errors}");
            }

            // 2. Business Rules Validation
            var businessValidation = await ValidateBusinessRules(request, cancellationToken);
            if (!businessValidation.IsSuccess)
            {
                _logger.LogWarning("Business validation failed: {Error}", businessValidation.Error);
                return Result<UserClientDto>.Failure(businessValidation.Error!);
            }

            // 3. Create Entity with Business Logic
            var userClient = RegisterUserClient(request);

            // 4. Save to Repository (Repository chỉ làm data access)
            var savedUserClient = await _userClientRepository.RegisterAsync(userClient, cancellationToken);

            // 5. Map to DTO
            var userClientDto = _mapper.Map<UserClientDto>(savedUserClient);

            _logger.LogInformation("UserClient {Username} registered successfully", userClientDto.Username);

            return Result<UserClientDto>.Success(userClientDto);
        }

        private async Task<Result<bool>> ValidateBusinessRules(RegisterUserClientCommand request, CancellationToken cancellationToken)
        {
            // 1. Check if Username already exists
            var existingUser = await _userClientRepository.GetByUsernameAsync(request.request.Username, cancellationToken);
            if (existingUser != null)
            {
                _logger.LogWarning("Username {Username} already exists", request.request.Username);
                return Result<bool>.Failure($"Username '{request.request.Username}' is already taken.");
            }
            return Result<bool>.Success(true);
        }

        private UserClient RegisterUserClient(RegisterUserClientCommand request)
        {
            return new UserClient
            {
                Username = request.request.Username,
                PasswordHash = _passwordHasher.HashPassword(request.request.Password),
                FullName = request.request.FullName,
                Role = "User", // Default role
                CreatedAt = DateTime.UtcNow // Use UTC for consistency
            };
        }
    }
}
