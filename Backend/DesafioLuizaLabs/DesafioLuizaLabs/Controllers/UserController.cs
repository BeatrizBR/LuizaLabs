using DesafioLuizaLabs.Models;
using DesafioLuizaLabs.Repositories;
using DesafioLuizaLabs.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DesafioLuizaLabs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) 
        { 
            _userRepository = userRepository;
        }


        [HttpGet()]
        public ActionResult<List<UserModel>> GetAllUsers()
        {
            List<UserModel> users = _userRepository.GetAllUsers();
            
            if(users.IsNullOrEmpty())
                {
                return NoContent();             
                }
            return Ok(users);
        }

        [HttpGet("/{id}")]
        public ActionResult<UserModel> GetById(int id)
        {
            UserModel user;
            try
            {
                user = _userRepository.GetUserById(id);
                return Ok(user);
            }
            catch(Exception ex)
            {
                return BadRequest($"User with id {id} not found");
            }
            
        }

        [HttpPost("/signin")]
        public ActionResult<UserModel> PostUser([FromBody] UserModel newUser)
        {
            _userRepository.AddUser(newUser);
            return Ok(newUser);
        }

        [HttpPost("/changepassword")]
        public ActionResult<UserModel> UpdateUser([FromBody] UserModel updatedUser)
        {
            _userRepository.UpdatePassword(updatedUser,updatedUser.id);
            return Ok(updatedUser);
        }

        [HttpDelete("/delete")]
        public ActionResult DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
            return Ok();
        }
    }
}
