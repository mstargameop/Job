﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Areas.JobArea.Models
{
    [MetadataType(typeof(JobMetadata))]
    public partial class Job
    {
        public class JobMetadata
        {
        public int JobID { get; set; }
        [DisplayName("工作名稱")]
        [Required(ErrorMessage = "工作名稱不可為白")]
        public string JobName { get; set; }
        [DisplayName("公司編號")]
        public Nullable<int> CompanyID { get; set; }
        [DisplayName("可上班日")]
        [DataType(DataType.Date)]
        public Nullable<System.TimeSpan> JobStartTime { get; set; }
        [DisplayName("工作時段")]
        public Nullable<System.TimeSpan> TimeID { get; set; }
        [DisplayName("時薪")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> PayPerHour { get; set; }
        [DisplayName("工作描述")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "工作描述不可為白")]
        public string Description { get; set; }
        [DisplayName("上班地點")]
        [Required(ErrorMessage = "上班地點不可為白")]
         public string Workplace { get; set; }

        }

    }
}