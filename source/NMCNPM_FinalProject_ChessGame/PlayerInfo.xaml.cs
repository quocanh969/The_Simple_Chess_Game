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
    /// Interaction logic for PlayerInfo.xaml
    /// </summary>

    public partial class PlayerInfo : Window
    {
        int i;
        //private Point lastPoint;
        public PlayerInfo(string id, int stage)
        {
            InitializeComponent();
            i = stage;
            loadData(id);
        }

        //Load Data for player info window
        private void loadData(string id)
        {
            UserBUS bus = new UserBUS();
            UserDTO result = bus.loadOneUser(id);
            txtName.Text = result.name;
            txtID.Text = result.id;
            txtEmail.Text = result.email;
            txtRecord.Text = result.point.ToString();
            WinNum.Content = result.wmatchs;
            DrawNum.Content = result.dmatchs;
            LoseNum.Content = result.lmatchs;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {// Xử lý sự kiện tắt khung thông tin
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {// Xử lý sự kiện thay đổi màn hình
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Window_Closed(object sender, EventArgs e)
        {// Xử lý khi tắt màn hình
            GlobalItem.isAnyPlyerInfo[i] = false;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {// Xử lý khi minimize cửa sổ
            this.WindowState = WindowState.Minimized;
        }
    }
}
