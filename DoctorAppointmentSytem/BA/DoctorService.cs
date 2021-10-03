using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA
{
   public  class DoctorService : IDoctorService
    {
        private readonly AppDbContext _appDbContext;
   

        public DoctorService(AppDbContext appDbContext )
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
            }

        public async Task<Doctor> SaveAsync(Doctor entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));

                ApplyValidationBl(entity);

                var result = await _appDbContext.Doctors.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Doctor> UpdateAsync(Doctor entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));
                var existingEntity = await _appDbContext.Doctors.FindAsync(entity.Id);
                if (existingEntity is null) throw new Exception("Doctor Not Found!");

                existingEntity.Name = entity.Name;
                ApplyDoctorIdBl(existingEntity);
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

                var result = _appDbContext.Doctors.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    _appDbContext.Doctors.Remove(result);
                    await _appDbContext.SaveChangesAsync();
                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<Doctor> FindByIdAsync(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentNullException(nameof(id));

                var result = await _appDbContext.Doctors.FirstOrDefaultAsync(c => c.Id == id);
                if (result == null)
                {
                    throw new Exception($"Doctor not Found with id= {id}");
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Doctor>> GetAsyc()
        {
            try
            {
                return await _appDbContext.Doctors.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }



        #region Business Logic

        private void ApplyValidationBl(Doctor entity)
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

        private void ApplyDoctorIdBl(Doctor entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));

                if (entity.Id <= 0) throw new Exception("Invalid Doctor");
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
