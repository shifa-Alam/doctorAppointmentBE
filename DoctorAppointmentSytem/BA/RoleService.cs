using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA
{
   public  class RoleService : IRoleService
    {
        private readonly AppDbContext _appDbContext;
   

        public RoleService(AppDbContext appDbContext )
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
            }

        public async Task<Role> SaveAsync(Role entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));

                ApplyValidationBl(entity);

                var result = await _appDbContext.Roles.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Role> UpdateAsync(Role entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));
                var existingEntity = await _appDbContext.Roles.FindAsync(entity.Id);
                if (existingEntity is null) throw new Exception("Role Not Found!");

                existingEntity.Name = entity.Name;
                ApplyRoleIdBl(existingEntity);
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

                var result = _appDbContext.Roles.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    _appDbContext.Roles.Remove(result);
                    await _appDbContext.SaveChangesAsync();
                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<Role> FindByIdAsync(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentNullException(nameof(id));

                var result = await _appDbContext.Roles.FirstOrDefaultAsync(c => c.Id == id);
                if (result == null)
                {
                    throw new Exception($"Role not Found with id= {id}");
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Role>> GetAsyc()
        {
            try
            {
                return await _appDbContext.Roles.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }



        #region Business Logic

        private void ApplyValidationBl(Role entity)
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

        private void ApplyRoleIdBl(Role entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));

                if (entity.Id <= 0) throw new Exception("Invalid Role");
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
