using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoTweak.Data.Infrastructure
{
public class DatabaseFactory : Disposable, IDatabaseFactory
{
    private TweakContext dataContext;
    public TweakContext Get()
    {
        return dataContext ?? (dataContext = new TweakContext());
    }
    protected override void DisposeCore()
    {
        if (dataContext != null)
            dataContext.Dispose();
    }
}
}
