﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoTweak.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
