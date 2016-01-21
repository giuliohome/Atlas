using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlas
{
    class Program
    {
        static void Main(string[] args)
        {
            var gens = Topos.Gen();
            foreach (Topos topos in gens)
            {

                double tot_qty = gens.Where(t => t.Equals(topos)).Sum(t => t.qty);
                Console.WriteLine(
                        topos.key1 + "," + topos.key2 + "," +
                        topos.day1.ToShortDateString() + "," + topos.day1.ToShortDateString() + "," +
                        topos.qty.ToString() + "," + topos.seq.ToString()
                    );
            }
            var map = new Map();
            var spaceFiltration = gens.Distinct(map);
            foreach (Topos topos in spaceFiltration)
            {

                double tot_qty = gens.Where(t => map.Equals(t,topos)).Sum(t => t.qty);
                string tot_qty_uom = String.Join(",", gens.Select(t => t.qty_uom).Distinct().ToArray() );
                Console.WriteLine(
                        topos.key1 + "," + topos.key2 + "," +
                        topos.day1.ToShortDateString() + "," + topos.day1.ToShortDateString() + 
                        " => tot:" + tot_qty.ToString() +  " => uom:" + tot_qty_uom.ToString()
                    );
            }
            Console.Read();
        }
    }
}
