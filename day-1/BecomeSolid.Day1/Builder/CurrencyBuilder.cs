using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day1.Builder
{
    public class CurrencyBuilder: IMessageBuilder<CurrencyEntity>
    {
        public string Build(CurrencyEntity entity)
        {
            var message = "For " + entity.Name + " exchange is " + entity.Currency;
            return message;
        }
    }
}
