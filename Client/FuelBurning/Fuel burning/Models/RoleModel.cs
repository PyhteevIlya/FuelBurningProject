using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fuel_burning.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserModel> Users { get; set; } = new List<UserModel>();
        
    }
}
