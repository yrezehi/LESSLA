﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils.Extenstions
{
    public static class MathExtenstions
    {
        public static int PercentageBetween(int number1, int number2) =>
            (number1 / number2) * 100;
    }
}
