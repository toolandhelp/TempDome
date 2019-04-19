using System;
using System.Collections.Generic;
using System.Text;
using Tool.Calendar.IRepository;
using Tool.Calendar.IServices;
using Tool.Calendar.Models.Models;
using Tool.Calendar.Services.Base;

namespace Tool.Calendar.Services
{
    public class T_WebUserService:BaseServices<T_WebUser>,IT_WebUserService
    {
        IT_WebUserRepository dal;
        public T_WebUserService(IT_WebUserRepository dal)
        {

        }
    }
}
