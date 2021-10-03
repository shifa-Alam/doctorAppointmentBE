using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA
{
    public interface IUserService
    {
        Task<User> SaveAsync(User entity);
        //Task<User> UpdateAsync(User entity);
        Task DeleteAsync(int id);
        Task<User> FindByIdAsync(int id);
        Task<IEnumerable<User>> GetAsyc();
      
    }
}
