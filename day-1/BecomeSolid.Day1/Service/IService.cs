using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BecomeSolid.Day1.Entity;

namespace BecomeSolid.Day1.Service
{
    interface IService<T> where T: IEntity
    {
        T GetInformation(string keyForInformathion);
    }
}
