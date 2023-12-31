﻿using Hackathon.Models;

namespace Hackathon.Services
{
    public interface IUserService
    {
        bool IsExists(string email);
        User GetItemWithAccount(string email);
        User GetItem(string email);
        User GetItemById(int id);
        bool UserExistsInOrganization(int idOrganization, string email);
    }
}
