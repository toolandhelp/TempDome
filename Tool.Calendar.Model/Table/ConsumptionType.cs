using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tool.Calendar.Model
{
    /// <summary>
    /// 消费类型
    /// </summary>
    public class ConsumptionType : BaseEntity<long>
    {
        /// <summary>
        /// 消费类型名称
        /// </summary>

        [StringLength(20)]
        [Required]
        public string CTName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(500)]
        [Required]
        public string CTDescription { get; set; }
        /// <summary>
        /// Labes类名称
        /// </summary>
        [StringLength(50)]
        [Required]
        public string CTLabelClass { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Range(1,int.MaxValue)]
        public int CTSort { get; set; }
    }
}
