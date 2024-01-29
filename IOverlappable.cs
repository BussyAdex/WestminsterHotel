using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestminsterHotel
{
    internal interface IOverlappable
    {
        public bool Overlaps(DateOnly dt);
    }
}
