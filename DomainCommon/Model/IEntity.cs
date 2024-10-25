using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCommon.Model
{
    public interface IEntity
    {
        /// <summary>
        /// Entity唯一标识
        /// </summary>
        public Guid Id { get; }
    }
}
