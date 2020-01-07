using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using xUnitTestAspNetCore.Core.EntitiesCore;

namespace xUnitTestAspNetCore.Entities.Models
{
    public class User : IEntity
    {
        [Key]
        public int userId { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string userMail { get; set; }
    }
}
