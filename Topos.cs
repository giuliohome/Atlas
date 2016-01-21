using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlas
{
    public class Topos
    {
        public string key1;
        public string key2;
        public DateTime day1;
        public DateTime day2;
        public double qty;
        public string qty_uom;
        public int seq;

        public static IEnumerable<Topos> Gen()
        {
            return new Topos[] {
                 new Topos(){ key1 ="a", key2="b", day1=DateTime.Now.Date.AddDays(-1), day2=DateTime.Now.Date, qty=100, seq=1, qty_uom="MT"  },
                 new Topos(){ key1 ="c", key2="d", day1=DateTime.Now.Date.AddDays(-1), day2=DateTime.Now.Date, qty=100, seq=1, qty_uom="BBL"  },
                 new Topos(){ key1 ="a", key2="b", day1=DateTime.Now.Date.AddDays(-2), day2=DateTime.Now.Date, qty=150, seq=2, qty_uom="BBL"  },
                 new Topos(){ key1 ="a", key2="b", day1=DateTime.Now.Date.AddDays(-1), day2=DateTime.Now.Date, qty=150, seq=2, qty_uom="BBL"  },
                 new Topos(){ key1 ="c", key2="d", day1=DateTime.Now.Date.AddDays(-1), day2=DateTime.Now.Date, qty=150, seq=2, qty_uom="MT"   }
            };
        }

    }
    
	public static class Cohomology {
		public static bool NullEquals(this object x, object y) {
			if (x != null && y == null) {
				return false;
			}
			if (x == null && y != null) {
				return false;
			}
			if (x == null && y == null) {
				return true;
			}
			return x.Equals(y);
		}
		public static int GetHashFiber(this object obj)
		{
			if (obj == null) {
				return 0;
			}
			return obj.GetHashCode();
		}
	}
    
    public class Map : IEqualityComparer<Topos>
    {

        public bool Equals(Topos x, Topos y)
        {
            if (!x.key1.NullEquals(y.key1))
            {
                return false;
            }
            if (!x.key2.NullEquals(y.key2))
            {
                return false;
            }
            if (!x.day1.NullEquals(y.day1))
            {
                return false;
            }
            if (!x.day2.NullEquals(y.day2))
            {
                return false;
            }
            return true;
        }

        public int GetHashCode(Topos obj)
        {
            return obj.key1.GetHashFiber() ^ obj.key2.GetHashFiber() ^
                    obj.day1.GetHashFiber() ^ obj.day2 .GetHashFiber();
        }
    } 
}
