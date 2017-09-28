using System;
using System.ComponentModel.DataAnnotations; //[Key] 需要
namespace mvcDemo.Base
{
    
    public class BaseModel
    {
        [Key]
        public string FID{get;set;}
    }
}