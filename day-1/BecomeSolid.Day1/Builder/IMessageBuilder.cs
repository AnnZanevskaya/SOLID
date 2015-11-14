using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BecomeSolid.Day1.Entity;
using BecomeSolid.Day1.Service;

namespace BecomeSolid.Day1.Builder
{
    public interface IMessageBuilder<T> where T:IEntity
    {
        string Build(T entity);
    }
}
