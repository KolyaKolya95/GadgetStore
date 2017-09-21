
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IGadgetRepository
    {
        IEnumerable<Gadget> Gadgets { get; }
        void AddGadget(Gadget gadget);
        void SaveGadget(Gadget gadget);
        void DeleteGadget(Gadget gadget);
        void SumGadgets(Gadget gadget);
    }
}
