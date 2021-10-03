using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

using Microsoft.AspNetCore.Http;
using AutoMapper;

using System.IO;
using BA;

namespace WebAPI.Controllers
{


    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;
        private readonly IMapper Mapper;

        public UserController(IUserService customerService, IMapper mapper)
        {
            UserService = customerService;
            Mapper = mapper;
        }

        #region  User
        [HttpPost]

        public async Task SaveUserAsync([FromBody] UserInputModel model)
        {
            try
            {
                var result = await UserService.SaveAsync(Mapper.Map<User>(model));

                Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }


      
        [HttpDelete("{id:int}")]
        public async Task DeleteUserAsync(int id)
        {
            try
            {
                await UserService.DeleteAsync(id);
                Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> FindUserByIdAsync(int id)
        {
            try
            {
                var result = await UserService.FindByIdAsync(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                return Ok(await UserService.GetAsyc());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data from Database");
            }

        }


        #endregion


    }


}

