using DomainCommon.Model;
using Justhis.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justhis.Domain.Models
{
    /// <summary>
    /// 用户实体
    /// </summary>
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public Sex Sex { get; private set; }
        public Address Address { get; private set; }
        public DateTime CreateTime { get; private set; }    

        public User() { }
        public User(Guid id, string name, string password, string email, string phone, Sex sex, Address address, DateTime createTime) 
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            Phone = phone;
            Sex = sex;
            Address = address;
            CreateTime = createTime;
        }

    }
}
