using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BecomeSolid.Day1.Entity;
using BecomeSolid.Day1.Helpers;

namespace BecomeSolid.Day1.Service
{
    public class ArtIntService : IService<ArtIntEntity>
    {
        public ArtIntEntity GetInformation(string keyForInformathion)
        {
            string response = keyForInformathion.GetSecondWord(defaulValue:"My name is Ann");
            return new ArtIntEntity()
            {
                Name = response
            };
        }
    }
}
