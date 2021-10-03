using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA
{
    public interface IRoleService
    {
        Task<Role> SaveAsync(Role entity);
        Task<Role> UpdateAsync(Role entity);
        Task DeleteAsync(int id);
        Task<Role> FindByIdAsync(int id);
        Task<IEnumerable<Role>> GetAsyc();
      
    }
}
