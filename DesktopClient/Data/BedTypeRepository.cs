using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public class BedTypeRepository : Repository<BedType>
    {
        public BedTypeRepository() : base("bedType")
        {
        }
    }
}
