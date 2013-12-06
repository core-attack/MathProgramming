using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathProgramming
{
    public class Lab3
    {
        private int[] a;
        private int[] b;
        private int[,] c;

        private int k, s;
        private int[,] x;

        private Integer[] u, v;
        private int[,] h;

        public List<string> console = new List<string>();

        public Lab3(int[,] t)
        {
            a = new int[t.GetLength(0)];
            b = new int[t.GetLength(1)];
            c = new int[t.GetLength(0) - 1, t.GetLength(1) - 1];
            x = new int[t.GetLength(0) - 1, t.GetLength(1) - 1];

            for (int i = 0; i < t.GetLength(0); i++)
                for (int j = 0; j < t.GetLength(1); j++)
                {
                    if (i == t.GetLength(0) - 1 && j == t.GetLength(1) - 1)
                        continue;
                    else if (i == t.GetLength(0) - 1)
                        b[j] = t[i, j];
                    else if (j == t.GetLength(1) - 1)
                        a[i] = t[i, j];
                    else
                        c[i, j] = t[i, j];
                }
            s1();
        }

        private void s1()
        {
            for (int i = 0; i < c.GetLength(0); i++)
                for (int j = 0; j < c.GetLength(1); j++)
                    if (c[i, j] < c[k, s])
                    {
                        k = i;
                        s = j;
                    }

            s2();
        }

        private void s2()
        {
            x[k, s] = Math.Min(a[k], b[s]);

            s3();
        }

        private void s3()
        {
            a[k] -= x[k, s];
            b[s] -= x[k, s];

            s4();
        }

        private void s4()
        {
            if (a[k] == 0)
                s7();
            else
                s5();
        }

        private void s5()
        {
            bool f = true;
            for (int j = 0; j < b.GetLength(0); j++)
                if (b[j] != 0)
                {
                    s6();
                    f = false;
                }
            if (f)
                s11();
        }

        private void s6()
        {
            int jmin = 0;
            int jminval = int.MaxValue;
            for (int j = 0; j < b.GetLength(0); j++)
                if (b[j] > 0 && c[k, j] < jminval)
                {
                    jmin = j;
                    jminval = c[k, j];
                }

            s = jmin;

            s2();
        }

        private void s7()
        {
            bool f = true;
            for (int i = 0; i < a.GetLength(0); i++)
                if (a[i] != 0)
                {
                    s8();
                    f = false;
                }
            if (f)
                s11();
        }

        private void s8()
        {
            int imin = 0;
            int iminval = int.MaxValue;
            for (int i = 0; i < a.GetLength(0); i++)
                if (a[i] > 0 && c[i, s] < iminval)
                {
                    imin = i;
                    iminval = c[i, s];
                }

            k = imin;

            s2();
        }

        private void s11()
        {
            u = new Integer[x.GetLength(0)];
            v = new Integer[x.GetLength(1)];

            List<int> p = new List<int>();
            u[0] = new Integer(0);
            for (int i = 0; i < x.GetLength(0); i++)
            {
                bool cq = false;
                if (u[i] == null)
                    for (int j = 0; j < x.GetLength(1); j++)
                    {
                        if (x[i, j] != 0 && v[j] != null)
                        {
                            u[i] = new Integer(c[i, j] - v[j].getValue());
                            goto a;
                        }
                    }
                if (u[i] == null)
                {
                    p.Add(i);
                    cq = true;
                }
            a:
                if (cq)
                    continue;
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    if (x[i, j] != 0 && v[j] == null)
                    {
                        v[j] = new Integer(c[i, j] - u[i].getValue());
                    }
                }
            }
            foreach (int i in p)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    if (x[i, j] != 0 && v[j] != null)
                    {
                        u[i] = new Integer(c[i, j] - v[j].getValue());
                        break;
                    }
                }
                if (u[i] == null)
                    u[i] = new Integer(0);
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    if (x[i, j] != 0 && v[j] == null)
                    {
                        v[j] = new Integer(c[i, j] - u[i].getValue());
                    }
                }
            }

            s13();
        }

        private void s13()
        {
            h = new int[x.GetLength(0), x.GetLength(1)];

            for (int i = 0; i < h.GetLength(0); i++)
            {
                for (int j = 0; j < h.GetLength(1); j++)
                {
                    h[i, j] = c[i, j] - new Integer(u[i].getValue() + v[j].getValue()).getValue();
                }
            }

            s14();
        }

        private void s14()
        {
            bool br = false;
            for (int i = 0; i < h.GetLength(0); i++)
            {
                if (br)
                    break;
                for (int j = 0; j < h.GetLength(1); j++)
                {
                    if (h[i, j] < 0)
                    {
                        s15();
                        br = true;
                        break;
                    }
                }
            }
            printResult();
        }

        private void s15()
        {
            printResult();

            int mi = 0, mj = 0;
            for (int i = 0; i < h.GetLength(0); i++)
                for (int j = 0; j < h.GetLength(1); j++)
                    if (h[i, j] < 0 && h[i, j] < h[mi, mj])
                    {
                        mi = i;
                        mj = j;
                    }

            int[,] t = new int[x.GetLength(0), x.GetLength(1)];
            for (int i = 0; i < t.GetLength(0); i++)
                for (int j = 0; j < t.GetLength(1); j++)
                    t[i, j] = x[i, j];
            t[mi, mj] = -1;

            bool d = true;
            while (d)
            {
                d = false;
                int c;
                for (int i = 0; i < t.GetLength(0); i++)
                {
                    c = 0;
                    for (int j = 0; j < t.GetLength(1); j++)
                        if (t[i, j] != 0)
                            c++;
                    if (c == 1)
                    {
                        for (int j = 0; j < t.GetLength(1); j++)
                            t[i, j] = 0;
                        d = true;
                    }
                }
                for (int j = 0; j < t.GetLength(1); j++)
                {
                    c = 0;
                    for (int i = 0; i < t.GetLength(0); i++)
                        if (t[i, j] != 0)
                            c++;
                    if (c == 1)
                    {
                        for (int i = 0; i < t.GetLength(0); i++)
                            t[i, j] = 0;
                        d = true;
                    }
                }
            }

            List<Tuple<int, int>> p = new List<Tuple<int, int>>();
            p.Add(new Tuple<int, int>(mj, mi));
            Tuple<int, int> tp = p[0];
            {
                int i = 0;
                for (; ; )
                {
                    tp = i % 2 == 0 ? findC(t, tp) : findR(t, tp);
                    if (p[0].Equals(tp) || tp == null)
                        break;
                    p.Add(tp);
                    i++;
                }
            }
            if (p.Count == 1)
                return;
            int a = 1;
            for (int i = 1; i < p.Count; i += 2)
            {
                if (x[p[i].Item2, p[i].Item1] < x[p[a].Item2, p[a].Item1])
                    a = i;
            }
            a = x[p[a].Item2, p[a].Item1];
            for (int i = 0; i < p.Count; i++)
            {
                x[p[i].Item2, p[i].Item1] += i % 2 == 0 ? a : -a;
            }

            s11();
        }

        private Tuple<int, int> findR(int[,] m, Tuple<int, int> p)
        {
            for (int i = 0; i < m.GetLength(1); i++)
                if (m[p.Item2, i] != 0 && i != p.Item1)
                    return new Tuple<int, int>(i, p.Item2);
            return null;
        }

        private Tuple<int, int> findC(int[,] m, Tuple<int, int> p)
        {
            for (int i = 0; i < m.GetLength(0); i++)
                if (m[i, p.Item1] != 0 && i != p.Item2)
                    return new Tuple<int, int>(p.Item1, i);
            return null;
        }

        public void printResult()
        {
            console.Add("");
            string str = "";
            for (int i = 0; i < v.Length; i++)
            {
                str += "\t" + v[i];
            }
            console.Add(str);
            str = "";
            console.Add("");
            for (int i = 0; i < x.GetLength(0); i++)
            {
                str += u[i] + "\t";
                for (int j = 0; j < x.GetLength(1); j++)
                    str += x[i, j] + "\t";
                //Console.WriteLine(a[i]);
                console.Add(str);
                str = "";
                console.Add("");
            }
            console.Add("");
            console.Add("f=");
            int s = 0;
            for (int i = 0; i < c.GetLength(0); i++)
                for (int j = 0; j < c.GetLength(1); j++)
                    s += c[i, j] * x[i, j];
            console[console.Count - 1] += s + "\n";
        }
    }

    public class Integer
    {
        private int value = 0;

        public Integer(int value)
        {
            this.value = value;
        }

        public int getValue()
        {
            return value;
        }

        public override string ToString()
        {
            return "" + value;
        }
    } 
}