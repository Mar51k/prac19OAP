using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace pr19
{
    internal class Nomenclature
    {
        public string name;
        public int opt_sum;
        public int rozn_sum;
        public int count;

        public Nomenclature(string name, int optS, int roznS, int count)
        {
            this.name = name;
            opt_sum = optS;
            rozn_sum = roznS;
            this.count = count;
        }
        public string Print()
        {
            return $"Название товара: {name}\nОптовая цена: {opt_sum}\nРозничная цена: {rozn_sum}\nКоличество на складе: {count}\nЧистая прибыль при продаже: {rozn_sum - opt_sum}";
        }


    }
}
