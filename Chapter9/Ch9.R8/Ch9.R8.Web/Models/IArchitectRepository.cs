using System.Collections.Generic;
using System;

namespace Ch9.R8.Web.Models
{
    public interface IArchitectRepository : IDisposable
    {
        List<Architect> GetArchitectList();
        Architect GetArchitectDetails(int id);
        void Create(Architect architect);
        void Update(Architect architect);
        void Delete(int id);
        void Save();
    }
}
