using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
using System.Data;
using System.Text.RegularExpressions;

namespace Assignment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> screen;
        public MainWindow()
        {
            InitializeComponent();
            screen = new List<string>{ };
            
        }
        void Window_KeyDown(Object sender, KeyEventArgs e)
        {
            switch (e.Key.ToString()) // Convertimos la tecla en string
            {
                case "D1":
                case "NumPad1":
                    btn1_Click(btn1, new RoutedEventArgs());
                    break;
                case "D2":
                case "NumPad2":
                    btn2_Click(btn2, new RoutedEventArgs());
                    break;
                case "D3":
                case "NumPad3":
                    btn3_Click(btn3, new RoutedEventArgs());
                    break;
                case "D4":
                case "NumPad4":
                    btn4_Click(btn4, new RoutedEventArgs());
                    break;
                case "D5":
                case "NumPad5":
                    btn5_Click(btn5, new RoutedEventArgs());
                    break;
                case "D6":
                case "NumPad6":
                    btn6_Click(btn6, new RoutedEventArgs());
                    break;
                case "D7":
                case "NumPad7":
                    btn7_Click(btn7, new RoutedEventArgs());
                    break;
                case "D8":
                case "NumPad8":
                    btn8_Click(btn8, new RoutedEventArgs());
                    break;
                case "D9":
                case "NumPad9":
                    btn9_Click(btn9, new RoutedEventArgs());
                    break;
                case "D0":
                case "NumPad0":
                    btn0_Click(btn0, new RoutedEventArgs());
                    break;
                case "Add":
                    btnPlus_Click(btnPlus, new RoutedEventArgs());
                    break;
                case "Subtract":
                    btnMinus_Click(btnMinus, new RoutedEventArgs());
                    break;
                case "Multiply":
                    btnMult_Click(btnMult, new RoutedEventArgs());
                    break;
                case "Divide":
                    btnDiv_Click(btnDiv, new RoutedEventArgs());
                    break;
                case "Return":
                case "Enter":
                    btnEqual_Click(btnEqual, new RoutedEventArgs());
                    break;
                case "Back":
                    btnR_Click(btnR, new RoutedEventArgs());
                    break;
                case "Delete":
                    btnDel_Click(btnDel, new RoutedEventArgs());
                    break;
            }
        }

        private void updateScreen()
        {
            string text = string.Join("", screen);
            Result.Text = text;
        }

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {


            string operation = string.Join("", screen);

            if (isValid(operation))
            {
                try
                {
                    var result = new DataTable().Compute(operation, null);
                    screen.Add("=");
                    screen.Add(Math.Round(Convert.ToDouble(result), 5).ToString());
                    updateScreen();
                    screen.Clear();
                }
                catch
                {
                    screen.Clear();
                    updateScreen();
                }
            }
            else
            {
                screen.Clear();
                updateScreen();
            }
        }

        static bool isValid(string operation)
        {
            if (Regex.IsMatch(operation, @"(?<![\d\)])[\+\*/]{2,}") || Regex.IsMatch(operation, @"--|\+\+|\*/|\*\*|//"))
            {
                return false;
            }
            if (Regex.IsMatch(operation, @"(?<![\d\)])-")) // Verifica que el '-' sea correcto
            {
                operation = operation.Replace("--", "+"); // Corrige dobles negativos
            }
            if (Regex.IsMatch(operation, @"^[\+\*/]") || Regex.IsMatch(operation, @"[\+\-\*/]$"))
            {
                return false;
            }
            return true;

        }


        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            screen.Clear();
            updateScreen();
        }

        private void btnR_Click(object sender, RoutedEventArgs e)
        {
            if (screen.Count > 0)
            {
                screen.RemoveAt(screen.Count - 1);
            }
            updateScreen();
        }

        private void btnOff_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            screen.Add("7");
            updateScreen();
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            screen.Add("8");
            updateScreen();
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            screen.Add("9");
            updateScreen();
        }

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            screen.Add("/");
            updateScreen();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            screen.Add("4");
            updateScreen();
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            screen.Add("5");
            updateScreen();
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            screen.Add("6");
            updateScreen();
        }

        private void btnMult_Click(object sender, RoutedEventArgs e)
        {
            screen.Add("*");
            updateScreen();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            screen.Add("1");
            updateScreen();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            screen.Add("2");
            updateScreen();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            screen.Add("3");
            updateScreen();
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            screen.Add("-");
            updateScreen();
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            screen.Add("0");
            updateScreen();
        }

        

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            screen.Add("+");
            updateScreen();
        }
    }
}
