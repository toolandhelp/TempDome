using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tool.Calendar.Model;
using Tool.Calendar.Service;

namespace Tool.Calendar.Service
{
    public class ConsumptionTypeService : IConsumptionTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ConsumptionTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public string test()
        {
            var repo = _unitOfWork.GetRepository<ConsumptionType>();
            repo.Insert(new ConsumptionType
            {
                CTName = "吃饭",
                CTDescription = "用于测试吃饭",
                CTLabelClass = "label-purple",
                CTSort = 1,

            });
            _unitOfWork.SaveChanges();//提交到数据库
            var result = repo.GetFirstOrDefault()?.CTDescription ?? string.Empty;
            return result;
        }
    }
}
