using DesafioLuizaLabs.Data;
using DesafioLuizaLabs.Models;
using DesafioLuizaLabs.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;

namespace DesafioLuizaLabs.Repositories
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
            return dbContext.Users.FirstOrDefault(user => user.id == id);
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

    }
}
