using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Matrix_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public dynamic Read_Matrix(string Matrix)
        {
            Matrix = Matrix.Replace("\r", "");
            string[] Rows = Matrix.Split('\n');
            int Row = Rows.Length;
            int Column = Rows[0].Split(' ').Length;
            Matrix A = new Matrix(Row, Column);
            foreach (string a in Rows)
                if (a.Split(' ').Length != Column)
                    return "Wrong input";
            for (int i = 0; i < Rows.Length; i++)
            {
                string[] s = Rows[i].Split(' ');
                for (int j = 0; j < Column; j++)
                    A.matrix[i, j] = Convert.ToInt32(s[j]);
            }

            return A;
        }

        private void Add_Btn(object sender, RoutedEventArgs e)
        {
            Matrix_Algebra_TBox.Text = "";
            if (string.IsNullOrEmpty(Matrix_A_TBox.Text) || string.IsNullOrEmpty(Matrix_B_TBox.Text))
            {
                Matrix_Result_TBox.Text = "No input";
                return;
            }
            var A = Read_Matrix(Matrix_A_TBox.Text);
            var B = Read_Matrix(Matrix_B_TBox.Text);
            if (A.GetType() == typeof(string))
            {
                Matrix_Result_TBox.Text = A.ToString();
                return;
            }
            if (B.GetType() == typeof(string))
            {
                Matrix_Result_TBox.Text = B.ToString();
                return;
            }

            if (A.GetType() == typeof(Matrix) & B.GetType() == typeof(Matrix))
            {
                Matrix C = A + B;
                Matrix_Result_TBox.Text = C.ToString();
                string calculations = null;
                for (int i = 0; i < C.CountRow; i++)
                    for (int j = 0; j < C.CountColumn; j++)
                        calculations += $"C[{i},{j}] = {A[i, j]} + {B[i, j]} = {C[i, j]}\n";
                Matrix_Algebra_TBox.Text = calculations;
            }
        }

        private void Subtract_Btn(object sender, RoutedEventArgs e)
        {
            Matrix_Algebra_TBox.Text = "";
            if (string.IsNullOrEmpty(Matrix_A_TBox.Text) || string.IsNullOrEmpty(Matrix_B_TBox.Text))
            {
                Matrix_Result_TBox.Text = "No input";
                return;
            }
            var A = Read_Matrix(Matrix_A_TBox.Text);
            var B = Read_Matrix(Matrix_B_TBox.Text);
            if (A.GetType() == typeof(string))
            {
                Matrix_Result_TBox.Text = A.ToString();
                return;
            }
            if (B.GetType() == typeof(string))
            {
                Matrix_Result_TBox.Text = B.ToString();
                return;
            }

            if (A.GetType() == typeof(Matrix) & B.GetType() == typeof(Matrix))
            {
                Matrix C = A - B;
                Matrix_Result_TBox.Text = C.ToString();
                string calculations = null;
                for (int i = 0; i < C.CountRow; i++)
                    for (int j = 0; j < C.CountColumn; j++)
                        calculations += $"C[{i},{j}] = {A[i,j]} - {B[i,j]} = {C[i, j]}\n";
                Matrix_Algebra_TBox.Text = calculations;
            }
        }

        private void Multiply_Btn(object sender, RoutedEventArgs e)
        {
            Matrix_Algebra_TBox.Text = "";
            if (string.IsNullOrEmpty(Matrix_A_TBox.Text) || string.IsNullOrEmpty(Matrix_B_TBox.Text))
            {
                Matrix_Result_TBox.Text = "No input";
                return;
            }
            var A = Read_Matrix(Matrix_A_TBox.Text);
            var B = Read_Matrix(Matrix_B_TBox.Text);
            if (A.GetType() == typeof(string))
            {
                Matrix_Result_TBox.Text = A.ToString();
                return;
            }
            if (B.GetType() == typeof(string))
            {
                Matrix_Result_TBox.Text = B.ToString();
                return;
            }

            if (A.GetType() == typeof(Matrix) & B.GetType() == typeof(Matrix))
            {
                Matrix C = A * B;
                Matrix_Result_TBox.Text = C.ToString();
                string calculations = null;
                for (int i = 0; i < C.CountRow; i++)
                {
                    for (int j = 0; j < C.CountColumn; j++)
                    {
                        calculations += $"C[{i},{j}] = ";
                        for (int k = 0; k < B.CountRow; k++)
                        {
                            if (k == 0)
                                calculations += $"{A[i, k]} * {B[k, j]} ";
                            else
                                calculations += $"+ {A[i, k]} * {B[k, j]} ";
                        }
                        calculations += $"= {C[i, j]}\n";
                    }
                }
                Matrix_Algebra_TBox.Text = calculations;
            }
        }
        
        private void Transpose_Btn(object sender, RoutedEventArgs e)
        {
            Matrix_Algebra_TBox.Text = "";
            if (string.IsNullOrEmpty(Matrix_A_TBox.Text))
            {
                Matrix_Result_TBox.Text = "No input";
                return;
            }
            var A = Read_Matrix(Matrix_A_TBox.Text);
            if (A.GetType() == typeof(string))
            {
                Matrix_Result_TBox.Text = A.ToString();
                return;
            }

            Matrix_Result_TBox.Text = Matrix.Transponse(A).ToString();
        }
    }
}
