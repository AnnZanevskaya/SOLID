﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace BecomeSolid.Day1.Commands
{
    public interface ICommand
    {

        void Execute(Update context); 
    }
}
