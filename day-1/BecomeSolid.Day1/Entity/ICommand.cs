﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day1
{
    public interface ICommand2
    {
        string GetInfo(WebResponse response);
        string GetInfo(string response);
    }
}