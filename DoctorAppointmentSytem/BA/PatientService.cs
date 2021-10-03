using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA
{
   public  class PatientService : IPatientService
    {
        private readonly AppDbContext _appDbContext;
   

        public PatientService(AppDbContext appDbContext )
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
            }

        public async Task<Patient> SaveAsync(Patient entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));

                ApplyValidationBl(entity);

                var result = await _appDbContext.Patients.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Patient> UpdateAsync(Patient entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));
                var existingEntity = await _appDbContext.Patients.FindAsync(entity.Id);
                if (existingEntity is null) throw new Exception("Patient Not Found!");

                existingEntity.Name = entity.Name;
                ApplyPatientIdBl(existingEntity);
                ApplyValidationBl(existingEntity);

                var result = await _appDbContext.SaveChangesAsync();
                return entity;



            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentNullException(nameof(id));

                var result = _appDbContext.Patients.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    _appDbContext.Patients.Remove(result);
                    await _appDbContext.SaveChangesAsync();
                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<Patient> FindByIdAsync(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentNullException(nameof(id));

                var result = await _appDbContext.Patients.FirstOrDefaultAsync(c => c.Id == id);
                if (result == null)
                {
                    throw new Exception($"Patient not Found with id= {id}");
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Patient>> GetAsyc()
        {
            try
            {
                return await _appDbContext.Patients.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }



        #region Business Logic

        private void ApplyValidationBl(Patient entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));
              
                entity.Name = string.IsNullOrWhiteSpace(entity.Name) ? throw new Exception("Name is Required") : entity.Name.Trim();
              
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ApplyPatientIdBl(Patient entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));

                if (entity.Id <= 0) throw new Exception("Invalid Patient");
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
