using Case.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case.Etity.Model
{
    public class User : BaseModel 
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }

    public class Content : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
