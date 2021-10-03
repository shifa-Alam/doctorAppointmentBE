using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA
{
    public interface IPatientService
    {
        Task<Patient> SaveAsync(Patient entity);
        Task<Patient> UpdateAsync(Patient entity);
        Task DeleteAsync(int id);
        Task<Patient> FindByIdAsync(int id);
        Task<IEnumerable<Patient>> GetAsyc();
      
    }
}
