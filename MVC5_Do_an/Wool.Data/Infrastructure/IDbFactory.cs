﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wool.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        WoolEntities Init();
    }
}
