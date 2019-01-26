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
    /// Interaction logic for Save.xaml
    /// </summary>
    public partial class Save : Window
    {
        MatchDTO matchToSave;
        public Save(MatchDTO match)
        {
            InitializeComponent();
            matchToSave = match;

            GlobalItem.man_che_vu_tru.Visibility = Visibility.Visible;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {// Xử lý drag window
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {// Xử lý khi ấn button CANCEL
            GlobalItem.man_che_vu_tru.Visibility = Visibility.Hidden;
            this.Close();
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {// Xử lý khi ấn button OK để hoàn thành việc lưu ván đấu
            if (txtUserName.Text.Count()==0)
            {
                MessageBox.Show("Please enter ID to know which your match is.");
                return;
            }
            if (txtPassword.Password.Count()==0)
            {
                MessageBox.Show("Please enter password.");
                return;
            }

            matchToSave.id = txtUserName.Text;
            matchToSave.password = txtPassword.Password;
            matchToSave.ate = GlobalItem.ate;

            MatchBUS bus = new MatchBUS();
            int result = bus.SaveMatch(matchToSave);
            if (result == 0)
                MessageBox.Show("Can not save, please try again later");
            else if (result == 1)
            {
                MessageBox.Show("Match saved");

                this.Close();
            }
            else
            {
                MessageBox.Show("ID was existed, please enter other ID");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {// Xu73 ly thoat
            
        }
    }
}
