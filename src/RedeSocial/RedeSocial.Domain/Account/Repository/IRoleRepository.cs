using System;
using System.Threading.Tasks;

namespace RedeSocial.Domain.Account.Repository
{
    public interface IRoleRepository
    {
        Role GetRoleById(Guid id);
        Role GetRolebyName(String name);
    }
}