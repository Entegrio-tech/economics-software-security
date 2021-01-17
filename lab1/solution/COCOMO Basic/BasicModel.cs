using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COCOMO_Basic
{
    class BasicModel
    {
        //Таблица коефицывфентов.
        static double[][] modelTable = new double[3][];
        static BasicModel()
        {
            modelTable[0] = new[] { 2.4, 1.05, 2.5, 0.38 };
            modelTable[1] = new[] { 3, 1.12, 2.5, 0.35 };
            modelTable[2] = new[] { 3.6, 1.2, 2.5, 0.32 };
        }
    }
}
