﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Earn
{
    public class ForeignEarnFactory : IEarnFactory
    {
        private decimal _percentage;
        private decimal _extra;

        public ForeignEarnFactory(decimal percentage, decimal extra)
        {
            _percentage = percentage;
            _extra = extra;
        }

        public IEarn GetEarn()
        {
            return new ForeignEarn(_percentage, _extra);
        }
    }
}
