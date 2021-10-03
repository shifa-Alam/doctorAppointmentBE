using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;
        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public async Task<User> SaveAsync(User entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));

                ApplyValidationBl(entity);

                ApplyDoctorOrPatientBl(entity);

                var result = await _appDbContext.Users.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }



        //public async Task<User> UpdateAsync(User entity)
        //{

        //    try
        //    {
        //        if (entity is null) throw new ArgumentNullException(nameof(entity));

        //        var existingEntity = await _appDbContext.Users.FindAsync(entity.Id);

        //        if (existingEntity is null) throw new Exception("User Not Found!");

        //        existingEntity.UserName = entity.UserName;
        //        existingEntity.FatherName = entity.FatherName;
        //        existingEntity.MotherName = entity.MotherName;
        //        existingEntity.CountryId = entity.CountryId;
        //        existingEntity.MaritalStatus = entity.MaritalStatus;
        //        existingEntity.UserPhoto = entity.UserPhoto;

        //        ApplyUserIdBl(existingEntity);
        //        ApplyValidationBl(existingEntity);

        //        // chain effect

        //        var result = await _appDbContext.SaveChangesAsync();
        //        return entity;



        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}



        public async Task DeleteAsync(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentNullException(nameof(id));

                var result = _appDbContext.Users.FirstOrDefault(c => c.Id == id);

                _appDbContext.Users.Remove(result);
                await _appDbContext.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<User> FindByIdAsync(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentNullException(nameof(id));

                var result = await _appDbContext.Users.FirstOrDefaultAsync(c => c.Id == id);
                if (result == null)
                {
                    throw new Exception($"User not Found with id= {id}");
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAsyc()
        {
            try
            {
                return await _appDbContext.Users.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }


        #region Business Logic

        private void ApplyValidationBl(User entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));
                if (entity.RoleId <= 0) throw new Exception("Role Required");
                entity.Name = string.IsNullOrWhiteSpace(entity.Name) ? throw new Exception("Name is Required") : entity.Name.Trim();
                entity.UserName = string.IsNullOrWhiteSpace(entity.UserName) ? throw new Exception("User Name is Required") : entity.UserName.Trim();
                entity.Email = string.IsNullOrWhiteSpace(entity.Email) ? throw new Exception("Email is Required") : entity.Email.Trim();
                entity.Phone = string.IsNullOrWhiteSpace(entity.Phone) ? string.Empty : entity.Phone.Trim();
                entity.Password = string.IsNullOrWhiteSpace(entity.Password) ? throw new Exception("Password is Required") : entity.Password.Trim();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ApplyUserIdBl(User entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));

                if (entity.Id <= 0) throw new Exception("Invalid User");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ApplyDoctorOrPatientBl(User entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));

                if (entity.RoleId == (long)RoleEnum.Doctor)
                {
                    Doctor doctor = new Doctor
                    {
                        Name = entity.Name,
                        Email = entity.Email,
                        Phone = entity.Phone,
                    };

                    _appDbContext.Doctors.AddAsync(doctor);
                }
                else if (entity.RoleId == (long)RoleEnum.Patient)
                {
                    Patient patient = new Patient
                    {
                        Name = entity.Name,
                        Email = entity.Email,
                        Phone = entity.Phone,
                    };
                    _appDbContext.Patients.AddAsync(patient);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
