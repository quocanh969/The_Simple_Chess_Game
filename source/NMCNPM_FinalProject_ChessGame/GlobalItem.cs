using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace NMCNPM_FinalProject_ChessGame
{
    class GlobalItem
    {
        // Màn hình main
        public static MainWindow main;

        // Bien61 pause
        public static bool pause = false;

        // Kiểm tra xem người dùng đăng nhập thành công chưa
        public static bool isPlayer1LoingOK;
        public static bool isPlayer2LoingOK;

        // Luu thong tin cua van dau
        public static string IDPlayer1;
        public static string IDPlayer2;
        public static int time1;
        public static int time2;
        public static int turn = 0;
        public static string chessboard = "KJILMIJKHHHHHHHHGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGFFFFFFFFCDEBAEDC";
        public static string check = "000000";
        public static string ate = "000000000000";
        public static System.Windows.Threading.DispatcherTimer dt1 = null;
        public static System.Windows.Threading.DispatcherTimer dt2 = null;

        // Xác định số điểm của hai bên
        public static int numOfWhitePawn = 0;
        public static int numOfBlackPawn = 0;
        public static int numOfWhiteBishop = 0;
        public static int numOfBlackBishop = 0;
        public static int numOfWhiteKnight = 0;
        public static int numOfBlackKnight = 0;
        public static int numOfWhiteCastle = 0;
        public static int numOfBlackCastle = 0;
        public static int numOfWhiteQueen = 0;
        public static int numOfBlackQueen = 0;
        public static int numOfWhiteKing = 0;
        public static int numOfBlackKing = 0;

        // Xác định thời gian phút:giây tối đa của mỗi người choi7
        public static string globalMin;
        public static string globalSec;
        public static bool pauseTime;
        //5:40 29/12
        public static int tempsec1;
        public static int tempsec2;



        // Biến kiểm tra xem các cửa sổ nào đang được mở
        public static bool isRegisterOpen = false;
        public static bool isRankOpen = false;
        public static bool isLoadOpen = false;
        public static bool isSettingOpen = false;
        public static List<bool> isAnyPlyerInfo = new List<bool>();
        public static List<bool> isAnyMatchInfo = new List<bool>();

        // Bg
        public static string Source = "Source/Gameplay_Background/classic.jpg";

        // Mau game
        public static SolidColorBrush typePlayer1 = new SolidColorBrush(Color.FromRgb(200, 226, 177));
        public static SolidColorBrush typePlayer2 = new SolidColorBrush(Color.FromRgb(255, 255, 255));

        // Sound
        public static bool isAudio = true;

        public static Rectangle man_che_vu_tru;

        //Phuc vu cho viec countdown dong ho
        public static int pre = -3;
        public static int time_win = 1;
    }
}
