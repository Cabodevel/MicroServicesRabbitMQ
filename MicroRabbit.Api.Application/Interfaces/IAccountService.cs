using MicroRabbit.Api.Application.Models;
using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.Api.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        void Transfer(AccountTransfer accountTransfer);
    }
}
