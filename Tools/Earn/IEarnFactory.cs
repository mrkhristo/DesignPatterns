﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Earn
{
    public interface IEarnFactory
    {
        public IEarn GetEarn();
    }
}
