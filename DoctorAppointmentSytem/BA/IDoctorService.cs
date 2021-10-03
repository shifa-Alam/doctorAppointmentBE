using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA
{
    public interface IDoctorService
    {
        Task<Doctor> SaveAsync(Doctor entity);
        Task<Doctor> UpdateAsync(Doctor entity);
        Task DeleteAsync(int id);
        Task<Doctor> FindByIdAsync(int id);
        Task<IEnumerable<Doctor>> GetAsyc();
      
    }
}
