using IS.DZ03.Logic.Repositories;
using IS.DZ03.Logic.Repositories.Interfaces;
using IS.DZ03.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.UnitOfWork
{
    public class AutomobilskeUslugeUnitOfWork : IAutomobilskeUslugeUnitOfWork
    {
        private AutomobilskeUslugeContext context;

        public AutomobilskeUslugeUnitOfWork(AutomobilskeUslugeContext context)
        {
            this.context = context;
            Osoba = new OsobaRepository(this.context);
        }

        public IOsobaRepository Osoba
        {
            get;
            private set;
        }

        public void Dispose()
        {
            context.Dispose();
        }
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
