using ShopChain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopChain.Core.Interfaces
{
    public interface IUserClientRepository
    {
        Task<string> CreateToken(UserClient user);
        Task<(bool IsSuccessful, UserClient? User)> Login(string username, string password);
    }
}
