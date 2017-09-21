using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFGadgetRepository : IGadgetRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Gadget> Gadgets
        {
            get { return context.Gadgets; }
        }

        public void AddGadget(Gadget gadget)
        {
            context.Gadgets.Add(gadget);
            context.SaveChanges();
            
            int id = gadget.GadgetId;
        }

        public void DeleteGadget(Gadget gadget)
        {
            Gadget dbEntry = context.Gadgets.Find(gadget.GadgetId);
            context.Gadgets.Remove(dbEntry);
            context.SaveChanges();
        }

        public void SaveGadget(Gadget gadget)
        {
            if (gadget.GadgetId == 0)
            {
                context.Gadgets.Add(gadget);
               
            }
            else
            {
                Gadget dbEntry = context.Gadgets.Find(gadget.GadgetId);
                if (dbEntry != null)
                {
                    dbEntry.Name = gadget.Name;
                    dbEntry.Type = gadget.Type;
                }
                context.SaveChanges();
            }
        }

        public void SumGadgets(Gadget gadget)
        {
            int sum = 0;

            Gadget dbEntry = context.Gadgets.Find(gadget.GadgetId);
            if (gadget.Type == dbEntry.Type)
            {
                sum++;
            }
            else
            {
                
            } 

        }
    }
}
