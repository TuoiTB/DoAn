using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface ITransaction : IDisposable
    {
        void Commit();

        void Rollback();
    }
}
