using SAX.CoreLibrary.Domains.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAXTestLabs
{
    public interface IMyUnitOfWork : IUnitOfWork
    {
        IMyRepository PersonRepository();
    }
}
