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

public class MyDate
{
    int Day;
    int Month;
    int Year;

    public void SetDay(int day)
    {
        Day = day;
    }

    public void SetMonth(int month)
    {
        Month = month;
    }

    public void SetYear(int year)
    {
        Year = year;
    }

    public void SetData(int day, int month, int year)
    {
        SetDay(day);
        SetMonth(month);
        SetYear(year);
    }

    public string ShowData()
    {
        string text = "";
        if (Day < 10)
        { text = '0' + Day + "." + Month + "." + Year; }
        else if (Month < 10)
        { text =  Day + "." + '0' + Month + "." + Year; }
        else
        { text = Day + "." + Month + "." + Year; }
        return text;
    }
}
namespace van_dz5
{
    using System;




    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var myData = new MyDate();
            var newData = tb1.Text;
            var newDataArray = tb1.Text.Split('.'); //Split делает массив с разделителем ТОЧКОЙ в данной случае
            string hh = "";
            int hhh = 0;
            hh = tb1.Text;
            for(int i = 0; i < hh.Length; i++)
            {
                if(hh[i] == '.')
                {
                    hhh++;
                }
            }
            if (hhh == 2)
            {

                var newTimeArray = tb1.Text.Split('.'); //Split делает массив с разделителем ТОЧКОЙ в данной случае

                if (int.TryParse(newTimeArray[0], out int day) == true)
                { day = int.Parse(newTimeArray[0]); }
                else
                {
                    MessageBox.Show("Ошибка ввода дня.");
                    day = 0;
                }
                if (int.TryParse(newTimeArray[1], out int month) == true)
                { month = int.Parse(newTimeArray[1]); }
                else
                {
                    MessageBox.Show("Ошибка ввода месяца.");
                    month = 0;
                }
                if (int.TryParse(newTimeArray[2], out int year) == true)
                { year = int.Parse(newTimeArray[2]); }
                else
                {
                    MessageBox.Show("Ошибка ввода года.");
                    year = 0;
                }

                if (month <= 12 & year <= 2022)
                {
                    if (month == 2 && day <= 28 || month != 2)
                    {
                        myData.SetData(day - 48, month, year);
                        string text = myData.ShowData();
                        MessageBox.Show(text);
                        tbb1.Text = text;
                    }
                }
                else
                    MessageBox.Show("Ошибка!");
            }
            else
            {
                MessageBox.Show("Вы ввели неправильную дату.");
            }
            hhh = 0;
    }

        //Увеличение даты.
        private void b2_Click(object sender, RoutedEventArgs e)
        {
            var myData = new MyDate();
            if(int.TryParse(tb2.Text,out int day1) == true)
            {  day1 = int.Parse(tb2.Text); }
            else
            {
                MessageBox.Show("Ошибка увеличения дня.");
                day1 = 0;
            }
            if (int.TryParse(tb3.Text, out int month1) == true)
            {  month1 = int.Parse(tb3.Text); }
            else
            {
                MessageBox.Show("Ошибка увеличения месяца.");
                month1 = 0;
            }
            if (int.TryParse(tb3.Text, out int year1) == true)
            { year1 = int.Parse(tb4.Text); }
            else
            {
                MessageBox.Show("Ошибка увеличения года.");
                year1 = 0;
            }

            var newDataArray = tbb1.Text.Split('.');
            var day = int.Parse(newDataArray[0]);
            var month = int.Parse(newDataArray[1]);
            var year = int.Parse(newDataArray[2]);
            if ((month + month1 <= 12 & year + month1 <= 2022 && day + day1 <= 28) && (day + day1 >= 0 && month + month1 >= 0 && year + year1 >= 0))
            {
                if (month + month1 == 2 && day + day1 <= 28 || month + month1 != 2) //Февраль условие
                {
                    myData.SetData(day + day1 - 48, month + month1, year + year1);
                    string text = myData.ShowData();
                    MessageBox.Show(text);
                    tbb1.Text = text;
                }
            }
            else
                MessageBox.Show("Ошибка!");
        }
        //Уменьшение даты.
        private void b3_Click(object sender, RoutedEventArgs e)
        {
            var myData = new MyDate();
            if (int.TryParse(tb2.Text, out int day1) == true)
            { day1 = int.Parse(tb2.Text); }
            else
            {
                MessageBox.Show("Ошибка уменьшения дня.");
                day1 = 0;

            }
            if (int.TryParse(tb3.Text, out int month1) == true)
            { month1 = int.Parse(tb3.Text); }
            else
            {
                MessageBox.Show("Ошибка уменьшения месяца.");
                month1 = 0; 
            }
            if (int.TryParse(tb3.Text, out int year1) == true)
            { year1 = int.Parse(tb4.Text); }
            else
            {
                MessageBox.Show("Ошибка уменьшения года.");
                year1 = 0;  
            }

            var newDataArray = tbb1.Text.Split('.');
            var day = int.Parse(newDataArray[0]);
            var month = int.Parse(newDataArray[1]);
            var year = int.Parse(newDataArray[2]);
            if ((month - month1 <= 12 & year - year1 <= 2022) && (day - day1 >= 0 && month - month1 >= 0 && year - year1 >= 0) && day <= 31)
            {
                if (month - month1 == 2 && day - day1 <= 28 || month - month1 != 2) //Февраль условие
                {
                    myData.SetData(day - day1 - 48, month - month1, year - year1);
                    string text = myData.ShowData();
                    MessageBox.Show(text);
                    tbb1.Text = text;
                }
            }
            else
                MessageBox.Show("Ошибка!");
        }

        private void tbb1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void tb2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
