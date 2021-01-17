using System;
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

        // Перечисление для упрощение восприятия формул, с использование значений из таблицы коэффициентов.
        private enum Coef
        {
            a = 0,
            b,
            c,
            d
        }

        // Типы проекта.
        public enum ProjectType
        {
            Органический = 0,
            Полуразделенный,
            Встроенный
        }

        // Трудоемкость.
        static public double GetLaboriousness(int codeSize, ProjectType type)
        {
            return modelTable[(int)type][(int)Coef.a] *
                Math.Pow(codeSize, modelTable[(int)type][(int)Coef.b]);
        }

        // Время разработки в месяцах.
        static public double GetDevelopmentTime(int codeSize, ProjectType type)
        {
            return modelTable[(int)type][(int)Coef.c] *
                Math.Pow(GetLaboriousness(codeSize, type), modelTable[(int)type][(int)Coef.d]);
        }

        // Среднее количество персонала.
        static public double GetNumberStaff(int codeSize, ProjectType type)
        {
            return GetLaboriousness(codeSize, type) /
                GetDevelopmentTime(codeSize, type);
        }

        // Продуктивность.
        static public double GetProductivity(int codeSize, ProjectType type)
        {
            return codeSize / GetLaboriousness(codeSize, type);
        }
    }
}

