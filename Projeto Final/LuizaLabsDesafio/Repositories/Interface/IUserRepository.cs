using DesafioLuizaLabs.Models;

namespace LuizaLabsDesafio.Repositories.Interface
{
    public interface IUserRepository
    {
        List<UserModel> GetAllUsers();

        UserModel GetUserById(int id);

        UserModel AddUser(UserModel user);

        UserModel Login(UserModel user);

        UserModel UpdatePassword(UserModel user, int id);

        bool DeleteUser(int id);
    }
}
