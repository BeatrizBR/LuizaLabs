using DesafioLuizaLabs.Models;
using LuizaLabsDesafio.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LuizaLabsDesafio.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet()]
        public ActionResult<List<UserModel>> GetAllUsers()
        {
            List<UserModel> users = _userRepository.GetAllUsers();

            if (users.IsNullOrEmpty())
            {
                return NoContent();
            }
            return Ok(users);
        }

        [HttpPost()]
        [Route("login")]
        public ActionResult<UserModel> Login([FromBody] UserModel user)
        {
            UserModel existentUser;

            try
            {
                existentUser = _userRepository.Login(user);
                Response.Redirect("/login/login");
                Console.WriteLine(user);
                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest($"User not signed " + ex.Message);
            }
            
        }

        [HttpGet()]
        [Route("{id}")]
        public ActionResult<UserModel> GetById(int id)
        {
            UserModel user;
            try
            {
                user = _userRepository.GetUserById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"User with id {id} not found" + ex.Message);
            }

        }

        [HttpPost()]
        [Route("signin")]
        public ActionResult<UserModel> PostUser([FromBody] UserModel newUser)
        {
            _userRepository.AddUser(newUser);
            return Ok(newUser);
        }

        [HttpPost()]
        [Route("changepassword")]
        public ActionResult<UserModel> UpdateUser([FromBody] UserModel updatedUser)
        {
            _userRepository.UpdatePassword(updatedUser, updatedUser.id);
            return Ok(updatedUser);
        }

        [HttpDelete()]
        [Route("delete")]
        public ActionResult DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
            return Ok();
        }
    }
}
