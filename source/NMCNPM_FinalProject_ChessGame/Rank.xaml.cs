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
    /// Interaction logic for Rank.xaml
    /// </summary>
    public partial class Rank : Window
    {
        List<PlayerInfo> listOfPlayerInfo = new List<PlayerInfo>();
        int count = 0;
        bool temp;

        public Rank()
        {
            InitializeComponent();
            loadRank();
        }

        private void loadRank()
        {
            UserBUS bus = new UserBUS();
            List<TopPlayer> list = new List<TopPlayer>();
            List<UserDTO> users = bus.loadAllRankedUser();

            for (int i = 0; i < users.Count(); i++)
            {
                list.Add(new TopPlayer() { rank = i + 1, id = users[i].id, point = users[i].point });
            }
            listRank.ItemsSource = list;
        }

        private void Player_Selected(object sender, MouseButtonEventArgs e)
        {
            // Lấy dữ liệu item từ list view
            ListViewItem lvi = sender as ListViewItem;
            TopPlayer yourDataObject = lvi.DataContext as TopPlayer;

            // Nếu như dữ liệu đọc vào ko bị rỗng
            if (yourDataObject != null)
            {
                string id = yourDataObject.id;

                // Gọi cửa số player info
                temp = new bool();
                temp = true;
                GlobalItem.isAnyPlyerInfo.Add(temp);
                PlayerInfo InfoScreen = new PlayerInfo(id, count);
                count++;
                InfoScreen.Owner = this;
                InfoScreen.Show();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {// Xử lý khi tắt cửa 
            if (listOfPlayerInfo != null)
            {
                for (int i = 0; i < listOfPlayerInfo.Count(); i++)
                {
                    if (GlobalItem.isAnyPlyerInfo[i] == true)
                    {
                        listOfPlayerInfo[i].Close();
                    }
                }
            }
            GlobalItem.isRankOpen = false;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
