using Justhis.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justhis.Infrastruct.DBContext
{
    public class UserDBContext  : DbContext
    {
        public DbSet<User> Users { get; set; }

    }
}
