using System;
using System.Collections.Generic;
using System.Text;
using Tool.Calendar.IRepository;
using Tool.Calendar.IServices;
using Tool.Calendar.Models.Models;
using Tool.Calendar.Services.Base;

namespace Tool.Calendar.Services
{
    public class T_ConsumptionTypeService : BaseServices<T_ConsumptionType>, IT_ConsumptionTypeIService
    {
        readonly IT_ConsumptionTypeRepository dal;
        public T_ConsumptionTypeService(IT_ConsumptionTypeRepository dal)
        {

        }
    }
}
