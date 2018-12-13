using My_Cookbook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace My_Cookbook.ViewModels
{
    public class UsersViewModel
    {
        public List<string> UsersList { get; set; }

        public UsersViewModel(List<string> userList)
        {
            UsersList = userList;
            
        }
    }
}