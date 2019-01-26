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
using System.Windows.Shapes;
using DTO;
using BUS;

namespace NMCNPM_FinalProject_ChessGame
{
    /// <summary>
    /// Interaction logic for MatchSetting.xaml
    /// </summary>
    public partial class MatchSetting : Window
    {
        public MatchSetting()
        {
            InitializeComponent();
            List<Time> listOfTime = new List<Time>();
            Time temp;
            for (int i = 0; i < 60; i++) 
            {
                temp = new Time() { time = i };
                listOfTime.Add(temp);
            }
            cmbMin.ItemsSource = listOfTime;
            cmbMin.SelectedIndex = 30;
            cmbSec.ItemsSource = listOfTime;
            cmbSec.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {// Xử lý khi ấn button OK
            // Phút
            Time cbi = (Time)cmbMin.SelectedItem;
            GlobalItem.globalMin = cbi.time.ToString();
            // GIây
            cbi = (Time)cmbSec.SelectedItem;
            GlobalItem.globalSec = cbi.time.ToString();
            this.Close();               
        }

        class Time
        {
            public int time { get; set; }
        }
    }
}
