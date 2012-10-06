using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Diagnostics;
using System.Media;
namespace Shutdown
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int step = 0;
        int actualtime;
        DispatcherTimer timer = new DispatcherTimer();
       
        public MainWindow()
        {
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            InitializeComponent();
            textBox1.Text = "0" ;
            textBox2.Text = "0";
            textBox3.Text = "0";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int hours = Convert.ToInt16(textBox1.Text);
                int minutes = Convert.ToInt16(textBox2.Text);
                int seconds = Convert.ToInt16(textBox3.Text);
                actualtime = hours * 3600 + minutes * 60 + seconds;
                step = 0;
                if (actualtime != 0)
                {
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = actualtime;
                    timer.Start();
                   
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void timer_tick(object sender, EventArgs e)
        {

           
            progressBar1.Value = step;
            int remaining=actualtime-step;
            label7.Content = (remaining / 3600).ToString() + "H : " + ((remaining / 60)%60).ToString() + "M : " + (remaining%60).ToString()+"S";
           

            if (remaining==0)
            {
                Process.Start("shutdown", "/s");

            }
            step++;
       }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            actualtime = 0;
            progressBar1.Value = 0;
            label7.Content = "";
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
        }
    }
}
