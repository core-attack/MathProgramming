using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MathProgramming
{
    public partial class GeneralForm : Form
    {
        System.Globalization.NumberFormatInfo format;
        /*
         * Сборка 1.0 Вычисление жордановыми исключениями 
         * Сборка 1.1 Решение систем линейных уравнений
         * лог со всеми действиями пользователя
         * повторное нажатие на кнопку "вычислить" перемещает матрицу из вывода во ввод, вычисляет и записывает во вывод
         * при нажатии на любую клавишу цифры печатается пробел после неё (отключаемое свойство)
         * Сборка 1.2 Симплекс метод
         * запись лога не ведется, поскольку все необходимые вычисления выводятся в окно вывода
         * Сборка 1.3 Транспортная задача
         * запись лога не ведется, поскольку все необходимые вычисления выводятся в окно вывода
         */
        public GeneralForm()
        {
            InitializeComponent();
            
            textBoxK.Text = "1";
            textBoxS.Text = "4";
            string[] labs = {"Жордановы исключения", "Симплекс метод", "Транспортная задача"};
            foreach (string s in labs)
                comboBoxLab.Items.Add(s);
            comboBoxLab.SelectedIndex = 1;
            
        }
        List<string> log = new List<string>();
        List<string> x = new List<string>();
        List<string> y = new List<string>();
        List<string> columnX = new List<string>();
        List<string> lineX = new List<string>();
        string RESULT = "";
        //меняет элемент под индексом ind1 в l1 и элемент под индексом ind2 в l2 местами
        void reverse(List<string> l1, List<string> l2, int ind1, int ind2)
        {
            string s = l1[ind1];
            l1[ind1] = l2[ind2];
            l2[ind2] = s;
        }

        bool isError(List<string> lline, List<string> lcolumn, List<List<double>> matrix)
        {
            for (int i = 0; i < matrix.Count; i++)
            {
                if (matrix[i][0] != 0)
                    return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                format = new System.Globalization.NumberFormatInfo();
                format.NumberDecimalSeparator = ",";
                switch (comboBoxLab.SelectedIndex)
                {
                    case 0://жордановы исключения
                        {
                            if (richTextBoxOutput.Text == "")
                            {

                                List<List<double>> matrix = readMatrixList(richTextBoxInput);
                                int k = Convert.ToInt32(textBoxK.Text);
                                int s = Convert.ToInt32(textBoxS.Text);
                                double[,] outMatrix = new double[0, 0];
                                if (matrix[k][s] != 0)
                                {
                                    outMatrix = calc(matrix, k, s);
                                    if (lineX.Count == 0)
                                        for (int i = 0; i < matrix[0].Count; i++)
                                            if (i == 0)
                                                lineX.Add("1");
                                            else
                                                lineX.Add("x" + i.ToString());
                                    if (columnX.Count == 0)
                                        for (int i = 0; i < matrix.Count; i++)
                                            columnX.Add("0");
                                    reverse(columnX, lineX, k, s);
                                }
                                else
                                    MessageBox.Show("Матрица не совместна. \na[k, s] == " + matrix[k][s].ToString(), "Будет деление на ноль!");
                                //вывод матрицы
                                writeMatrix(outMatrix, richTextBoxOutput);
                                RESULT = outResult(lineX, columnX, matrix);
                                if (isError(lineX, columnX, matrix))//FIXME
                                    MessageBox.Show("Матрица не совместна");
                            }
                            else
                            {
                                List<List<double>> matrix = readMatrixList(richTextBoxOutput);
                                richTextBoxInput.Text = richTextBoxOutput.Text = "";
                                writeMatrix(matrix, richTextBoxInput);
                                int k = Convert.ToInt32(textBoxK.Text);
                                int s = Convert.ToInt32(textBoxS.Text);
                                log.Add("k = " + k.ToString());
                                log.Add("s = " + s.ToString());
                                string st = x[s];
                                x[s] = y[k];
                                y[k] = st;
                                double[,] outMatrix = new double[0, 0];
                                if (matrix[k][s] != 0)
                                {
                                    outMatrix = calc(matrix, k, s);
                                    if (lineX.Count == 0)
                                        for (int i = 0; i < matrix[0].Count; i++)
                                            if (i == 0)
                                                lineX.Add("1");
                                            else
                                                lineX.Add("x" + i.ToString());
                                    if (columnX.Count == 0)
                                        for (int i = 0; i < matrix.Count; i++)
                                            columnX.Add("0");
                                    reverse(columnX, lineX, k, s);
                                }
                                else
                                    MessageBox.Show("a[k, s] == " + matrix[k][s].ToString(), "Будет деление на ноль!");
                                //вывод матрицы
                                writeMatrix(outMatrix, richTextBoxOutput);
                                RESULT = outResult(lineX, columnX, matrix);
                                if (isError(lineX, columnX, matrix))//FIXME
                                    MessageBox.Show("Матрица не совместна");
                            }
                        }
                        break;
                    case 1://симплекс метод
                        {
                            if (richTextBoxOutput.Text == "")
                            {
                                double[,] matrix = readMatrixDouble(richTextBoxInput);
                                int k = Convert.ToInt32(textBoxK.Text);
                                int s = Convert.ToInt32(textBoxS.Text);
                                console.Clear();
                                simplex(matrix);
                                printResult();
                                foreach (string str in console)
                                    richTextBoxOutput.Text += str + "\n"; 
                            }
                            else
                            {
                                double[,] matrix = readMatrixDouble(richTextBoxOutput);
                                richTextBoxInput.Text = richTextBoxOutput.Text = "";
                                writeMatrix(matrix, richTextBoxInput);
                                int k = Convert.ToInt32(textBoxK.Text);
                                int s = Convert.ToInt32(textBoxS.Text);
                                console.Clear();
                                simplex(matrix);
                                printResult();
                                foreach (string str in console)
                                    richTextBoxOutput.Text += str + "\n";
                            }

                        }
                        break;
                    case 2://транспортная задача
                        {
                            int[,] matrix = readMatrix(richTextBoxInput);
                            Lab3 l3 = new Lab3(matrix);
                            l3.printResult();
                            foreach (string str in l3.console)
                                richTextBoxOutput.Text += str + "\n";
                            RESULT = l3.console[l3.console.Count - 1];
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }
        //симплекс метод
        String[] r, c;
        double[,] m;
        void simplex(/*List<List<double>>*/double[,] matrix)
        {
            m = new double[matrix.GetLength(0) + 1, matrix.GetLength(1)];
            r = new String[matrix.GetLength(0) + 1];
            for (int i = 0; i < r.GetLength(0) - 2; i++)
                r[i] = "x" + (i + matrix.GetLength(1));
            r[r.GetLength(0) - 2] = "f";
            r[r.GetLength(0) - 1] = "g";
            c = new String[matrix.GetLength(1)];
            c[0] = "1";
            for (int i = 1; i < c.GetLength(0); i++)
                c[i] = "x" + i;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, 0] < 0)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        this.m[i, j] = -matrix[i, j];
                }
                else
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        this.m[i, j] = matrix[i, j];
                }
            }
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                this.m[matrix.GetLength(0), i] = 0;
                for (int j = 0; j < matrix.GetLength(0) - 1; j++)
                {
                    this.m[matrix.GetLength(0), i] = this.m[matrix.GetLength(0), i] - matrix[j, i];
                }
            }

            s2();

            /*double[,] resultArr = new double[matrix.Count, matrix[0].Count];
            string[] line = new string[matrix[0].Count];
            string[] column = new string[matrix.Count - 1];
            for (int i = 0; i < matrix[0].Count; i++)
                if (i == 0)
                    line[i] = "1";
                else
                    line[i] = "x" + i.ToString();
            for (int i = 0; i < matrix.Count - 1; i++)
                column[i] = "x" + (matrix[0].Count + i).ToString();
            bool ok = true;
            bool NOT_RESULT = false; //задача неразрешима
            List<double> C = new List<double>();
            List<double> Cs = new List<double>();//С'
            for (int j = 0; j < matrix[matrix.Count - 1].Count; j++)
                C.Add(matrix[matrix.Count - 1][j]);
            //шаг 1
            for (int i = 1; i < matrix.Count; i++)
            {
                if (matrix[i][0] < 0)
                    ok = false;
            }
            if (ok)
            {
                double c = 0;
                for (int j = 0; j < matrix[0].Count; j++)
                {
                    for (int i = 0; i < matrix.Count - 1; i++)
                    {
                        c += matrix[i][j];
                    }
                    Cs.Add(-c);
                    c = 0;
                }

                while (repeat(C, Cs))/*до тех пор, пока существуют отрицательные элементы g строки и пока над нулями в g строке стоят отрицательные числа*/
/*                {
                    //все ли элементы массива положительны?
                    if (allElementsIs(Cs.ToArray()).Equals("положительны"))//шаг 2
                    {
                        //шаг 7
                        List<int> nulElementsIndex = new List<int>();
                        for (int j = 0; j < Cs.Count; j++)
                        {
                            if (Cs[j] == 0)//сделать Math.Abs(C'[j]) < Eps
                                nulElementsIndex.Add(j);
                        }
                        if (allElementsIs(Cs.ToArray()).Equals("нулевые") && allElementsIs(C.ToArray()).Equals("неотрицательны"))
                        {
                            if (true/*все искуственные переменные = 0)*/
/*                               MessageBox.Show("План оптимален");
                            else
                            {
                                MessageBox.Show("Задача неразрешима!");
                                NOT_RESULT = true;
                            }
                        }
                        //шаг8
                        double maxElement = 0;
                        int maxElementIndex = 0;
                        for (int j = 0; j < nulElementsIndex.Count; j++)
                        {
                            if (Cs[nulElementsIndex[j]] < 0)
                            {
                                if (Math.Abs(Cs[nulElementsIndex[j]]) > maxElement)
                                {
                                    maxElement = Math.Abs(Cs[nulElementsIndex[j]]);
                                    maxElementIndex = nulElementsIndex[j];
                                }
                            }
                        }
                        //шаг 9
                        bool allPol = false;
                        int kol = 0;
                        for (int i = 0; i < matrix.Count - 2; i++)
                        {
                            if (matrix[i][maxElementIndex] > 0)
                                kol++;
                        }
                        if (kol == matrix.Count - 2)
                            allPol = true;
                        if (!allPol)
                        {
                            MessageBox.Show("Задача неразрешима!");
                            NOT_RESULT = true;
                        }
                        else
                        {
                            int k = 0;
                            int s = maxElementIndex;
                            double[] minA = new double[matrix.Count];
                            for (int i = 0; i < matrix.Count; i++)
                            {
                                if (matrix[i][maxElementIndex] > 0)
                                    minA[i] = matrix[i][0] / matrix[i][s];
                            }
                            for (int i = 0; i < matrix.Count; i++)
                            {
                                if (matrix[i][maxElementIndex] > 0)
                                {
                                    double x = matrix[i][0] / matrix[i][s];
                                    if (x == minA.Min())
                                        k = i;
                                }
                            }
                            //шаг 6
                            matrix = calc_outList(matrix, k, maxElementIndex);
                            string val = line[s];
                            line[s] = column[k];
                            column[k] = val;
                        }
                    }
                    else//шаг 3
                    {
                        int s = 0;
                        bool hasnt_pol_elements = true;
                        double[] absCs = new double[Cs.Count];
                        //берем по модулю массив
                        for (int i = 0; i < Cs.Count; i++)
                            absCs[i] = Math.Abs(Cs[i]);
                        List<double> otrOnly = new List<double>();
                        for (int j = 1; j < Cs.Count; j++) //с 1 чтобы не ловило нулевой столбец (который без переменных наверху)
                            if (Cs[j] < 0)
                                otrOnly.Add(Cs[j]);
                        for (int i = 0; i < Cs.Count; i++)
                            if (Cs[i] < 0)
                            {
                                if (Cs[i] == otrOnly.Max())
                                {
                                    s = i;
                                    break;
                                }
                            }
                        //гуляем по столбцу s
                        for (int i = 0; i < matrix.Count; i++ )
                            if (matrix[i][s] > 0)
                                hasnt_pol_elements = false;
                        if (hasnt_pol_elements)//шаг 4
                        {
                            MessageBox.Show("Задача неразрешима!");
                            NOT_RESULT = true;
                            break;
                        }
                        //шаг 5
                        int k = 0;
                        double[] minA = new double[matrix.Count];
                        for (int i = 0; i < matrix.Count; i++)
                        {
                            if (matrix[i][s] > 0)
                                minA[i] = matrix[i][0] / matrix[i][s];
                        }
                        double min = 0;
                        foreach (double m in minA)
                            if (m != 0)
                                if (min < m)
                                    min = m;
                        for (int i = 0; i < matrix.Count; i++)
                        {
                            if (matrix[i][s] > 0)
                            {
                                double x = matrix[i][0] / matrix[i][s];
                                if (x == min)
                                    k = i;
                            }
                        }
                        //шаг 6
                        matrix = calc_outList(matrix, k, s);
                        string val = line[s];
                        line[s] = column[k];
                        column[k] = val;
                    }
                    //пересчитываем С и Cs
                    C = new List<double>();
                    Cs = new List<double>();//С'
                    for (int j = 0; j < matrix[matrix.Count - 1].Count; j++)
                        C.Add(matrix[matrix.Count - 1][j]);
                    double cc = 0;
                    for (int j = 0; j < matrix[0].Count; j++)
                    {
                        for (int i = 0; i < matrix.Count - 1; i++)
                        {
                            cc += matrix[i][j];
                        }
                        Cs.Add(-cc);
                        cc = 0;
                    }
                }
            }
            
            for (int i = 0; i < matrix.Count; i++)
                for (int j = 0; j < matrix.Count; j++)
                {
                    resultArr[i, j] = matrix[i][j];
                }
            return resultArr;*/
        }
        List<string> console = new List<string>();
        private void s2()
        {
            console.Add("");
            console.Add("");
            print();

            int s = -1;
            for (int i = 1; i < m.GetLength(1); i++)
                if (m[m.GetLength(0) - 1, i] < 0)
                {
                    if (s == -1)
                        s = i;
                    else if (m[m.GetLength(0) - 1, s].CompareTo(m[m.GetLength(0) - 1, i]) > 0)
                        s = i;
                }
            if (s == -1)
            {
                s7();
            }
            else
            {
                console.Add("s = " + s);

                int k = -1;
                for (int i = 0; i < m.GetLength(0) - 2; i++)
                {
                    if (m[i, s] > 0)
                    {
                        if (k == -1)
                            k = i;
                        else if ((m[k, 0] / m[k, s]) - (m[i, 0] / (m[i, s])) > 0)
                            k = i;
                    }
                }
                if (k == -1)
                {
                    console.Add("Задача неразрешима");
                }
                else
                {
                    console.Add("k = " + k);
                    je(k, s);
                    s2();
                }
            }
        }

        private void je(int k, int s)
        {
            m = matrix.jordan(m, k, s);
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                    if (Math.Abs(m[i, j]) < 0.00001)
                        m[i, j] = 0;

            String tmp = r[k];
            r[k] = c[s];
            c[s] = tmp;

            if ("0".Equals(c[s]))
            {
                m = matrix.removeColumn(m, s);
                String[] t = new String[c.GetLength(0) - 1];
                for (int i = 0; i < t.GetLength(0); i++)
                    t[i] = c[i < s ? i : i + 1];
                c = t;
            }
        }

        private void s7()
        {
            console.Add("");
            console.Add("");
            print();

            bool p = true;
            bool z = true;
            for (int j = 1; j < m.GetLength(1); j++)
            {
                if (Math.Abs(m[m.GetLength(0) - 1, j]) < 0.00001 && m[m.GetLength(0) - 2, j] < 0)
                    p = false;
                if (Math.Abs(m[m.GetLength(0) - 1, j]) > 0.00001)
                    z = false;
            }
            if (z)
            {
                console.Add("Оптимальный план");
            }
            else if (p)
            {
                console.Add("Оптимален");
            }
            else
            {
                int s = -1;
                for (int j = 1; j < m.GetLength(1); j++)
                {
                    if (Math.Abs(m[m.GetLength(0) - 1, j]) < 0.00001 && m[m.GetLength(0) - 2, j] < 0)
                    {
                        if (s == -1)
                            s = j;
                        else if (m[m.GetLength(0) - 2, j].CompareTo(m[m.GetLength(0) - 2, s]) < 0)
                            s = j;
                    }
                }
                console.Add("s " + s);

                int k = -1;
                for (int i = 0; i < m.GetLength(0); i++)
                {
                    if (m[i, s] > 0)
                    {
                        if (k == -1)
                            k = i;
                        else if (m[i, 0] / (m[i, s]).CompareTo(m[k, 0] / (m[k, s])) < 0)
                            k = i;
                    }
                }
                console.Add(k + " " + s);
                if (k == -1)
                {
                    console.Add("k = -1 задача неразрешима");
                }
                else
                {
                    je(k, s);
                    s7();
                }
            }
        }

        public void print()
        {
            string s = "\t";
            for (int i = 0; i < c.GetLength(0); i++)
            {
                if (c[i].StartsWith("x"))
                    s += "-" + c[i] + "\t";
                else
                    s += c[i] + "\t";
            }
            console.Add(s);
            s = "";
            console.Add("");
            for (int i = 0; i < m.GetLength(0); i++)
            {
                s += r[i] + "\t";
                for (int j = 0; j < m.GetLength(1); j++)
                    s += Math.Round(m[i, j], 2) + "\t";
                console.Add(s);
                s = "";
                console.Add("");
            }
        }

        public void printResult()
        {
            
            int Xcount = m.GetLength(0)+m.GetLength(1)-3;
            double[] result = new double[Xcount];



            for (int i = 0; i < r.GetLength(0); i++)
            {
                if (r[i].StartsWith("x"))
                {
                    result[int.Parse(r[i].Substring(1)) - 1] = m[i, 0];
                }
                           
            }

            console.Add("\t");
            string s = "(";
            for (int i = 0; i < result.GetLength(0);i++)
            {
                s += " " + Math.Round(result[i], 2) + ",";
            }
            s += ")";
            console.Add(s);
            RESULT = s;
            console.Add("\t");
           

        }
        //проверка условий, налагаемых на элементы двух последних строк (флаг остановки алгоритма)
        bool repeat(List<double> C, List<double> Cs)
        {
            //есть ли в g строке отрицательные
            foreach (double d in Cs)
                if (d < 0)
                    return true;
            //есть ли в f строке над нулями g строки отрицательные
            for (int i = 0; i < Cs.Count; i++)
                if (Cs[i].Equals(0))
                    if (C[i] < 0)
                        return true;
            return false;
        }

        string allElementsIs(double[] arr)
        {
            int otr = 0;
            int pol = 0;
            int nul = 0;
            int nulpol = 0;
            int nulotr = 0;
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j] == 0)//сделать Math.Abs(C[j]) < Eps
                    nul++;
                if (arr[j] > 0)
                    pol++;
                if (arr[j] < 0)
                    otr++;
                if (arr[j] >= 0)
                    nulpol++;
                if (arr[j] <= 0)
                    nulotr++;
            }
            if (otr == arr.Length)
                return "отрицательны";
            else if (pol == arr.Length)
                return "положительны";
            else if (nul == arr.Length)
                return "нулевые";
            else if (nulpol == arr.Length)
                return "неотрицательны";
            else if (nulotr == arr.Length)
                return "неположительны";
            return "разных знаков";
        }

        string allElementsIs(int[] arr)
        {
            int otr = 0;
            int pol = 0;
            int nul = 0;
            int nulpol = 0;
            int nulotr = 0;
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j] == 0)//сделать Math.Abs(C[j]) < Eps
                    nul++;
                if (arr[j] > 0)
                    pol++;
                if (arr[j] < 0)
                    otr++;
                if (arr[j] >= 0)
                    nulpol++;
                if (arr[j] <= 0)
                    nulotr++;
            }
            if (otr == arr.Length)
                return "отрицательны";
            else if (pol == arr.Length)
                return "положительны";
            else if (nul == arr.Length)
                return "нулевые";
            else if (nulpol == arr.Length)
                return "неотрицательны";
            else if (nulotr == arr.Length)
                return "неположительны";
            return "разных знаков";
        }

        void transportTask(List<List<double>> matrix, int[] a, int[] b)
        { 
            //a - объём продукции
            //b - объём потребления
            //alpha - пункты потребления
            //A - пункты производства
            //х - объем производимой по маршруту А - альфа продукции
            int[,] x = new int[matrix.Count, matrix[0].Count];
            //С - затраты на перевозку единицы продукции по маршруту А - альфа
            int[,] C = new int[matrix.Count, matrix[0].Count];
            //считаем потенциалы
            //ищем минимальный элемент матрицы
            double minElement = 0; 
            int k = 0;
            int s = 0;
            while (true)
            {
                //C[k,s]
                for (int i = 0; i < matrix.Count; i++)
                    for (int j = 0; j < matrix[0].Count; j++)
                    {
                        if (minElement < matrix[i].Min())
                        {
                            minElement = matrix[i].Min();
                            for (int l = 0; l < matrix[i].Count; l++)
                                if (minElement == matrix[i][j])
                                {
                                    k = i;
                                    s = j;
                                }
                        }
                    }
                x[k, s] = Math.Min(a[k], b[s]);
                a[k] = a[k] - x[k, s];
                b[s] = b[s] - x[k, s];
                if (a[k] == 0)
                { }
                else
                {
                    if (allElementsIs(b).Equals("нулевые"))
                    {
                        break;
                    }
                    else
                    {

                        for (int j = 0; j < b.Length; j++)
                            if (b[j] > 0)
                                if (C[k, s] > C[k, j])
                                    C[k, s] = C[k, j];
                    }
                    if (allElementsIs(a).Equals("нулевые"))
                    {
                        break;
                    }
                    else
                    {

                        for (int i = 0; i < b.Length; i++)
                            if (a[i] > 0)
                                if (C[k, s] > C[i, s])
                                    C[k, s] = C[i, s];
                    }

                }
            }

            int[] u = new int[matrix.Count];
            int[] v = new int[matrix[0].Count];
            for (int i = 0; i < u.Length; i++)
            {
                if (i == 0)
                    u[i] = 0;
                for (int j = 0; j < v.Length; j++)
                {
                    int vv = b[j] / Convert.ToInt32(matrix[i][j]);
                    if (vv > 0)
                    {
                        u[i] = Convert.ToInt16(matrix[i][j]) - v[j];
                        v[j] = Convert.ToInt16(matrix[i][j]) - u[i];
                            
                    }

                }
                
            }

        }

        List<List<double>> readMatrixList(RichTextBox rtb)
        {
            List<List<double>> matrix = new List<List<double>>();
            int count = rtb.Lines.Length;
            char[] sep = { ' ' };
            for (int i = 0; i < count; i++)
            {
                y.Add("y"+i.ToString());
                List<double> line = new List<double>();
                string[] sArr = rtb.Lines[i].Split(sep);
                for (int j = 0; j < sArr.Length; j++ )
                {
                    if (sArr[j] != "")
                    {
                        x.Add("x"+j.ToString());
                        line.Add(Convert.ToDouble(sArr[j]));
                    }
                }
                if (line.Count != 0)
                    matrix.Add(line);
            }
            return matrix;
        }

        int[,] readMatrix(RichTextBox rtb)
        {
            List<List<int>> matrix = new List<List<int>>();
            int count = rtb.Lines.Length;
            char[] sep = { ' ' };
            for (int i = 0; i < count; i++)
            {
                y.Add("y" + i.ToString());
                List<int> line = new List<int>();
                string[] sArr = rtb.Lines[i].Split(sep);
                for (int j = 0; j < sArr.Length; j++)
                {
                    if (sArr[j] != "")
                    {
                        x.Add("x" + j.ToString());
                        line.Add(Convert.ToInt16(sArr[j]));
                    }
                }
                if (line.Count != 0)
                    matrix.Add(line);
            }
            int[,] m = new int[matrix.Count, matrix[0].Count];
            for (int i = 0; i < matrix.Count; i++)
                for (int j = 0; j < matrix[0].Count; j++)
                    m[i, j] = matrix[i][j];
            return m;
        }

        double[,] readMatrixDouble(RichTextBox rtb)
        {
            List<List<double>> matrix = new List<List<double>>();
            int count = rtb.Lines.Length;
            char[] sep = { ' ' };
            for (int i = 0; i < count; i++)
            {
                y.Add("y" + i.ToString());
                List<double> line = new List<double>();
                string[] sArr = rtb.Lines[i].Split(sep);
                for (int j = 0; j < sArr.Length; j++)
                {
                    if (sArr[j] != "")
                    {
                        x.Add("x" + j.ToString());
                        line.Add(Convert.ToDouble(sArr[j]));
                    }
                }
                if (line.Count != 0)
                    matrix.Add(line);
            }
            double[,] m = new double[matrix.Count, matrix[0].Count];
            for (int i = 0; i < matrix.Count; i++)
                for (int j = 0; j < matrix[0].Count; j++)
                    m[i, j] = matrix[i][j];
            return m;
        }

        void writeMatrix(double[,] Matrix, RichTextBox rtb)
        {
            
            for (int i = 0; i < Matrix.GetLength(0); i++)
                for (int j = 0; j < Matrix.GetLength(1); j++)
                    {
                        if (j == Matrix.GetLength(1) - 1)
                        { rtb.Text += Matrix[i, j].ToString() + "\n"; }
                        else
                        { rtb.Text += Matrix[i, j].ToString() + " "; }
                    }
            if (textBoxK.Text != "")
            {
                int k = Convert.ToInt32(textBoxK.Text);
                log.Add("k = " + k.ToString());
            }
            if (textBoxS.Text != "")
            {
                int s = Convert.ToInt32(textBoxS.Text);
                log.Add("s = " + s.ToString());
            }
            log.AddRange(rtb.Lines.ToList());
        }

        void writeMatrix(List<List<double>> Matrix, RichTextBox rtb)
        {
            for (int i = 0; i < Matrix.Count; i++)
                for (int j = 0; j < Matrix[i].Count; j++)
                {
                    if (j == Matrix[i].Count - 1)
                    { rtb.Text += Matrix[i][j].ToString() + "\n"; }
                    else
                    { rtb.Text += Matrix[i][j].ToString() + " "; }
                }
            int k = Convert.ToInt32(textBoxK.Text);
            int s = Convert.ToInt32(textBoxS.Text);
            log.Add("k = " + k.ToString());
            log.Add("s = " + s.ToString());
            log.AddRange(rtb.Lines.ToList());
        }

        string outResult(List<string> lineX/*переменные вверху таблицы*/, List<string> columnX/*слева*/, List<List<double>> Matrix)
        {
            string s = "";
            if (columnX.Count != 0)
            {
                for (int i = 0; i < lineX.Count; i++)
                    if (!lineX[i].Equals("0") && !lineX[i].Equals("1"))
                        s += lineX[i] + " = α" + i.ToString() + "\n";
                for (int i = 0; i < columnX.Count; i++)
                {
                    if (!columnX[i].Equals("0"))
                    {
                        s += columnX[i] + " = ";
                        for (int j = 0; j < Matrix[i].Count; j++)
                        {
                            if (!lineX[j].Equals("0"))
                            {
                                if (j == 0)
                                {
                                    if (Matrix[i][j] != 0)
                                        s += Matrix[i][j].ToString() + " -";
                                }
                                else
                                {
                                    if (Matrix[i][j] != 1 && Matrix[i][j] != 0)
                                        s += " " + Matrix[i][j].ToString() + "α" + j.ToString() + " -";
                                    else if (Matrix[i][j] != 0)
                                        s += " α" + j.ToString() + " -";
                                }
                            }
                        }
                        s = s.Remove(s.Length - 1, 1);
                        s += "\n";
                    }
                }
            }
            else
            {
                for (int i = 0; i < lineX.Count; i++)
                    s += lineX[i] + " = " + "α" + i.ToString() + "\n";
            }
            return s;
        }
        //метод жордановых исключений
        double[,] calc(List<List<double>> matrix, int k, int s)
        {
            double[,] outMatrix = new double[matrix.Count, matrix[0].Count];
            for (int i = 0; i < matrix.Count; i++)//по строкам
                for (int j = 0; j < matrix[i].Count; j++)//по элементам строки
                {
                    if (i != k && j != s)
                    {
                        outMatrix[i, j] = (matrix[i][j] * matrix[k][s] - matrix[i][s] * matrix[k][j]) / matrix[k][s];
                    }
                    else if (i == k && j != s)
                    {
                        outMatrix[i, j] = matrix[k][j] / matrix[k][s];
                    }
                    else if (j == s && i != k)
                    {
                        outMatrix[i, j] = - matrix[i][j] / matrix[k][s]; 
                    }
                    else if (i == k && j == s)
                    {
                        outMatrix[i, j] = 1.0 / matrix[k][s];
                    }
                }
            return outMatrix;
        }

        //метод жордановых исключений
        List<List<double>> calc_outList(List<List<double>> matrix, int k, int s)
        {
            List<List<double>> outMatrix = new List<List<double>>();
            for (int i = 0; i < matrix.Count; i++)//по строкам
            {
                List<double> ld = new List<double>();
                for (int j = 0; j < matrix[i].Count; j++)//по элементам строки
                {
                    if (i != k && j != s)
                    {
                        ld.Add((matrix[i][j] * matrix[k][s] - matrix[i][s] * matrix[k][j]) / matrix[k][s]);
                    }
                    else if (i == k && j != s)
                    {
                        ld.Add(matrix[k][j] / matrix[k][s]);
                    }
                    else if (j == s && i != k)
                    {
                        ld.Add(- matrix[i][j] / matrix[k][s]);
                    }
                    else if (i == k && j == s)
                    {
                        ld.Add(1.0 / matrix[k][s]);
                    }
                }
                outMatrix.Add(ld);
            }
            return outMatrix;
        }

        private void GeneralForm_Load(object sender, EventArgs e)
        {
            richTextBoxInput.Focus();
        }

        private void richTextBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\b' && e.KeyChar != '-' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void textBoxS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void GeneralForm_Resize(object sender, EventArgs e)
        {
            int space = 6;
            int width = Width / 2;
            richTextBoxInput.Width = width;
            richTextBoxOutput.Location = new Point(width + space, richTextBoxOutput.Location.Y);
            richTextBoxOutput.Width = width;
            buttonClearInput.Location = new Point(richTextBoxInput.Width - buttonClearInput.Width, buttonClearInput.Location.Y);
            buttonClearOutput.Location = new Point(richTextBoxOutput.Location.X, buttonClearInput.Location.Y);
            buttonLog.Location = new Point(richTextBoxInput.Width - buttonLog.Width / 2, buttonLog.Location.Y);
            comboBoxLab.Width = buttonLog.Location.X - 10;
        }

        private void textBoxS_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCleatOutput_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                if (((Button)sender).Name.IndexOf("Input") != -1)
                {
                    richTextBoxInput.Text = "";
                }
                else if (((Button)sender).Name.IndexOf("Output") != -1)
                {
                    richTextBoxOutput.Text = "";
                }
            }
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            richTextBoxInput.Text = richTextBoxOutput.Text = textBoxK.Text = textBoxS.Text = "";
            lineX.Clear();
            columnX.Clear();
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            foreach (string s in log)
                richTextBoxInput.Text += "\n" + s;
        }

        private void richTextBoxInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (добавлятьПробелыПослеЦифрToolStripMenuItem.Checked)
                if (sender is RichTextBox)
                    if (e.KeyCode == Keys.D0 ||
                        e.KeyCode == Keys.D1 ||
                        e.KeyCode == Keys.D2 ||
                        e.KeyCode == Keys.D3 ||
                        e.KeyCode == Keys.D4 ||
                        e.KeyCode == Keys.D5 ||
                        e.KeyCode == Keys.D6 ||
                        e.KeyCode == Keys.D7 ||
                        e.KeyCode == Keys.D8 ||
                        e.KeyCode == Keys.D9 ||
                        e.KeyCode == Keys.NumPad0 ||
                        e.KeyCode == Keys.NumPad1 ||
                        e.KeyCode == Keys.NumPad2 ||
                        e.KeyCode == Keys.NumPad3 ||
                        e.KeyCode == Keys.NumPad4 ||
                        e.KeyCode == Keys.NumPad5 ||
                        e.KeyCode == Keys.NumPad6 ||
                        e.KeyCode == Keys.NumPad7 ||
                        e.KeyCode == Keys.NumPad8 ||
                        e.KeyCode == Keys.NumPad9)
                    {

                        ((RichTextBox)sender).Text += " ";
                        ((RichTextBox)sender).Select(((RichTextBox)sender).Text.Length, 0);

                    }
        }

        private void добавлятьПробелыПослеЦифрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (добавлятьПробелыПослеЦифрToolStripMenuItem.Checked)
                добавлятьПробелыПослеЦифрToolStripMenuItem.Checked = false;
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            MessageBox.Show(RESULT, "Ответ");
        }

        private void comboBoxLab_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxInput.Text = "";
            double[,] arr1 = { { 4, 1, 2, 1, 0 }, { 6, 1, 1, 0, 1 }, { 10, 1, -1, -2, 3 } };
            double[,] arr2 = { { 3, 1, -4, 2, -5, 9 }, { 6, 0, 1, -3, 4, -5 }, { 1, 0, 1, -1, 1, -1 }, { 0, 2, 6, -5, 1, 4 } };
            double[,] arr3 = { {7,1,4,5,2,85},
                               {13,4,7,6,3,112},
                               {3,8,0,18,12,72},
                               {9,5,3,4,7,120},
                               {75,125,64,65,60,0} };
            double[] A = { 90, 70, 50 };
            double[] alpha = { 80, 60, 40, 30 };
            switch (comboBoxLab.SelectedIndex)
            {
                case 0:
                    {
                        textBoxK.Visible = label1.Visible = true;
                        textBoxS.Visible = label2.Visible = true;
                        
                        textBoxK.Text = "1";
                        textBoxS.Text = "4";
                        writeMatrix(arr1, richTextBoxInput);
                    }
                    break;
                case 1:
                    {
                        textBoxK.Visible = label1.Visible = false;
                        textBoxS.Visible = label2.Visible = false;
                        writeMatrix(arr2, richTextBoxInput);
                    }
                    break;
                case 2:
                    {
                        textBoxK.Visible = label1.Visible = false;
                        textBoxS.Visible = label2.Visible = false;
                        writeMatrix(arr3, richTextBoxInput);
                    }
                    break;
            }
        }
    }
}
