using Pharmacy_Management1.Models;

using System.Collections.Generic;

namespace Pharmacy_Management1.Repository
{
    public interface IUserRepository
    {
        UserDetail Create(UserDetail user);
        IEnumerable<UserDetail> GetAll();
        UserDetail GetByEmail(string email);
        UserDetail GetById(int id);
    }
}