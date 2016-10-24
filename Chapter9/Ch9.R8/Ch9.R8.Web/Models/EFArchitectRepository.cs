using System;
using System.Collections.Generic;
using System.Data;

namespace Ch9.R8.Web.Models
{
    public class EFArchitectRepository : IArchitectRepository
    {
        private ArchitectContext m_Context = new ArchitectContext();
        public List<Architect> GetArchitectList()
        {
            throw new NotImplementedException();
        }

        public Architect GetArchitectDetails(int id)
        {
            Architect architect = m_Context.Architects.Find(id);
            return architect;
        }

        public void Create(Architect architect)
        {
            throw new NotImplementedException();
        }

        public void Update(Architect architect)
        {
            m_Context.Entry(architect).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Architect architect = m_Context.Architects.Find(id);
            m_Context.Architects.Remove(architect);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (m_Context != null)
                m_Context.Dispose();
        }
    }
}