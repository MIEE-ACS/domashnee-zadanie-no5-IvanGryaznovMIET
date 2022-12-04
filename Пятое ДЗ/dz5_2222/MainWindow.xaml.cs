using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace dz5_2222
{
    public class Fraction
    {
        int nominator;
        int denominator;

        public Fraction(int n, int d)
        {
            nominator = n;
            denominator = d;
        }

        public int getNominator()    // Возврат значения
        {
            return nominator;
        }
        public int getDenominator()  // Возврат значения
        {
            return denominator;
        }
        public int setNominator      // Переопределение значения
        {
            set { nominator = value; }
        }

        public int setDenominator    // Переопределение значения
        {
            set { denominator = value; }
        }
    }

    
    
    public partial class MainWindow : Window
    {
        public static void answer_calculate()
        {
            int buf = fractions[0].getDenominator();
            fractions[0].setDenominator = fractions[0].getDenominator() * fractions[1].getDenominator();    // Считаем знаменатель результата
            fractions[0].setNominator = fractions[0].getNominator() * fractions[1].getDenominator();        // Первое слaгаемое знаменателя результата
            // fractions[1].setDenominator = fractions[1].getDenominator() * buf;
            fractions[1].setNominator = fractions[1].getNominator() * buf;      // Второе слaгаемое знаменателя результата
            fractions[2] = new Fraction(fractions[0].getNominator() + fractions[1].getNominator(), fractions[0].getDenominator());    // Результат (конечная дробь)
            
        }


        public MainWindow()
        {
            InitializeComponent();
        }


        public static Fraction[] fractions = new Fraction[3];


        private void calc_Click(object sender, RoutedEventArgs e)
        {
            // ---------- Указан ли слэш ----------
            bool correct = false;
            string[] buf;
            for (int i = 0; i < frac1box.Text.Length; i++)
            {
                if (frac1box.Text[i] == '/')
                {
                    correct = true;
                    break;
                }                
            }


            if (correct == false)
            {
                MessageBox.Show("Введите дробь 1 корректно");
                throw new Exception("Дробь 1 указана некорректно");
            }
            correct = false;


            // ---------- Указан ли слэш ----------
            for (int i = 0; i < frac2box.Text.Length; i++)
            {
                if (frac2box.Text[i] == '/')
                {
                    correct = true;
                    break;
                }

            }


            if (correct == false)
            {
                MessageBox.Show("Введите дробь 2 корректно");
                throw new Exception("Дробь 2 указана некорректно");
            }
            buf = frac1box.Text.Split('/');
            int trash;


            // ---------- Проверка на корректность введённых данных (нельзя вводить строку) ----------
            if (int.TryParse(buf[0], out trash) && int.TryParse(buf[1], out trash))
            {
                fractions[0] = new Fraction(int.Parse(buf[0]), int.Parse(buf[1]));
            }

            else
            {
                MessageBox.Show("Введите дробь 1 корректно");
                throw new Exception("Дробь 1 указана некорректно");
            }
            buf = frac2box.Text.Split('/');


            // ---------- Проверка на корректность введённых данных (нельзя вводить строку) ----------
            if (int.TryParse(buf[0], out trash) && int.TryParse(buf[1], out trash))
            {
                fractions[1] = new Fraction(int.Parse(buf[0]), int.Parse(buf[1]));
            }

            else
            {
                MessageBox.Show("Введите дробь 2 корректно");
                throw new Exception("Дробь 2 указана некорректно");
            }


            // ---------- Деление на ноль ----------
            if ( (fractions[0].getDenominator() == 0) || (fractions[1].getDenominator() == 0) )
            {
                MessageBox.Show("На ноль делить нельзя, болван !!!");
                throw new Exception("Дробь указана некорректно");
            }


            // ---------- Проверка на количество слэшей (должно быть не больше одного) ----------
            int k = 0;
            int n = 0;

            for (int i = 0; i < frac1box.Text.Length; i++)
            {
                if (frac1box.Text[i] == '/')
                {
                    k += 1;
                }

            }

            if (k >= 2)
            {
                MessageBox.Show(" Запишите первую дробь в формате 'Ч/З' ");
                throw new Exception("Дробь 1 указана некорректно");
            }


            // ---------- Проверка на количество слэшей (должно быть не больше одного) ----------
            for (int i = 0; i < frac2box.Text.Length; i++)
            {
                if (frac2box.Text[i] == '/')
                {
                    n += 1;
                }

            }

            if (n >= 2)
            {
                MessageBox.Show(" Запишите вторую дробь в формате 'Ч/З' ");
                throw new Exception("Дробь 2 указана некорректно");
            }


            answer_calculate();
            answer.Text = string.Format("{0}/{1}", fractions[2].getNominator(), fractions[2].getDenominator());

        }
    }

}
