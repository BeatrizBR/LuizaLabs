using DesafioLuizaLabs.Models;
using LuizaLabsDesafio.Data;
using LuizaLabsDesafio.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;

namespace LuizaLabsDesafio.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserSystemContext dbContext;


        public UserRepository(UserSystemContext systemContext)
        {
            dbContext = systemContext;
        }
        public List<UserModel> GetAllUsers()
        {
            return dbContext.Users.ToList();
        }

        public UserModel GetUserById(int id)
        {
            UserModel? user = dbContext.Users.FirstOrDefault(user => user.id == id);
            return user;
        }

        public UserModel AddUser(UserModel user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return user;
        }

        public bool DeleteUser(int id)
        {
            UserModel user = GetUserById(id);

            if (user == null)
            {
                throw new Exception($"User with id {id} not found");
            }

            dbContext.Users.Remove(user);
            dbContext.SaveChanges();

            return true;
        }


        public UserModel UpdatePassword(UserModel user, int id)
        {
            UserModel updatedUser = GetUserById(id);

            if (updatedUser == null)
            {
                throw new Exception($"User with id {id} not found");
            }

            updatedUser._password = user._password;
            dbContext.Users.Update(updatedUser);
            dbContext.SaveChanges();
            return user;
        }

        public UserModel Login(UserModel user)
        {
            UserModel? userLogin = dbContext.Users.FirstOrDefault(ExistentUser => user.username == ExistentUser.username & user._password == ExistentUser._password);
            if (userLogin == null)
            {
                throw new Exception("User not signed!");
            }
            return user;
        }
    }
}
