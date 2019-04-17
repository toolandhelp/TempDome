using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tool.Calendar.IRepository;
using Tool.Calendar.IServices;
using Tool.Calendar.Models.Models;

namespace Tool.Calendar.Api.Controllers
{
    /// <summary>
    /// 消费类型控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumptionTypeController : ControllerBase
    {
        private readonly IT_ConsumptionTypeService consumptionTypeService;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="consumptionType"></param>
        public ConsumptionTypeController(IT_ConsumptionTypeService consumptionType)
        {
            this.consumptionTypeService = consumptionType;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value"+id;
        }
        /// <summary>
        ///初始化消费类型数据
        /// </summary>
        /// <returns></returns>
        [Route("InitConType")]
        [HttpGet]
        public async Task<IActionResult> InitConsumptionType()
        {
            try
            {
                T_ConsumptionType t_ConsumptionType = new T_ConsumptionType();

                t_ConsumptionType.ConsumptionTypeName = "早餐";
                t_ConsumptionType.ConsumptionTypeCreateDate = DateTime.Now;
                t_ConsumptionType.ConsumptionTypeGuid = Guid.NewGuid();
                t_ConsumptionType.ConsumptionTypeClass = "labal";

                bool flag = await consumptionTypeService.Add(t_ConsumptionType);



                return Ok(new
                {
                    syccess = flag,
                    message = "加入"
                });
            }
            catch (Exception ex)
            {

                return Ok(new
                {
                    syccess = false,
                    message = ex.Message
                });
            }
        }

        /// <summary>
        /// post
        /// </summary>
        /// <param name="ConsumptionType">model实体参数</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostConsumptionType([FromBody]T_ConsumptionType ConsumptionType)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                bool flag = false;

                ConsumptionType.ConsumptionTypeCreateDate = DateTime.Now;
                ConsumptionType.ConsumptionTypeGuid = Guid.NewGuid();
                flag = await consumptionTypeService.Add(ConsumptionType);

                return Ok(new
                {
                    success = flag,
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
