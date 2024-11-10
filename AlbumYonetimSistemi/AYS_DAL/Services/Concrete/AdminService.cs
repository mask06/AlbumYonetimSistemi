﻿using AYS_DAL.Entities.Concrete;
using AYS_DAL.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYS_DAL.Services.Concrete
{
    public class AdminService<TModel>:Service<TModel,Admin> where TModel : class
    {
        public AdminService()
        {
            _repository = _unitOfWork.Admins;
        }
    }
}
