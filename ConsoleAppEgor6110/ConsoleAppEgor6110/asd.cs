using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEgor6110;

class asd
{
    public static int Fibo(int n) // Рекурсивный
    {
        if (n < 3) return 1;
        return Fibo(n - 1) + Fibo(n - 2);
    }
    public static int Fibo2(int n) // Нерекурсивный
    {
        if (n < 3) return 1;
        int a, b, c = 0;
        a = 1; b = 1;
        for (int i = 3; i <= n; i++)
        {
            c = a + b;
            b = a;
            a = c;
        }
        return c;
    }
    public static string convert(int n, int d) // Конвертер
    {
        string N = "0123456789ABCDF";
        string r = "";
        while (n > 0)
        {
            int oct = n % d;
            if (oct < N.Length)
            {
                r = N[oct] + r;
            }
            else
            {
                // обработка ошибки, например, выброс исключения
            }
            n /= d;
        }
        return r;
    }
    public delegate double Func(double x); // Корни
    public static double korenpd(double left, double right, Func fun, double Epsilon = 0.001)
    {
        double fl = fun(left);
        double fr = fun(right);
        if (fr * fl > 0) return double.NaN;

        while (right - left > Epsilon)
        {
            double c = (left + right) * 0.5;
            double fc = fun(c);
            if (fl * fc < 0) right = c;
            else
            {
                left = c;
                fl = fc;
            }
        }
        return (left + right) * 0.5;
    }
}