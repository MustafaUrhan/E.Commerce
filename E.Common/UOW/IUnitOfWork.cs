using System;
using System.Collections.Generic;
using System.Text;

namespace E.Common.UOW
{
    public interface IUnitOfWork:IDisposable
    {
       int SaveChanges();
    }
}
