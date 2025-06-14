using MediatR;
using ShopChain.Application.Dtos;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Application.Queries.UserClientQueries
{
    public record GetTokenQuery(string username, string password) : IRequest<string>;

    public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery, string>
    {
        private readonly IUserClientRepository _userClientRepository;
        public GetTokenQueryHandler(IUserClientRepository userClientRepository)
        {
            _userClientRepository = userClientRepository ?? throw new ArgumentNullException(nameof(userClientRepository));
        }
        public async Task<string> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            var (isSuccesful, user) = await _userClientRepository.Login(request.username, request.password);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }
            return await _userClientRepository.CreateToken(user);
        }
    }
}
