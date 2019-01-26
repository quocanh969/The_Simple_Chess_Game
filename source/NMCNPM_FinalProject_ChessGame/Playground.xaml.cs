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
using DTO;
using BUS;
using System.Media;

namespace NMCNPM_FinalProject_ChessGame
{
    /// <summary>
    /// Interaction logic for Playground.xaml
    /// </summary>
    public partial class Playground : UserControl
    {
        CinemaSeats seats;
        
        public Playground()
        {            
            InitializeComponent();
            GlobalItem.man_che_vu_tru = Man_che;



        }

        // Hàm khởi tạo chương trình chính thức, bắt đầu chạy
        public void itPlayTime()
        {
            //seats.startCountdown();
        }

        // Hàm set thời gian
        public void setTime()
        {
            min1.Content = GlobalItem.globalMin;
            sec1.Content = GlobalItem.globalSec;
            min2.Content = GlobalItem.globalMin;
            sec2.Content = GlobalItem.globalSec;
        }
        
        // Hàm load CinemaSeats
        public void loadMatch()
        {
            GlobalItem.dt1 = new System.Windows.Threading.DispatcherTimer();
            GlobalItem.dt2 = new System.Windows.Threading.DispatcherTimer();

            this.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), GlobalItem.Source)));
       
       // Cap nha tbuton
           

            seats = new CinemaSeats(8, 8, Ghe, phongcap, min1,
                sec1, min2, sec2, true, turnPlayer1, turnPlayer2,
                chot_1, chot_2, tuong_1, tuong_2, ma_1, ma_2, xe_1, xe_2, Hau_1, Hau_2,
                Vua_1, Vua_2, Play, Man_che);

            seats.setEnabled();

            chot_1.Content = GlobalItem.numOfWhitePawn;
            chot_2.Content = GlobalItem.numOfBlackPawn;
            tuong_1.Content = GlobalItem.numOfWhiteBishop;
            tuong_2.Content = GlobalItem.numOfBlackBishop;
            ma_1.Content = GlobalItem.numOfWhiteKnight;
            ma_2.Content = GlobalItem.numOfBlackKnight;
            xe_1.Content = GlobalItem.numOfWhiteCastle;
            xe_2.Content = GlobalItem.numOfBlackCastle;
            Hau_1.Content = GlobalItem.numOfWhiteQueen;
            Hau_2.Content = GlobalItem.numOfBlackQueen;
            Vua_1.Content = GlobalItem.numOfWhiteKing;
            Vua_2.Content = GlobalItem.numOfBlackKing;
                        

           

            //seats.startCountdown();
        }

        // Hàm khởi tạo CinemaSeats
        public void initCinemaSeats()
        {
            GlobalItem.dt1 = new System.Windows.Threading.DispatcherTimer();
            GlobalItem.dt2 = new System.Windows.Threading.DispatcherTimer();

            if (GlobalItem.dt1 != null)
            {
                GlobalItem.dt1.Stop();
            }
            if (GlobalItem.dt2 != null)
            {
                GlobalItem.dt2.Stop();
            }

            this.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), GlobalItem.Source)));

            

            seats = new CinemaSeats(8, 8, Ghe, phongcap, min1,
                sec1, min2, sec2, false, turnPlayer1, turnPlayer2,
                chot_1, chot_2, tuong_1, tuong_2, ma_1, ma_2, xe_1, xe_2, Hau_1, Hau_2,
                Vua_1, Vua_2, Play, Man_che);

            

            seats.setEnabled();

            
          
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {//To do
         //Tạm ngưng mọi hành động
            GlobalItem.pauseTime = true;
            seats.setPause(GlobalItem.pauseTime);
            seats.startCountdown();


            //Tiến hành lưu ván đấu
            MatchDTO match = new MatchDTO();
            match.player1 = GlobalItem.IDPlayer1;
            match.player2 = GlobalItem.IDPlayer2;
            match.time1 = seats.getTime(1);
            match.time2 = seats.getTime(2);
            match.turn = GlobalItem.turn;
            match.type = 1;
            match.check = GlobalItem.check;
            match.chessboard = GlobalItem.chessboard;
            match.ate = GlobalItem.ate;


            Save save = new Save(match);
            save.Show();
            
          
            
        }

        private void btnBackToMenu_Click(object sender, RoutedEventArgs e)
        { // Chức năng BACK
            this.Visibility = Visibility.Hidden;
            seats.restartResource();
            Ghe.IsEnabled = true;
            seats.back_event();
            Man_che.Visibility = Visibility.Hidden;
            //GlobalItem.globalMin=

        }        

       
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            // nut pause
            btnPause.Visibility = Visibility.Hidden;
            btnResume.Visibility = Visibility.Visible;

            //code
            GlobalItem.pauseTime = true;
            seats.setPause(GlobalItem.pauseTime);
            seats.startCountdown();
        }

        private void btnResume_Click(object sender, RoutedEventArgs e)
        {
            // nut resume
            btnResume.Visibility = Visibility.Hidden;
            btnPause.Visibility = Visibility.Visible;

            //code
            GlobalItem.pauseTime = false;
            seats.setPause(GlobalItem.pauseTime);
            seats.startCountdown();

        }
    }

    //--------------------------------------------------------------------------------------------------------------------------------
    public class cell
    {
        private int dong;
        private int cot;
        private int type; //1: co trang -1: co den 0: khong co co
        private string link_img;
        private string kind;
        private int ordinal;//xem luot di thu may cua 1 quan
        private int en_passant = 0;//kiem tra chot an qua duong
        private int turn;//luot di thu may cua con co

        public int getTurn() { return turn; }
        public void setTurn(int n) { turn = n; }
        public int getEnpassant() { return en_passant; }
        public void setEmpassant(int n) { en_passant = n; }
        public int getOrdinal() { return ordinal; }
        public void setOrdinal(int n) { ordinal = n; }
        public int getCot() { return cot; }
        public int getDong() { return dong; }
        public int getType() { return type; }
        public string getLinkImg() { return link_img; }
        public string getKind() { return kind; }
        public void setDong(int new_dong) { dong = new_dong; }
        public void setCot(int newCot) { cot = newCot; }
        public void setType(int n) { type = n; }
        public void setLinkImg(string newlink)
        {
            link_img = newlink;
        }
        public cell(int _dong, int _cot)
        {
            dong = _dong;
            cot = _cot;
            link_img = "";
        }
        public void setKind(string s) { kind = s; }
    }
    //-------------------------------------------------------------------------------------------------------------------------
    public class boardChess
    {
        public cell[,] board;

        public boardChess(int dongB, int cotB)
        {
            board = new cell[dongB, cotB];
            for (int i = 0; i < dongB; i++)
            {
                for (int j = 0; j < cotB; j++)
                {
                    cell temp_cell = new cell(i, j);
                    temp_cell.setCot(i);
                    temp_cell.setDong(i);
                    temp_cell.setTurn(0);
                    if (i == 0)
                    {
                        if (j == 0 || j == 7)
                        {
                            temp_cell.setLinkImg("Source/Chess/8.png");
                            temp_cell.setKind("castle");
                        }

                        else if (j == 1 || j == 6)
                        {
                            temp_cell.setLinkImg("Source/Chess/4.png");
                            temp_cell.setKind("knight");
                        }
                        else if (j == 2 || j == 5)
                        {
                            temp_cell.setLinkImg("Source/Chess/6.png");
                            temp_cell.setKind("bishop");
                        }

                        else if (j == 3)
                        {
                            temp_cell.setLinkImg("Source/Chess/10.png");
                            temp_cell.setKind("queen");
                        }
                        else
                        {
                            temp_cell.setLinkImg("Source/Chess/12.png");
                            temp_cell.setKind("king");
                        }
                        temp_cell.setType(-1);
                    }
                    else if (i == 1)
                    {
                        temp_cell.setLinkImg("Source/Chess/2.png");
                        temp_cell.setKind("pawn");
                        temp_cell.setType(-1);
                    }
                    else if (i == 6)
                    {
                        temp_cell.setLinkImg("Source/Chess/1.png");
                        temp_cell.setKind("pawn");
                        temp_cell.setType(1);
                    }
                    else if (i == 7)
                    {
                        if (j == 0 || j == 7)
                        {
                            temp_cell.setLinkImg("Source/Chess/7.png");
                            temp_cell.setKind("castle");
                        }

                        else if (j == 1 || j == 6)
                        {
                            temp_cell.setLinkImg("Source/Chess/3.png");
                            temp_cell.setKind("knight");
                        }
                        else if (j == 2 || j == 5)
                        {
                            temp_cell.setLinkImg("Source/Chess/5.png");
                            temp_cell.setKind("bishop");
                        }

                        else if (j == 3)
                        {
                            temp_cell.setLinkImg("Source/Chess/9.png");
                            temp_cell.setKind("queen");
                        }
                        else
                        {
                            temp_cell.setLinkImg("Source/Chess/11.png");
                            temp_cell.setKind("king");
                        }
                        temp_cell.setType(1);
                    }
                    else
                    {
                        //o trong
                        temp_cell.setLinkImg("");
                        temp_cell.setKind("");
                        temp_cell.setType(0);
                    }
                    temp_cell.setOrdinal(0);
                    board[i, j] = temp_cell;

                }

            }
        }

        public boardChess()
        {
            board = new cell[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    cell temp_cell = new cell(i, j);
                    temp_cell.setCot(i);
                    temp_cell.setDong(i);
                    temp_cell.setLinkImg("");
                    temp_cell.setKind("");
                    temp_cell.setType(0);
                    temp_cell.setOrdinal(0);
                    board[i, j] = temp_cell;
                }
            }
        }


        public void loadMatch()
        {
            int countForCheck = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    cell temp_cell = new cell(i, j);
                    temp_cell.setCot(i);
                    temp_cell.setDong(i);
                    temp_cell.setTurn(1);
                    if (GlobalItem.chessboard[i*8+j] == 'M')
                    {
                        temp_cell.setLinkImg("Source/Chess/12.png");
                        temp_cell.setKind("king");
                        temp_cell.setType(-1);
                        temp_cell.setTurn(GlobalItem.check[countForCheck] - '0');
                        countForCheck++;
                    }
                    else if (GlobalItem.chessboard[i * 8 + j] == 'L')
                    {
                        temp_cell.setLinkImg("Source/Chess/10.png");
                        temp_cell.setKind("queen");
                        temp_cell.setType(-1);
                    }
                    else if (GlobalItem.chessboard[i * 8 + j] == 'K')
                    {
                        temp_cell.setLinkImg("Source/Chess/8.png");
                        temp_cell.setKind("castle");
                        temp_cell.setType(-1);
                        temp_cell.setTurn(GlobalItem.check[countForCheck] - '0');
                        countForCheck++;
                    }
                    else if (GlobalItem.chessboard[i * 8 + j] == 'J')
                    {
                        temp_cell.setLinkImg("Source/Chess/4.png");
                        temp_cell.setKind("knight");
                        temp_cell.setType(-1);
                    }
                    else if (GlobalItem.chessboard[i * 8 + j] == 'I')
                    {
                        temp_cell.setLinkImg("Source/Chess/6.png");
                        temp_cell.setKind("bishop");
                        temp_cell.setType(-1);
                    }
                    else if (GlobalItem.chessboard[i * 8 + j] == 'H')
                    {
                        temp_cell.setLinkImg("Source/Chess/2.png");
                        temp_cell.setKind("pawn");
                        temp_cell.setType(-1);
                    }
                    else if (GlobalItem.chessboard[i * 8 + j] == 'F')
                    {
                        temp_cell.setLinkImg("Source/Chess/1.png");
                        temp_cell.setKind("pawn");
                        temp_cell.setType(1);
                    }
                    else if (GlobalItem.chessboard[i * 8 + j] == 'E')
                    {
                        temp_cell.setLinkImg("Source/Chess/5.png");
                        temp_cell.setKind("bishop");
                        temp_cell.setType(1);
                    }
                    else if (GlobalItem.chessboard[i * 8 + j] == 'D')
                    {
                        temp_cell.setLinkImg("Source/Chess/3.png");
                        temp_cell.setKind("knight");
                        temp_cell.setType(1);
                    }
                    else if (GlobalItem.chessboard[i * 8 + j] == 'C')
                    {
                        temp_cell.setLinkImg("Source/Chess/7.png");
                        temp_cell.setKind("castle");
                        temp_cell.setType(1);
                        temp_cell.setTurn(GlobalItem.check[countForCheck] - '0');
                        countForCheck++;
                    }
                    else if (GlobalItem.chessboard[i * 8 + j] == 'B')
                    {
                        temp_cell.setLinkImg("Source/Chess/9.png");
                        temp_cell.setKind("queen");
                        temp_cell.setType(1);
                    }
                    else if (GlobalItem.chessboard[i * 8 + j] == 'A')
                    {
                        temp_cell.setLinkImg("Source/Chess/11.png");
                        temp_cell.setKind("king");
                        temp_cell.setType(1);
                        temp_cell.setTurn(GlobalItem.check[countForCheck] - '0');
                        countForCheck++;
                    }
                    else
                    {
                        //o trong
                        temp_cell.setLinkImg("");
                        temp_cell.setKind("");
                        temp_cell.setType(0);
                    }
                    temp_cell.setOrdinal(0);
                    board[i, j] = temp_cell;

                }

            }
        }

    }


    //----------------------------------------------------------------------------------------------------------------------------------------------
    public class Seat
    {
        private Button bt_seat;
        private int row_id;
        private int col_id;

        private bool isPreview = false;
        private string link;
        private string kind;
        private int type;
        private int ordinal;
        private int turn;//luot di thu may cua con co

        public int getTurn() { return turn; }
        public void setTurn(int n) { turn = n; }
        private int en_passant = 0;//kiem tra chot an qua duong
        public int getEnpassant() { return en_passant; }
        public void setEmpassant(int n) { en_passant = n; }

        public void setRowID(int row)
        {
            row_id = row;

        }

        public void setColID(int col)
        {
            col_id = col;
        }

        //public void setRowChar(int value)
        //{
        //    row_char = (char)(value + 65);
        //}

        //public void setRowChar(char value)
        //{
        //    row_char = value;
        //}

        //public void setStateEmpty(bool is_empty) { isEmpty = is_empty; }

        public void setStatePreview(bool is_preview) { isPreview = is_preview; }

        public int getOrdinal() { return ordinal; }
        public void setOrdinal(int n) { ordinal = n; }

        public int getRowID() { return row_id; }

        public int getColID() { return col_id; }

        public bool IsPreview() { return isPreview; }

        public string getLink() { return link; }

        public void setLink(string newlink) { link = newlink; }

        public string getKind() { return kind; }

        public int getType() { return type; }

        public void setKind(string s) { kind = s; }

        public void setType(int n) { type = n; }

        public Seat(int row, int col, string s_link)
        {
            bt_seat = new Button();
            setLink(s_link);
            bt_seat.Height = 80;
            bt_seat.Width = 79.25;

            if ((row + col) % 2 == 0)
            {
                bt_seat.Background = GlobalItem.typePlayer1;
            }
            else
            {
                bt_seat.Background = GlobalItem.typePlayer2;
            }

            if (s_link != "")
            {
                bt_seat.Content = new Image
                {
                    Source = new BitmapImage(new Uri(s_link,UriKind.Relative))
                    //,VerticalAlignment = VerticalAlignment.Center
                };

            }
            else
            {
                bt_seat.Content = "";
            }


        }

        public Button getButtonSeat()
        {
            return bt_seat;
        }


    }
    //----------------------------------------------------------------------------------------------------------------------------------------

    public class CinemaSeats
    {
        private Seat[,] arraySeats;
        private int rows = 0;
        private int cols = 0;

        // Grid
        private Grid p;

        private WrapPanel wp_seats;
        private WrapPanel phonghau;
        private boardChess banco;
        private ArrayButton arrayButton;
        private Label minwhite, minblack, secwhite, secblack;

        // 2 label hiện thị xem lượt cảu bên nào
        private Border turnPlayer1;
        private Border turnPlayer2;

        //Các label hiễn thị số lượng quân cờ bị ăn
        private Label WhitePawn;
        private Label BlackPawn;
        private Label WhiteBishop;
        private Label BlackBishop;
        private Label WhiteKnight;
        private Label BlackKnight;
        private Label WhiteCastle;
        private Label BlackCastle;
        private Label WhiteQueen;
        private Label BlackQueen;
        private Label WhiteKing;
        private Label BlackKing;

        public arrayRadioPlus arrRadio;
        int intMin1, second1, intMin2, second2;

        // sound
        private SoundPlayer sound = new SoundPlayer("buttonbeep.wav");
        private SoundPlayer victory = new SoundPlayer("applause.wav");

        bool choose = false;
        bool pick = true;//kiem tra toi luot co trang hay den
        int[,] recallmove = new int[30, 2];
        int recallspt = 0;
        string temp_link = "", temp_kind = "";
        int temp_type, temp_ordinal, luotdi = 1, temp_col, temp_turn, nhapthanh = 0;
        Button bt1;
        bool win1 = false, win2 = false;
        bool stop = false, save =false;
                
        // Vị trí hàng và cột của nước đi trước
        int pre_i = 0;
        int pre_j = 0;

        // Man2 che
        private Rectangle man_che;

        //kiem tra xem co nam trong nhung o duoc di hay ko
        public bool checkMove(int[,] arr, int row, int col, int spt)
        {
            for (int i = 0; i < spt; i++)
            {
                if (arr[i, 0] == row && arr[i, 1] == col)
                    return true;
            }
            return false;
        }

        // Xử lý Back button
        public void back_event()
        {
            wp_seats.Children.Clear();
            GlobalItem.dt1.Stop();
            GlobalItem.dt2.Stop();
            
        }

        public CinemaSeats(int _rows, int _cols, WrapPanel wpseats, WrapPanel wpphonghau,
            Label min1, Label sec1, Label min2, Label sec2, bool CreateOrLoad,
            Border turn1, Border turn2, Label numWhitePawn, Label numBlackPawn,
            Label numWhiteBishop, Label numBlackBishop, Label numWhiteKnight, Label numBlackKnight,
            Label numWhiteCastle, Label numBlackCastle, Label numWhiteQueen, Label numBlackQueen,
            Label numWhiteKing, Label numBlackKing, Grid Play, Rectangle hidden_mask)//create= false load =true
        {

            // Load sound
            sound.Load();
            victory.Load();

            // Ánh xạ từ lớp Playground window
            rows = _rows;
            cols = _cols;
            wp_seats = wpseats;
            minwhite = min1;
            secwhite = sec1;
            minblack = min2;
            secblack = sec2;
            /*
            if(wp_seats.IsEnabled == false)
            {
                wp_seats.IsEnabled = true;
            }
            */
            // Ánh xạ Grid play
            p = Play;


            if(p.IsEnabled == false)
            {
                p.IsEnabled = true;
            }

            // ---------------------------------------------------
            if (CreateOrLoad == false)
            {
                second1 = int.Parse(sec1.Content.ToString());
                GlobalItem.tempsec1 = second1;
                second2 = int.Parse(sec2.Content.ToString());
                GlobalItem.tempsec2 = second2;
            }
            else
            {// Do nothing
            //    second1 = GlobalItem.time1 % 60;
            //    tempsec1 = second1;
            //    second2 = GlobalItem.time2 % 60;
            }
            // -------------------------------------------------------

            man_che = hidden_mask;

            // Hai border để xác định xem đến lượt ai
            turnPlayer1 = turn1;
            turnPlayer2 = turn2;

            // Ánh xạ các Label số quân cờ bị ăn từ màn hình chính
            WhitePawn = numWhitePawn;
            BlackPawn = numBlackPawn;
            WhiteBishop = numWhiteBishop;
            BlackBishop = numBlackBishop;
            WhiteKnight = numWhiteKnight;
            BlackKnight = numBlackKnight;
            WhiteCastle = numWhiteCastle;
            BlackCastle = numBlackCastle;
            WhiteQueen = numWhiteQueen;
            BlackQueen = numBlackQueen;
            WhiteKing = numWhiteKing;
            BlackKing = numBlackKing;

            if (CreateOrLoad == false)
            {
                banco = new boardChess(8, 8);
            }
            else
            {
                banco = new boardChess();
                banco.loadMatch();



                minwhite.Content = GlobalItem.time1 / 60;
                secwhite.Content = GlobalItem.time1 % 60;
                minblack.Content = GlobalItem.time2 / 60;
                secblack.Content = GlobalItem.time2 % 60;

                intMin1 = GlobalItem.time1 / 60;
                second1 = GlobalItem.time1 % 60;
                GlobalItem.tempsec1 = second1;

                intMin2 = GlobalItem.time2 / 60;
                second2 = GlobalItem.time2 % 60;
                GlobalItem.tempsec2 = second2;
                //chua lam dc
            }

            //cap nhat pick va 2 border
            if (CreateOrLoad == true)
            {
                if (GlobalItem.turn == 0)// 0 = load 1 = create
                {
                    pick = true;
                    stop = false;
                    turnPlayer1.Background = Brushes.GreenYellow;
                    turnPlayer2.Background = Brushes.Transparent;
                    Countdown1(second1, TimeSpan.FromSeconds(1), cur => secwhite.Content = cur.ToString(), minwhite, GlobalItem.dt1);
                    GlobalItem.pre = -4;
                }
                else
                {
                    pick = false;
                    stop = true;
                    turnPlayer2.Background = Brushes.GreenYellow;
                    turnPlayer1.Background = Brushes.Transparent;
                    Countdown2(second2, TimeSpan.FromSeconds(1), cur => secblack.Content = cur.ToString(), minblack, GlobalItem.dt2);
                    GlobalItem.pre = -4;
                }
            }
            else
            {
                pick = true;
                stop = false;
                turnPlayer1.Background = Brushes.GreenYellow;
                turnPlayer2.Background = Brushes.Transparent;
                Countdown1(second1, TimeSpan.FromSeconds(1), cur => secwhite.Content = cur.ToString(), minwhite, GlobalItem.dt1);
                GlobalItem.pre = -4;
            }

            phonghau = wpphonghau;
            arraySeats = new Seat[rows, cols];
            
            arrayButton = new ArrayButton(8, 8);

            //int mex_element_row = WINDOW_WIDTH - Convert.ToInt32(wpseats.Margin.Left) - Convert.ToInt32(wpseats.Margin.Right);
            //ham khoi tao
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    string s_link = banco.board[i, j].getLinkImg();
                    string s_kind = banco.board[i, j].getKind();
                    int s_type = banco.board[i, j].getType();
                    int s_ordinal = banco.board[i, j].getOrdinal();
                    int s_turn = banco.board[i, j].getTurn();

                    Seat _tempseat = new Seat(i, j, s_link);
                    _tempseat.setColID(j);
                    //_tempseat.setRowChar(i);
                    _tempseat.setRowID(i);
                    _tempseat.setLink(s_link);
                    _tempseat.setKind(s_kind);
                    _tempseat.setType(s_type);
                    _tempseat.setOrdinal(s_ordinal);
                    _tempseat.setTurn(s_turn);

                    arraySeats[i, j] = _tempseat;
                    arraySeats[i, j].getButtonSeat().Tag = arraySeats[i, j];
                    arraySeats[i, j].getButtonSeat().Click += new RoutedEventHandler(clickEvent);

                    arrayButton.array[i, j] = arraySeats[i, j].getButtonSeat();

                    //seats[i, j].getSeat().MouseDown += new MouseEventHandler(

                    wp_seats.Children.Add(arraySeats[i, j].getButtonSeat());

                }

            }
        }

        // Hàm đếm ngược thời gian
        public void startCountdown()
        {
            if (GlobalItem.turn == 0)
            {
                second1 = GlobalItem.tempsec1;

                Countdown1(second1, TimeSpan.FromSeconds(1), cur => secwhite.Content = cur.ToString(), minwhite, GlobalItem.dt1);
                GlobalItem.pre = -4;

            }
            else
            {
                second2 = GlobalItem.tempsec2;
                Countdown2(second2, TimeSpan.FromSeconds(1), cur => secblack.Content = cur.ToString(), minblack, GlobalItem.dt2);
                GlobalItem.pre = -4;
            }
        }

        private void clickEvent(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            chessMove move;
            Seat seat = (Seat)btn.Tag;
            int i = seat.getRowID();
            int j = seat.getColID();
            seat = arraySeats[i, j];

            if (GlobalItem.isAudio == true)
            {
                sound.Play();
            }

            // Biến kiểm tra xem có phải chọn quân khác không
            bool isClickAnother = false;
            do // Thêm dòng do .. while .. vào để tao vòng xoay, tận dụng lại cái hàm hiển thị các nút preview
            {
                if (choose == false || isClickAnother == true)//da chon 1 quan co hay chua
                {

                    if (pick == true)// luot co trang di
                    {
                        if (seat.getType() != 1)//co trang
                        {
                            // Vì là pick cờ đen nên sẽ không có gì hết
                        }
                        else
                        {
                            if (arraySeats[i, j].IsPreview() == false)
                            {
                                pre_i = i;
                                pre_j = j;

                                arrayButton.array[i, j].Background = Brushes.LightBlue;

                                temp_link = arraySeats[i, j].getLink();
                                temp_kind = arraySeats[i, j].getKind();
                                temp_type = arraySeats[i, j].getType();
                                temp_ordinal = arraySeats[i, j].getOrdinal();
                                temp_col = arraySeats[i, j].getColID();
                                temp_turn = arraySeats[i, j].getTurn();

                                arrayButton.array[i, j] = btn;

                                bt1 = btn;
                                bt1.Tag = arraySeats[i, j];
                                move = new chessMove(seat, arraySeats);

                                for (int t = 0; t < move.getSPT(); t++)
                                {
                                    int u = move.getPT(t, 0);
                                    int v = move.getPT(t, 1);
                                    recallmove[t, 0] = u;
                                    recallmove[t, 1] = v;
                                    recallspt++;
                                    arrayButton.array[u, v].Background = Brushes.LightBlue;

                                }
                                if (arraySeats[i, j].getKind() == "king" && arraySeats[i, j].getTurn() == 0)
                                {
                                    if (arraySeats[7, 7].getKind() == "castle" && arraySeats[i, j].getTurn() == 0)
                                    {
                                        if (arraySeats[7, 6].getType() == 0 && arraySeats[7, 5].getType() == 0)
                                        {
                                            recallmove[recallspt, 0] = 7;
                                            recallmove[recallspt, 1] = 6;
                                            recallspt++;
                                            nhapthanh++;
                                            arrayButton.array[7, 6].Background = Brushes.LightBlue;
                                        }
                                    }
                                }
                                if (arraySeats[i, j].getKind() == "king" && arraySeats[i, j].getTurn() == 0)
                                {
                                    if (arraySeats[0, 7].getKind() == "castle" && arraySeats[i, j].getTurn() == 0)
                                    {
                                        if (arraySeats[7, 1].getType() == 0 && arraySeats[7, 2].getType() == 0 && arraySeats[7, 3].getType() == 0)
                                        {
                                            recallmove[recallspt, 0] = 7;
                                            recallmove[recallspt, 1] = 2;
                                            recallspt++;
                                            nhapthanh++;
                                            arrayButton.array[7, 2].Background = Brushes.LightBlue;
                                        }
                                    }
                                }
                            }

                            else
                            {

                            }
                            arraySeats[i, j].setStatePreview(!arraySeats[i, j].IsPreview());
                            choose = true;
                        }

                    }
                    else
                    {

                        if (seat.getType() != -1)//co den
                        {

                        }
                        else
                        {
                            if (arraySeats[i, j].IsPreview() == false)
                            {
                                pre_i = i;
                                pre_j = j;

                                arrayButton.array[i, j] = btn;
                                arrayButton.array[i, j].Background = Brushes.LightBlue;

                                temp_link = arraySeats[i, j].getLink();
                                temp_kind = arraySeats[i, j].getKind();
                                temp_type = arraySeats[i, j].getType();
                                temp_ordinal = arraySeats[i, j].getOrdinal();
                                temp_col = arraySeats[i, j].getColID();


                                arrayButton.array[i, j] = btn;

                                bt1 = btn;
                                bt1.Tag = arraySeats[i, j];
                                move = new chessMove(seat, arraySeats);
                                for (int t = 0; t < move.getSPT(); t++)
                                {
                                    int u = move.getPT(t, 0);
                                    int v = move.getPT(t, 1);
                                    recallmove[t, 0] = u;
                                    recallmove[t, 1] = v;
                                    recallspt++;
                                    arrayButton.array[u, v].Background = Brushes.LightBlue;

                                }
                                if (arraySeats[i, j].getKind() == "king" && arraySeats[i, j].getTurn() == 0)
                                {
                                    if (arraySeats[0, 7].getKind() == "castle" && arraySeats[i, j].getTurn() == 0)
                                    {
                                        if (arraySeats[0, 6].getType() == 0 && arraySeats[0, 5].getType() == 0)
                                        {
                                            recallmove[recallspt, 0] = 0;
                                            recallmove[recallspt, 1] = 6;
                                            recallspt++;
                                            arrayButton.array[0, 6].Background = Brushes.LightBlue;
                                            nhapthanh++;
                                        }
                                    }
                                }
                                if (arraySeats[i, j].getKind() == "king" && arraySeats[i, j].getTurn() == 0)
                                {
                                    if (arraySeats[0, 0].getKind() == "castle" && arraySeats[i, j].getTurn() == 0)
                                    {
                                        if (arraySeats[0, 1].getType() == 0 && arraySeats[0, 2].getType() == 0 && arraySeats[0, 3].getType() == 0)
                                        {
                                            recallmove[recallspt, 0] = 0;
                                            recallmove[recallspt, 1] = 2;
                                            recallspt++;
                                            arrayButton.array[0, 2].Background = Brushes.LightBlue;
                                            nhapthanh++;
                                        }
                                    }
                                }
                            }

                            else
                            {

                            }
                            arraySeats[i, j].setStatePreview(!arraySeats[i, j].IsPreview());
                            choose = true;
                        }
                    }

                    isClickAnother = false;
                }
                else
                {
                    if (arraySeats[i, j].IsPreview() == true)
                    {
                        // Chỉnh lại Background cho nút trước đó
                        if ((i + j) % 2 == 0)
                        {
                            arrayButton.array[i, j].Background = GlobalItem.typePlayer1;
                        }
                        else
                        {
                            arrayButton.array[i, j].Background = GlobalItem.typePlayer2;
                        }

                        // Chỉnh lại chế độ chọn của quân cờ
                        arraySeats[i, j].setStatePreview(!arraySeats[i, j].IsPreview());

                        // Chỉnh lại Background cho các nút preview
                        for (int t = 0; t < recallspt; t++)
                        {
                            int u = recallmove[t, 0];
                            int v = recallmove[t, 1];
                            //arrayButton.array[u, v].Background = Brushes.Transparent;
                            if ((u + v) % 2 == 0)
                            {
                                arrayButton.array[u, v].Background = GlobalItem.typePlayer1;
                            }
                            else
                            {
                                arrayButton.array[u, v].Background = GlobalItem.typePlayer2;
                            }
                        }
                        recallspt = 0;

                        choose = false;


                    }
                    else
                    {
                        Seat seat1 = (Seat)bt1.Tag;

                        if (seat.getType() == seat1.getType())
                        {
                            // chon quan co khac
                            // Chỉnh lại background của quan co duoc chon truoc do
                            if ((pre_i + pre_j) % 2 == 0)
                            {
                                arrayButton.array[pre_i, pre_j].Background = GlobalItem.typePlayer1;
                            }
                            else
                            {
                                arrayButton.array[pre_i, pre_j].Background = GlobalItem.typePlayer2;
                            }

                            arraySeats[pre_i, pre_j].setStatePreview(!arraySeats[pre_i, pre_j].IsPreview());

                            for (int t = 0; t < recallspt; t++)
                            {
                                int u = recallmove[t, 0];
                                int v = recallmove[t, 1];

                                if ((u + v) % 2 == 0)
                                {
                                    arrayButton.array[u, v].Background = GlobalItem.typePlayer1;
                                }
                                else
                                {
                                    arrayButton.array[u, v].Background = GlobalItem.typePlayer2;
                                }
                            }
                            recallspt = 0;

                            isClickAnother = true;
                        }
                        else if (checkMove(recallmove, seat.getRowID(), seat.getColID(), recallspt) == false)
                        {
                            // neu nhan ben ngoai se k lam gi het
                        }
                        else
                        {
                             // Hiển thị đến lượt ai
                            if (pick == false)
                            {
                                // Hiển thị cờ trắng đi
                                turnPlayer1.Background = Brushes.GreenYellow;
                                turnPlayer2.Background = Brushes.Transparent;
                            }
                            else
                            {
                                // Hiển thị cờ đen đi
                                turnPlayer2.Background = Brushes.GreenYellow;
                                turnPlayer1.Background = Brushes.Transparent;
                            }


                                // Xét loại quân cờ để cập nhật vào bảng điểm
                                if (seat.getKind() == "king")
                            {
                                if (seat.getType() == 1)
                                {
                                    GlobalItem.numOfBlackKing++;
                                    BlackKing.Content = GlobalItem.numOfBlackKing.ToString();
                                    win2 = true;
                                }
                                else
                                {
                                    GlobalItem.numOfBlackKing++;
                                    BlackKing.Content = GlobalItem.numOfBlackKing.ToString();
                                    win1 = true;
                                }
                            }
                            else if (seat.getKind() == "pawn")
                            {
                                if (seat.getType() == 1)
                                {
                                    GlobalItem.numOfBlackPawn++;
                                    BlackPawn.Content = GlobalItem.numOfBlackPawn.ToString();
                                }
                                else
                                {
                                    GlobalItem.numOfWhitePawn++;
                                    WhitePawn.Content = GlobalItem.numOfWhitePawn.ToString();
                                }
                            }
                            else if (seat.getKind() == "bishop")
                            {
                                if (seat.getType() == 1)
                                {
                                    GlobalItem.numOfBlackBishop++;
                                    BlackBishop.Content = GlobalItem.numOfBlackBishop.ToString();
                                }
                                else
                                {
                                    GlobalItem.numOfWhiteBishop++;
                                    WhiteBishop.Content = GlobalItem.numOfWhiteBishop.ToString();
                                }
                            }
                            else if (seat.getKind() == "knight")
                            {
                                if (seat.getType() == 1)
                                {
                                    GlobalItem.numOfBlackKnight++;
                                    BlackKnight.Content = GlobalItem.numOfBlackKnight.ToString();
                                }
                                else
                                {
                                    GlobalItem.numOfWhiteKnight++;
                                    WhiteKnight.Content = GlobalItem.numOfWhiteKnight.ToString();
                                }
                            }
                            else if (seat.getKind() == "castle")
                            {
                                if (seat.getType() == 1)
                                {
                                    GlobalItem.numOfBlackCastle++;
                                    BlackCastle.Content = GlobalItem.numOfBlackCastle.ToString();
                                }
                                else
                                {
                                    GlobalItem.numOfWhiteCastle++;
                                    WhiteCastle.Content = GlobalItem.numOfWhiteCastle.ToString();
                                }
                            }
                            else if (seat.getKind() == "Queen")
                            {
                                if (seat.getType() == 1)
                                {
                                    GlobalItem.numOfBlackQueen++;
                                    BlackQueen.Content = GlobalItem.numOfBlackQueen.ToString();
                                }
                                else
                                {
                                    GlobalItem.numOfWhiteQueen++;
                                    WhiteQueen.Content = GlobalItem.numOfWhiteQueen.ToString();
                                }
                            }
                            else
                            {
                                // Do nothing
                            }


                            // Thay thế quân cờ khi ăn
                            seat.setLink(temp_link);
                            seat.setKind(temp_kind);
                            seat.setType(temp_type);
                            seat.setOrdinal(temp_ordinal + 1);
                            seat.setTurn(temp_turn + 1);
                            //if(seat.getColID()-temp_col==2)
                            //{
                            //    seat.setEmpassant(luotdi - 1);
                            //}



                            arraySeats[i, j] = seat;
                            arraySeats[i, j].getButtonSeat().Tag = arraySeats[i, j];

                            //btn.Content = new Image
                            arrayButton.array[i, j].Content = new Image
                            {
                                Source = new BitmapImage(new Uri(temp_link, UriKind.Relative))
                                //,VerticalAlignment = VerticalAlignment.Center
                            };

                            int i1 = seat1.getRowID();
                            int j1 = seat1.getColID();
                            seat1.setLink("");
                            seat1.setKind("");
                            seat1.setType(0);
                            seat1.setTurn(0);
                            arraySeats[i1, j1] = seat1;
                            arraySeats[i1, j1].getButtonSeat().Tag = arraySeats[i1, j1];
                            //bt1.Content = "";
                            //bt1.Background = Brushes.Transparent;
                            arrayButton.array[i1, j1].Content = "";
                            //arrayButton.array[i1, j1].Background = Brushes.Transparent;
                            if ((i1 + j1) % 2 == 0)
                            {
                                arrayButton.array[i1, j1].Background = GlobalItem.typePlayer1;
                            }
                            else
                            {
                                arrayButton.array[i1, j1].Background = GlobalItem.typePlayer2;
                            }

                            arraySeats[i1, j1].setStatePreview(!arraySeats[i1, j1].IsPreview());

                            //arrayButton.array[i, j] = btn;
                            //arrayButton.array[i1, j1] = bt1;
                            for (int t = 0; t < recallspt; t++)
                            {
                                int u = recallmove[t, 0];
                                int v = recallmove[t, 1];


                                // arrayButton.array[u, v].Background = Brushes.Transparent;
                                if ((u + v) % 2 == 0)
                                {
                                    arrayButton.array[u, v].Background = GlobalItem.typePlayer1;
                                }
                                else
                                {
                                    arrayButton.array[u, v].Background = GlobalItem.typePlayer2;
                                }
                            }
                            recallspt = 0;

                            //phong hau
                            if (seat.getKind() == "pawn" && win1 == false && win2 ==false)
                            {
                                if (seat.getType() == 1 && seat.getRowID() == 0)
                                {
                                    phonghau.Visibility = Visibility.Visible;
                                    wp_seats.IsEnabled = false;
                                    string[] imgWhite = new string[4];
                                    imgWhite[0] = "Source/Chess/9.png";
                                    imgWhite[1] = "Source/Chess/7.png";
                                    imgWhite[2] = "Source/Chess/5.png";
                                    imgWhite[3] = "Source/Chess/3.png";
                                    arrRadio = new arrayRadioPlus();
                                    for (int t = 0; t < 4; t++)
                                    {
                                        RadioButton temp = new RadioButton();
                                        temp.Content = new Image
                                        {
                                            Source = new BitmapImage(new Uri(imgWhite[t], UriKind.Relative))
                                        };
                                        temp.Height = 100;
                                        temp.Width = 100;



                                        arrRadio.a[t].radio = temp;
                                        arrRadio.a[t].setCap(t);
                                        arrRadio.a[t].setRow(i);
                                        arrRadio.a[t].setCol(j);
                                        arrRadio.a[t].setLoai(1);
                                        temp.Tag = arrRadio.a[t];
                                        //temp.Tag = arraySeats[i, j];
                                        temp.Checked += new RoutedEventHandler(checkEvent);
                                        phonghau.Children.Add(temp);
                                    }
                                    // Khoảng trống
                                    Rectangle space = new Rectangle();
                                    space.Height = 20;
                                    space.Width = 200;
                                    space.Fill = Brushes.Transparent;
                                    phonghau.Children.Add(space);

                                    Button btnOK = new Button();
                                    btnOK.Content = "Phong cap";
                                    btnOK.Background = Brushes.LawnGreen;
                                    btnOK.Height = 50;
                                    btnOK.Width = 200;
                                    btnOK.Click += new RoutedEventHandler(click_OK);
                                    phonghau.Children.Add(btnOK);


                                }
                                else if (seat.getType() == -1 && seat.getRowID() == 7)
                                {
                                    phonghau.Visibility = Visibility.Visible;
                                    wp_seats.IsEnabled = false;
                                    string[] imgWhite = new string[4];
                                    imgWhite[0] = "Source/Chess/10.png";
                                    imgWhite[1] = "Source/Chess/8.png";
                                    imgWhite[2] = "Source/Chess/6.png";
                                    imgWhite[3] = "Source/Chess/4.png";
                                    arrRadio = new arrayRadioPlus();
                                    for (int t = 0; t < 4; t++)
                                    {
                                        RadioButton temp = new RadioButton();
                                        temp.Content = new Image
                                        {
                                            Source = new BitmapImage(new Uri(imgWhite[t],UriKind.Relative))
                                        };
                                        temp.Height = 100;
                                        temp.Width = 100;



                                        arrRadio.a[t].radio = temp;
                                        arrRadio.a[t].setCap(t);
                                        arrRadio.a[t].setRow(i);
                                        arrRadio.a[t].setCol(j);
                                        arrRadio.a[t].setLoai(-1);
                                        temp.Tag = arrRadio.a[t];
                                        //temp.Tag = arraySeats[i, j];
                                        temp.Checked += new RoutedEventHandler(checkEvent);
                                        phonghau.Children.Add(temp);
                                    }
                                    // Khoảng trống
                                    Rectangle space = new Rectangle();
                                    space.Height = 20;
                                    space.Width = 200;
                                    space.Fill = Brushes.Transparent;
                                    phonghau.Children.Add(space);

                                    Button btnOK = new Button();
                                    btnOK.Content = "Phong cap";
                                    btnOK.Background = Brushes.LawnGreen;
                                    btnOK.Height = 50;
                                    btnOK.Width = 200;
                                    btnOK.Click += new RoutedEventHandler(click_OK);
                                    phonghau.Children.Add(btnOK);
                                }

                            }
                            //nhap thanh
                            if (nhapthanh > 0)
                            {
                                if (seat.getColID() == 6)//ben phai
                                {
                                    if (seat.getType() == 1)
                                    {
                                        int row2 = 7, col2 = 5;
                                        Seat seat2 = (Seat)arraySeats[7, 7].getButtonSeat().Tag;
                                        seat2.setTurn(1);
                                        seat2.setRowID(row2);
                                        seat2.setColID(col2);
                                        seat2.setType(1);
                                        arraySeats[row2, col2] = seat2;
                                        arraySeats[row2, col2].getButtonSeat().Tag = arraySeats[row2, col2];
                                        arrayButton.array[row2, col2].Content = new Image
                                        {
                                            Source = new BitmapImage(new Uri(seat2.getLink()))
                                        };

                                        arraySeats[row2, 7] = seat1;
                                        arraySeats[row2, 7].getButtonSeat().Tag = arraySeats[row2, 7];
                                        arrayButton.array[row2, 7].Content = "";
                                        //arrayButton.array[row2, 7].Background = Brushes.Transparent;
                                        if (row2 % 2 != 0)
                                        {
                                            arrayButton.array[row2, 7].Background = GlobalItem.typePlayer1;
                                        }
                                        else
                                        {
                                            arrayButton.array[row2, 7].Background = GlobalItem.typePlayer2;
                                        }
                                    }
                                    else
                                    {
                                        int row2 = 0, col2 = 5;
                                        Seat seat2 = arraySeats[0, 7];
                                        seat2.setTurn(1);
                                        seat2.setType(-1);
                                        seat2.setRowID(row2);
                                        seat2.setColID(col2);
                                        arraySeats[row2, col2] = seat2;
                                        arraySeats[row2, col2].getButtonSeat().Tag = arraySeats[row2, col2];
                                        arrayButton.array[row2, col2].Content = new Image
                                        {
                                            Source = new BitmapImage(new Uri(seat2.getLink()))
                                        };

                                        arraySeats[row2, 7] = seat1;
                                        arraySeats[row2, 7].getButtonSeat().Tag = arraySeats[row2, 7];
                                        arrayButton.array[row2, 7].Content = "";
                                        //arrayButton.array[row2, 7].Background = Brushes.Transparent;
                                        if (row2 % 2 != 0)
                                        {
                                            arrayButton.array[row2, 7].Background = GlobalItem.typePlayer1;
                                        }
                                        else
                                        {
                                            arrayButton.array[row2, 7].Background = GlobalItem.typePlayer2;
                                        }
                                    }
                                    nhapthanh = 0;
                                }
                                else if (seat.getColID() == 2)//ben trai
                                {
                                    if (seat.getType() == 1)
                                    {
                                        int row2 = 7, col2 = 3;
                                        Seat seat2 = arraySeats[7, 0];
                                        seat2.setTurn(1);
                                        seat2.setRowID(row2);
                                        seat2.setColID(col2);
                                        seat2.setType(1);
                                        arraySeats[row2, col2] = seat2;
                                        arraySeats[row2, col2] = seat2;
                                        arraySeats[row2, col2].getButtonSeat().Tag = arraySeats[row2, col2];
                                        arrayButton.array[row2, col2].Content = new Image
                                        {
                                            Source = new BitmapImage(new Uri(seat2.getLink()))
                                        };

                                        arraySeats[row2, 0] = seat1;
                                        arraySeats[row2, 0].getButtonSeat().Tag = arraySeats[row2, 0];
                                        arrayButton.array[row2, 0].Content = "";
                                        //arrayButton.array[row2, 0].Background = Brushes.Transparent;
                                        if (row2 % 2 == 0)
                                        {
                                            arrayButton.array[row2, 0].Background = GlobalItem.typePlayer1;
                                        }
                                        else
                                        {
                                            arrayButton.array[row2, 0].Background = GlobalItem.typePlayer2;
                                        }
                                    }
                                    else
                                    {
                                        int row2 = 0, col2 = 3;
                                        Seat seat2 = arraySeats[0, 0];
                                        seat2.setTurn(1);
                                        seat2.setRowID(row2);
                                        seat2.setColID(col2);
                                        seat2.setType(-1);
                                        arraySeats[row2, col2] = seat2;
                                        arraySeats[row2, col2].getButtonSeat().Tag = arraySeats[row2, col2];
                                        arrayButton.array[row2, col2].Content = new Image
                                        {
                                            Source = new BitmapImage(new Uri(seat2.getLink()))
                                        };

                                        arraySeats[row2, 0] = seat1;
                                        arraySeats[row2, 0].getButtonSeat().Tag = arraySeats[row2, 0];
                                        arrayButton.array[row2, 0].Content = "";
                                        //arrayButton.array[row2, 0].Background = Brushes.Transparent;
                                        if (row2 % 2 == 0)
                                        {
                                            arrayButton.array[row2, 0].Background = GlobalItem.typePlayer1;
                                        }
                                        else
                                        {
                                            arrayButton.array[row2, 0].Background = GlobalItem.typePlayer2;
                                        }
                                    }
                                    nhapthanh = 0;
                                }

                            }


                            choose = false;
                            pick = !pick;
                            luotdi++;
                            stop = !stop;

                           // Cho sua bay
                            second1 = GlobalItem.tempsec1;
                            second2 = GlobalItem.tempsec2;

                            Countdown1(second1, TimeSpan.FromSeconds(1), cur => secwhite.Content = cur.ToString(), minwhite, GlobalItem.dt1);
                            GlobalItem.pre = -4;
                            Countdown2(second2, TimeSpan.FromSeconds(1), cur => secblack.Content = cur.ToString(), minblack, GlobalItem.dt2);
                            GlobalItem.pre = -4;

                            //chien thang
                            if (win1 == true)
                            {
                                GlobalItem.dt1.Stop();
                                GlobalItem.dt2.Stop();
                                if (GlobalItem.isAudio == true)
                                {
                                    victory.Play();
                                }
                                MessageBox.Show("Nguoi choi 1 thang");
                                if (GlobalItem.isAudio == true)
                                {
                                    victory.Stop();
                                }
                                restartResource();
                                man_che.Visibility = Visibility.Visible;

                                //Cap nhat csdl cho 2 nguoi choi
                                UserBUS bus = new UserBUS();
                                bus.playerWin(GlobalItem.IDPlayer1);
                                bus.playerLose(GlobalItem.IDPlayer2);
                            }
                            if (win2 == true)
                            {
                                GlobalItem.dt1.Stop();
                                GlobalItem.dt2.Stop();
                                if (GlobalItem.isAudio == true)
                                {
                                    victory.Play();
                                }
                                MessageBox.Show("Nguoi choi 2 thang");
                                if (GlobalItem.isAudio == true)
                                {
                                    victory.Stop();
                                }
                                restartResource();
                                man_che.Visibility = Visibility.Visible;

                                //Cap nhat csdl cho 2 nguoi choi
                                UserBUS bus = new UserBUS();
                                bus.playerWin(GlobalItem.IDPlayer2);
                                bus.playerLose(GlobalItem.IDPlayer1);
                            }

                        }
                    }

                }
            } while (isClickAnother == true);

            
            if (choose == false)
            {//ket thuc luot di
                if (seat.getType() == 1)
                {// Co72 trang81 di
                    GlobalItem.turn = 1;
                }
                else
                {
                    GlobalItem.turn = 0;
                }
                updateForDB();
            }
        }
        private void updateForDB()
        {
            // Save bàn cờ
            StringBuilder chessboard = new StringBuilder();
            StringBuilder check = new StringBuilder();
            StringBuilder ate = new StringBuilder();

            // Doc5 du7 lieu ban co
            for (int i = 0; i < 8; i++) 
            {
                for (int j = 0; j < 8; j++)
                {
                    if (arraySeats[i,j].getType() == 1)
                    {
                        if (arraySeats[i, j].getKind() == "king")
                        {
                            chessboard.Append("A");
                            if(arraySeats[i,j].getTurn() == 0)
                            {
                                check.Append("0");
                            }
                            else
                            {
                                check.Append("1");
                            }
                        }
                        else if(arraySeats[i, j].getKind() == "queen")
                        {
                            chessboard.Append("B");
                        }
                        else if (arraySeats[i, j].getKind() == "castle")
                        {
                            chessboard.Append("C");

                            if (arraySeats[i, j].getTurn() == 0)
                            {
                                check.Append("0");
                            }
                            else
                            {
                                check.Append("1");
                            }
                        }
                        else if (arraySeats[i, j].getKind() == "knight")
                        {
                            chessboard.Append("D");
                        }
                        else if (arraySeats[i, j].getKind() == "bishop")
                        {
                            chessboard.Append("E");
                        }
                        else
                        {
                            chessboard.Append("F");
                        }
                    }
                    else if(arraySeats[i, j].getType() == -1)
                    {
                        if (arraySeats[i, j].getKind() == "king")
                        {
                            chessboard.Append("M");
                            if (arraySeats[i, j].getTurn() == 0)
                            {
                                check.Append("0");
                            }
                            else
                            {
                                check.Append("1");
                            }
                        }
                        else if (arraySeats[i, j].getKind() == "queen")
                        {
                            chessboard.Append("L");
                        }
                        else if (arraySeats[i, j].getKind() == "castle")
                        {
                            chessboard.Append("K");
                            if (arraySeats[i, j].getTurn() == 0)
                            {
                                check.Append("0");
                            }
                            else
                            {
                                check.Append("1");
                            }
                        }
                        else if (arraySeats[i, j].getKind() == "knight")
                        {
                            chessboard.Append("J");
                        }
                        else if (arraySeats[i, j].getKind() == "bishop")
                        {
                            chessboard.Append("I");
                        }
                        else
                        {
                            chessboard.Append("H");
                        }
                    }
                    else
                    {
                        chessboard.Append("G");
                    }
                }
            }

            // Doc so quan co da an
            ate.Append(GlobalItem.numOfWhitePawn.ToString());
            ate.Append(GlobalItem.numOfBlackPawn.ToString());
            ate.Append(GlobalItem.numOfWhiteBishop.ToString());
            ate.Append(GlobalItem.numOfBlackBishop.ToString());
            ate.Append(GlobalItem.numOfWhiteKnight.ToString());
            ate.Append(GlobalItem.numOfBlackKnight.ToString());
            ate.Append(GlobalItem.numOfWhiteCastle.ToString());
            ate.Append(GlobalItem.numOfBlackCastle.ToString());
            ate.Append(GlobalItem.numOfWhiteQueen.ToString());
            ate.Append(GlobalItem.numOfBlackQueen.ToString());
            ate.Append(GlobalItem.numOfWhiteKing.ToString());
            ate.Append(GlobalItem.numOfBlackKing.ToString());



            GlobalItem.chessboard = chessboard.ToString();
            GlobalItem.check = check.ToString();
            GlobalItem.ate = ate.ToString();

        }


        private void checkEvent(object sender, RoutedEventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            RadioPlus radiio = (RadioPlus)btn.Tag;
            int i = radiio.getrow();
            int j = radiio.getcol();
            int cap = radiio.getCap();
            int loai = radiio.getLoai();
            Seat seat1 = new Seat(i, j, "Source/Chess/10.png");
            if (loai == 1)
            {
                if (cap == 0)
                {
                    seat1.setLink("Source/Chess/9.png");
                    seat1.setKind("queen");
                    seat1.setType(1);
                    seat1.setRowID(i);
                    seat1.setColID(j);
                    arrayButton.array[i, j].Content = new Image
                    {
                        Source = new BitmapImage(new Uri("Source/Chess/9.png", UriKind.Relative))
                    };


                    arraySeats[i, j] = seat1;
                    arraySeats[i, j].getButtonSeat().Tag = arraySeats[i, j];
                }
                else if (cap == 1)
                {

                    seat1.setLink("Source/Chess/7.png");
                    seat1.setKind("castle");
                    seat1.setType(1);
                    seat1.setRowID(i);
                    seat1.setColID(j);
                    arrayButton.array[i, j].Content = new Image
                    {
                        Source = new BitmapImage(new Uri("Source/Chess/7.png", UriKind.Relative))
                    };


                    arraySeats[i, j] = seat1;
                    arraySeats[i, j].getButtonSeat().Tag = arraySeats[i, j];
                }
                else if (cap == 2)
                {

                    seat1.setLink("Source/Chess/5.png");
                    seat1.setKind("bishop");
                    seat1.setType(1);
                    seat1.setRowID(i);
                    seat1.setColID(j);
                    arrayButton.array[i, j].Content = new Image
                    {
                        Source = new BitmapImage(new Uri("Source/Chess/5.png", UriKind.Relative))
                    };


                    arraySeats[i, j] = seat1;
                    arraySeats[i, j].getButtonSeat().Tag = arraySeats[i, j];
                }
                else
                {

                    seat1.setLink("Source/Chess/3.png");
                    seat1.setKind("knight");
                    seat1.setType(1);
                    seat1.setRowID(i);
                    seat1.setColID(j);
                    arrayButton.array[i, j].Content = new Image
                    {
                        Source = new BitmapImage(new Uri("Source/Chess/3.png", UriKind.Relative))
                    };


                    arraySeats[i, j] = seat1;
                    arraySeats[i, j].getButtonSeat().Tag = arraySeats[i, j];
                }
            }
            else
            {
                if (cap == 0)
                {
                    seat1.setLink("Source/Chess/10.png");
                    seat1.setKind("queen");
                    seat1.setType(-1);
                    seat1.setRowID(i);
                    seat1.setColID(j);
                    arrayButton.array[i, j].Content = new Image
                    {
                        Source = new BitmapImage(new Uri("Source/Chess/10.png", UriKind.Relative))
                    };


                    arraySeats[i, j] = seat1;
                    arraySeats[i, j].getButtonSeat().Tag = arraySeats[i, j];
                }
                else if (cap == 1)
                {

                    seat1.setLink("Source/Chess/8.png");
                    seat1.setKind("castle");
                    seat1.setType(-1);
                    seat1.setRowID(i);
                    seat1.setColID(j);
                    arrayButton.array[i, j].Content = new Image
                    {
                        Source = new BitmapImage(new Uri("Source/Chess/8.png", UriKind.Relative))
                    };


                    arraySeats[i, j] = seat1;
                    arraySeats[i, j].getButtonSeat().Tag = arraySeats[i, j];
                }
                else if (cap == 2)
                {

                    seat1.setLink("Source/Chess/6.png");
                    seat1.setKind("bishop");
                    seat1.setType(-1);
                    seat1.setRowID(i);
                    seat1.setColID(j);
                    arrayButton.array[i, j].Content = new Image
                    {
                        Source = new BitmapImage(new Uri("Source/Chess/6.png", UriKind.Relative))
                    };


                    arraySeats[i, j] = seat1;
                    arraySeats[i, j].getButtonSeat().Tag = arraySeats[i, j];
                }
                else
                {

                    seat1.setLink("Source/Chess/4.png");
                    seat1.setKind("knight");
                    seat1.setType(-1);
                    seat1.setRowID(i);
                    seat1.setColID(j);
                    arrayButton.array[i, j].Content = new Image
                    {
                        Source = new BitmapImage(new Uri("Source/Chess/4.png", UriKind.Relative))
                    };


                    arraySeats[i, j] = seat1;
                    arraySeats[i, j].getButtonSeat().Tag = arraySeats[i, j];
                }
            }



        }
        private void click_OK(object sender, RoutedEventArgs e)
        {
            wp_seats.IsEnabled = true;
            phonghau.Visibility = Visibility.Hidden;
            phonghau.Children.Clear();
        }


        public int getSize() { return rows * cols; }

        public int getRows() { return rows; }

        public int getCols() { return cols; }

        public Seat getArraySeat(int row, int col) { return arraySeats[row, col]; }

        public void setEnabled()
        {
            wp_seats.IsEnabled = true;
        }

        public int getTime(int i)
        {
            if(i == 1)
            {
                return intMin1 * 60 + GlobalItem.tempsec1;
            }
            else
            {
                return intMin2 * 60 + GlobalItem.tempsec2;
            }
            
        }
        public void restartResource()
        {
            GlobalItem.pause = false;
            GlobalItem.turn = 0;
            GlobalItem.numOfWhitePawn = 0;
            GlobalItem.numOfBlackPawn = 0;
            GlobalItem.numOfWhiteBishop = 0;
            GlobalItem.numOfBlackBishop = 0;
            GlobalItem.numOfWhiteKnight = 0;
            GlobalItem.numOfBlackKnight = 0;
            GlobalItem.numOfWhiteCastle = 0;
            GlobalItem.numOfBlackCastle = 0;
            GlobalItem.numOfWhiteQueen = 0;
            GlobalItem.numOfBlackQueen = 0;
            GlobalItem.numOfWhiteKing = 0;
            GlobalItem.numOfBlackKing = 0;
            GlobalItem.chessboard = "KJILMIJKHHHHHHHHGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGFFFFFFFFCDEBAEDC";
            GlobalItem.check = "000000";
            GlobalItem.ate = "000000000000";

        }

        public void Countdown1(int count, TimeSpan interval, Action<int> ts, Label minute, System.Windows.Threading.DispatcherTimer dt1)
        {

            intMin1 = Int32.Parse(minute.Content.ToString());

            dt1.Interval = interval;
            dt1.Tick += (_, a) =>
            {
                if (stop == false)
                {
                    if (count-- == 0)
                    {
                        if (intMin1 > 0)
                        {
                            if (GlobalItem.pre != count)
                            {

                                GlobalItem.pre = count;
                                intMin1--;
                                minute.Content = intMin1.ToString();
                                ts(59);
                                count = 59;
                                GlobalItem.tempsec1 = count;
                                GlobalItem.time_win = 0;
                            }
                            else
                            {
                                count = 59;
                                ts(59);
                                GlobalItem.tempsec1 = count;
                            }

                        }
                        else if (intMin1 == 0 && GlobalItem.time_win == 1)
                        {
                            if (GlobalItem.pre != count)
                            {
                                GlobalItem.pre = count;
                                dt1.Stop();
                                if (GlobalItem.isAudio == true)
                                {
                                    victory.Play();
                                }
                                MessageBox.Show("Nguoi choi 2 thang");
                                if (GlobalItem.isAudio == true)
                                {
                                    victory.Stop();
                                }

                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            count = 59;
                            ts(59);
                            GlobalItem.tempsec1 = count;
                        }
                    }
                    else
                    {
                        ts(count);
                        GlobalItem.pre = -3;
                        GlobalItem.time_win = 1;
                        GlobalItem.tempsec1 = count;
                    }
                    if (save == true)
                    {
                        dt1.Stop();
                        GlobalItem.tempsec1 = count;
                        save = false;
                    }

                }
                else
                {
                    dt1.Stop();
                    GlobalItem.tempsec1 = count;
                }

            };
            //ts(count);
            dt1.Start();
        }

        public void Countdown2(int count, TimeSpan interval, Action<int> ts, Label minute, System.Windows.Threading.DispatcherTimer dt2)
        {
            intMin2 = Int32.Parse(minute.Content.ToString());
            dt2.Interval = interval;
            dt2.Tick += (_, a) =>
            {
                if (stop == true)
                {
                    if (count-- == 0)
                    {
                        if (intMin2 > 0)
                        {
                            if (GlobalItem.pre != count)
                            {
                                GlobalItem.pre = count;
                                intMin2--;
                                minute.Content = intMin2.ToString();
                                ts(59);
                                count = 59;
                                GlobalItem.tempsec2 = count;
                                GlobalItem.time_win = 0;
                            }
                            else
                            {
                                count = 59;
                                ts(59);
                                GlobalItem.tempsec2 = count;
                            }

                        }
                        else if (intMin2 == 0 && GlobalItem.time_win == 1)
                        {
                            if (GlobalItem.pre != count)
                            {
                                GlobalItem.pre = count;
                                dt2.Stop();
                                if (GlobalItem.isAudio == true)
                                {
                                    victory.Play();
                                }
                                MessageBox.Show("Nguoi choi 1 thang");
                                if (GlobalItem.isAudio == true)
                                {
                                    victory.Stop();
                                }
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            count = 59;
                            ts(59);
                            GlobalItem.tempsec2 = count;
                        }
                    }
                    else
                    {
                        ts(count);
                        GlobalItem.time_win = 1;
                        GlobalItem.pre = -3;
                        GlobalItem.tempsec2 = count;
                    }
                    if (save == true)
                    {
                        dt2.Stop();
                        GlobalItem.tempsec2 = count;
                        save = false;
                    }
                }
                else
                {
                    dt2.Stop();
                    GlobalItem.tempsec2 = count;
                }

            };
            //ts(count);
            dt2.Start();
        }

        public void setPause(bool n)
        {
            save = n;
        }

        public boardChess saveMatch()
        {
            boardChess game = new boardChess(8, 8);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    game.board[i, j].setLinkImg(arraySeats[i, j].getLink());
                    game.board[i, j].setKind(arraySeats[i, j].getKind());
                    game.board[i, j].setType(arraySeats[i, j].getType());
                    game.board[i, j].setOrdinal(arraySeats[i, j].getOrdinal());
                    game.board[i, j].setTurn(arraySeats[i, j].getTurn());
                }
            }
            return game;
        }

    }

    public class ArrayButton
    {
        public Button[,] array;
        public ArrayButton(int dongB, int cotB)
        {
            array = new Button[dongB, cotB];
            for (int i = 0; i < dongB; i++)
            {
                for (int j = 0; j < cotB; j++)
                {
                    array[i, j] = new Button();
                }
            }
        }
    }
    public class chessMove
    {
        private int sophantu = 0;
        private int[,] array;

        public int getSPT() { return sophantu; }
        public void setSPT(int n) { sophantu = n; }
        public int getPT(int dong, int cot) { return array[dong, cot]; }
        public void deleteRow(ref int[,] a, int delRow, ref int spt)
        {
            for (int i = delRow; i < spt - 1; i++)
            {
                a[i, 0] = a[i + 1, 0];
                a[i, 1] = a[i + 1, 1];
            }
            spt -= 1;
        }
        public void addRow(ref int[,] a, int spt, int row, int col)
        {
            a[spt, 0] = row;
            a[spt, 1] = col;
            spt++;
        }


        public chessMove(Seat a, Seat[,] arr)
        {
            array = new int[30, 2];
            if (a.getKind() == "pawn")
            {
                if (a.getType() == 1)
                {
                    if (a.getRowID() - 1 < 0)
                    {

                    }
                    else
                    {
                        if (a.getColID() - 1 >= 0 && a.getColID() - 1 <= 7)
                        {
                            if (arr[a.getRowID() - 1, a.getColID() - 1].getType() == -1)
                            {
                                array[sophantu, 0] = a.getRowID() - 1;
                                array[sophantu, 1] = a.getColID() - 1;
                                sophantu++;
                            }

                        }
                        if (a.getColID() + 1 >= 0 && a.getColID() + 1 <= 7)
                        {
                            if (arr[a.getRowID() - 1, a.getColID() + 1].getType() == -1)
                            {
                                array[sophantu, 0] = a.getRowID() - 1;
                                array[sophantu, 1] = a.getColID() + 1;
                                sophantu++;
                            }

                        }
                        if (arr[a.getRowID() - 1, a.getColID()].getType() == 0)
                        {
                            array[sophantu, 0] = a.getRowID() - 1;
                            array[sophantu, 1] = a.getColID();
                            sophantu++;
                        }


                        if (a.getRowID() == 6)
                        {
                            if (arr[a.getRowID() - 2, a.getColID()].getType() == 0)
                            {
                                array[sophantu, 0] = a.getRowID() - 2;
                                array[sophantu, 1] = a.getColID();
                                sophantu++;
                            }

                        }
                        else
                        {

                        }
                    }

                }
                else
                {

                    if (a.getColID() - 1 >= 0 && a.getColID() - 1 <= 7)
                    {
                        if (arr[a.getRowID() + 1, a.getColID() - 1].getType() == 1)
                        {
                            array[sophantu, 0] = a.getRowID() + 1;
                            array[sophantu, 1] = a.getColID() - 1;
                            sophantu++;
                        }

                    }
                    if (a.getColID() + 1 >= 0 && a.getColID() + 1 <= 7)
                    {
                        if (arr[a.getRowID() + 1, a.getColID() + 1].getType() == 1)
                        {
                            array[sophantu, 0] = a.getRowID() + 1;
                            array[sophantu, 1] = a.getColID() + 1;
                            sophantu++;
                        }

                    }
                    if (arr[a.getRowID() + 1, a.getColID()].getType() == 0)
                    {
                        array[sophantu, 0] = a.getRowID() + 1;
                        array[sophantu, 1] = a.getColID();
                        sophantu++;
                    }

                    if (a.getRowID() == 1)
                    {
                        if (arr[a.getRowID() + 2, a.getColID()].getType() == 0)
                        {
                            array[sophantu, 0] = a.getRowID() + 2;
                            array[sophantu, 1] = a.getColID();
                            sophantu++;
                        }

                    }
                    else
                    {

                    }
                }

            }
            else if (a.getKind() == "knight")
            {
                if (a.getColID() - 2 >= 0 && a.getColID() - 2 <= 7 && a.getRowID() - 1 >= 0 && a.getRowID() - 1 <= 7)
                {
                    if (a.getType() != arr[a.getRowID() - 1, a.getColID() - 2].getType())
                    {
                        array[sophantu, 0] = a.getRowID() - 1;
                        array[sophantu, 1] = a.getColID() - 2;
                        sophantu++;
                    }

                }
                if (a.getColID() - 1 >= 0 && a.getColID() - 1 <= 7 && a.getRowID() - 2 >= 0 && a.getRowID() - 2 <= 7)
                {
                    if (a.getType() != arr[a.getRowID() - 2, a.getColID() - 1].getType())
                    {
                        array[sophantu, 0] = a.getRowID() - 2;
                        array[sophantu, 1] = a.getColID() - 1;
                        sophantu++;
                    }
                }
                if (a.getColID() + 1 >= 0 && a.getColID() + 1 <= 7 && a.getRowID() - 2 >= 0 && a.getRowID() - 2 <= 7)
                {
                    if (a.getType() != arr[a.getRowID() - 2, a.getColID() + 1].getType())
                    {
                        array[sophantu, 0] = a.getRowID() - 2;
                        array[sophantu, 1] = a.getColID() + 1;
                        sophantu++;
                    }
                }
                if (a.getColID() + 2 >= 0 && a.getColID() + 2 <= 7 && a.getRowID() - 1 >= 0 && a.getRowID() - 1 <= 7)
                {
                    if (a.getType() != arr[a.getRowID() - 1, a.getColID() + 2].getType())
                    {
                        array[sophantu, 0] = a.getRowID() - 1;
                        array[sophantu, 1] = a.getColID() + 2;
                        sophantu++;
                    }
                }
                if (a.getColID() + 2 >= 0 && a.getColID() + 2 <= 7 && a.getRowID() + 1 >= 0 && a.getRowID() + 1 <= 7)
                {
                    if (a.getType() != arr[a.getRowID() + 1, a.getColID() + 2].getType())
                    {
                        array[sophantu, 0] = a.getRowID() + 1;
                        array[sophantu, 1] = a.getColID() + 2;
                        sophantu++;
                    }
                }
                if (a.getColID() + 1 >= 0 && a.getColID() + 1 <= 7 && a.getRowID() + 2 >= 0 && a.getRowID() + 2 <= 7)
                {
                    if (a.getType() != arr[a.getRowID() + 2, a.getColID() + 1].getType())
                    {
                        array[sophantu, 0] = a.getRowID() + 2;
                        array[sophantu, 1] = a.getColID() + 1;
                        sophantu++;
                    }
                }
                if (a.getColID() - 1 >= 0 && a.getColID() - 1 <= 7 && a.getRowID() + 2 >= 0 && a.getRowID() + 2 <= 7)
                {
                    if (a.getType() != arr[a.getRowID() + 2, a.getColID() - 1].getType())
                    {
                        array[sophantu, 0] = a.getRowID() + 2;
                        array[sophantu, 1] = a.getColID() - 1;
                        sophantu++;
                    }
                }
                if (a.getColID() - 2 >= 0 && a.getColID() - 2 <= 7 && a.getRowID() + 1 >= 0 && a.getRowID() + 1 <= 7)
                {
                    if (a.getType() != arr[a.getRowID() + 1, a.getColID() - 2].getType())
                    {
                        array[sophantu, 0] = a.getRowID() + 1;
                        array[sophantu, 1] = a.getColID() - 2;
                        sophantu++;
                    }
                }
            }
            else if (a.getKind() == "queen")
            {
                int x = a.getRowID();
                int y = a.getColID();
                int tempx = x, tempy = y;
                while (x - 1 >= 0)
                {
                    if (arr[x - 1, y].getType() == 0)
                    {
                        array[sophantu, 0] = x - 1;
                        array[sophantu, 1] = y;
                        x--;
                        sophantu++;
                    }
                    else if (a.getType() != arr[x - 1, y].getType())
                    {
                        array[sophantu, 0] = x - 1;
                        array[sophantu, 1] = y;
                        x--;
                        sophantu++;
                        break;
                    }
                    else break;
                }
                x = tempx; y = tempy;
                while (x + 1 <= 7)
                {
                    if (arr[x + 1, y].getType() == 0)
                    {
                        array[sophantu, 0] = x + 1;
                        array[sophantu, 1] = y;
                        x++;
                        sophantu++;
                    }
                    else if (a.getType() != arr[x + 1, y].getType())
                    {
                        array[sophantu, 0] = x + 1;
                        array[sophantu, 1] = y;
                        x++;
                        sophantu++;
                        break;
                    }
                    else break;
                }
                x = tempx; y = tempy;
                while (y + 1 <= 7)
                {
                    if (arr[x, y + 1].getType() == 0)
                    {
                        array[sophantu, 0] = x;
                        array[sophantu, 1] = y + 1;
                        y++;
                        sophantu++;
                    }
                    else if (a.getType() != arr[x, y + 1].getType())
                    {
                        array[sophantu, 0] = x;
                        array[sophantu, 1] = y + 1;
                        y++;
                        sophantu++;
                        break;
                    }
                    else break;
                }
                x = tempx; y = tempy;
                while (y - 1 >= 0)
                {
                    if (arr[x, y - 1].getType() == 0)
                    {
                        array[sophantu, 0] = x;
                        array[sophantu, 1] = y - 1;
                        y--;
                        sophantu++;
                    }
                    else if (a.getType() != arr[x, y - 1].getType())
                    {
                        array[sophantu, 0] = x;
                        array[sophantu, 1] = y - 1;
                        y--;
                        sophantu++;
                        break;
                    }
                    else break;
                }
                x = tempx; y = tempy;
                while (x - 1 >= 0 && y - 1 >= 0)
                {
                    if (arr[x - 1, y - 1].getType() == 0)
                    {
                        array[sophantu, 0] = x - 1;
                        array[sophantu, 1] = y - 1;
                        x--; y--;
                        sophantu++;
                    }
                    else if (a.getType() != arr[x - 1, y - 1].getType())
                    {
                        array[sophantu, 0] = x - 1;
                        array[sophantu, 1] = y - 1;
                        x--; y--;
                        sophantu++;
                        break;
                    }
                    else break;
                }
                x = tempx; y = tempy;
                while (x - 1 >= 0 && y + 1 <= 7)
                {
                    if (arr[x - 1, y + 1].getType() == 0)
                    {
                        array[sophantu, 0] = x - 1;
                        array[sophantu, 1] = y + 1;
                        x--; y++;
                        sophantu++;
                    }
                    else if (a.getType() != arr[x - 1, y + 1].getType())
                    {
                        array[sophantu, 0] = x - 1;
                        array[sophantu, 1] = y + 1;
                        x--; y++;
                        sophantu++;
                        break;
                    }
                    else break;
                }
                x = tempx; y = tempy;
                while (x + 1 <= 7 && y - 1 >= 0)
                {
                    if (arr[x + 1, y - 1].getType() == 0)
                    {
                        array[sophantu, 0] = x + 1;
                        array[sophantu, 1] = y - 1;
                        x++; y--;
                        sophantu++;
                    }
                    else if (a.getType() != arr[x + 1, y - 1].getType())
                    {
                        array[sophantu, 0] = x + 1;
                        array[sophantu, 1] = y - 1;
                        x++; y--;
                        sophantu++;
                        break;
                    }
                    else break;
                }
                x = tempx; y = tempy;
                while (x + 1 <= 7 && y + 1 <= 7)
                {
                    if (arr[x + 1, y + 1].getType() == 0)
                    {
                        array[sophantu, 0] = x + 1;
                        array[sophantu, 1] = y + 1;
                        x++; y++;
                        sophantu++;
                    }
                    else if (a.getType() != arr[x + 1, y + 1].getType())
                    {
                        array[sophantu, 0] = x + 1;
                        array[sophantu, 1] = y + 1;
                        x++; y++;
                        sophantu++;
                        break;
                    }
                    else break;
                }
            }
            else if (a.getKind() == "bishop")
            {
                int x = a.getRowID();
                int y = a.getColID();
                int tempx = x, tempy = y;
                while (x - 1 >= 0 && y - 1 >= 0)
                {
                    if (arr[x - 1, y - 1].getType() == 0)
                    {
                        array[sophantu, 0] = x - 1;
                        array[sophantu, 1] = y - 1;
                        x--; y--;
                        sophantu++;
                    }
                    else if (a.getType() != arr[x - 1, y - 1].getType())
                    {
                        array[sophantu, 0] = x - 1;
                        array[sophantu, 1] = y - 1;
                        x--; y--;
                        sophantu++;
                        break;
                    }
                    else break;
                }
                x = tempx; y = tempy;
                while (x - 1 >= 0 && y + 1 <= 7)
                {
                    if (arr[x - 1, y + 1].getType() == 0)
                    {
                        array[sophantu, 0] = x - 1;
                        array[sophantu, 1] = y + 1;
                        x--; y++;
                        sophantu++;
                    }
                    else if (a.getType() != arr[x - 1, y + 1].getType())
                    {
                        array[sophantu, 0] = x - 1;
                        array[sophantu, 1] = y + 1;
                        x--; y++;
                        sophantu++;
                        break;
                    }
                    else break;
                }
                x = tempx; y = tempy;
                while (x + 1 <= 7 && y - 1 >= 0)
                {
                    if (arr[x + 1, y - 1].getType() == 0)
                    {
                        array[sophantu, 0] = x + 1;
                        array[sophantu, 1] = y - 1;
                        x++; y--;
                        sophantu++;
                    }
                    else if (a.getType() != arr[x + 1, y - 1].getType())
                    {
                        array[sophantu, 0] = x + 1;
                        array[sophantu, 1] = y - 1;
                        x++; y--;
                        sophantu++;
                        break;
                    }
                    else break;
                }
                x = tempx; y = tempy;
                while (x + 1 <= 7 && y + 1 <= 7)
                {
                    if (arr[x + 1, y + 1].getType() == 0)
                    {
                        array[sophantu, 0] = x + 1;
                        array[sophantu, 1] = y + 1;
                        x++; y++;
                        sophantu++;
                    }
                    else if (a.getType() != arr[x + 1, y + 1].getType())
                    {
                        array[sophantu, 0] = x + 1;
                        array[sophantu, 1] = y + 1;
                        x++; y++;
                        sophantu++;
                        break;
                    }
                    else break;
                }
            }
            else if (a.getKind() == "castle")
            {
                int x = a.getRowID();
                int y = a.getColID();
                int tempx = x, tempy = y;
                while (x - 1 >= 0)
                {
                    if (arr[x - 1, y].getType() == 0)
                    {
                        array[sophantu, 0] = x - 1;
                        array[sophantu, 1] = y;
                        x--;
                        sophantu++;
                    }
                    else if (a.getType() != arr[x - 1, y].getType())
                    {
                        array[sophantu, 0] = x - 1;
                        array[sophantu, 1] = y;
                        x--;
                        sophantu++;
                        break;
                    }
                    else break;
                }
                x = tempx; y = tempy;
                while (x + 1 <= 7)
                {
                    if (arr[x + 1, y].getType() == 0)
                    {
                        array[sophantu, 0] = x + 1;
                        array[sophantu, 1] = y;
                        x++;
                        sophantu++;
                    }
                    else if (a.getType() != arr[x + 1, y].getType())
                    {
                        array[sophantu, 0] = x + 1;
                        array[sophantu, 1] = y;
                        x++;
                        sophantu++;
                        break;
                    }
                    else break;
                }
                x = tempx; y = tempy;
                while (y + 1 <= 7)
                {
                    if (arr[x, y + 1].getType() == 0)
                    {
                        array[sophantu, 0] = x;
                        array[sophantu, 1] = y + 1;
                        y++;
                        sophantu++;
                    }
                    else if (a.getType() != arr[x, y + 1].getType())
                    {
                        array[sophantu, 0] = x;
                        array[sophantu, 1] = y + 1;
                        y++;
                        sophantu++;
                        break;
                    }
                    else break;
                }
                x = tempx; y = tempy;
                while (y - 1 >= 0)
                {
                    if (arr[x, y - 1].getType() == 0)
                    {
                        array[sophantu, 0] = x;
                        array[sophantu, 1] = y - 1;
                        y--;
                        sophantu++;
                    }
                    else if (a.getType() != arr[x, y - 1].getType())
                    {
                        array[sophantu, 0] = x;
                        array[sophantu, 1] = y - 1;
                        y--;
                        sophantu++;
                        break;
                    }
                    else break;
                }
            }
            else
            {
                if (a.getColID() - 1 >= 0 && a.getColID() - 1 <= 7 && a.getRowID() - 1 >= 0 && a.getRowID() - 1 <= 7)
                {
                    if (a.getType() != arr[a.getRowID() - 1, a.getColID() - 1].getType())
                    {
                        array[sophantu, 0] = a.getRowID() - 1;
                        array[sophantu, 1] = a.getColID() - 1;
                        sophantu++;
                    }
                }
                if (a.getColID() - 0 >= 0 && a.getColID() - 0 <= 7 && a.getRowID() - 1 >= 0 && a.getRowID() - 1 <= 7)
                {
                    if (a.getType() != arr[a.getRowID() - 1, a.getColID() - 0].getType())
                    {
                        array[sophantu, 0] = a.getRowID() - 1;
                        array[sophantu, 1] = a.getColID() - 0;
                        sophantu++;
                    }
                }
                if (a.getColID() + 1 >= 0 && a.getColID() + 1 <= 7 && a.getRowID() - 1 >= 0 && a.getRowID() - 1 <= 7)
                {
                    if (a.getType() != arr[a.getRowID() - 1, a.getColID() + 1].getType())
                    {
                        array[sophantu, 0] = a.getRowID() - 1;
                        array[sophantu, 1] = a.getColID() + 1;
                        sophantu++;
                    }
                }
                if (a.getColID() + 1 >= 0 && a.getColID() + 1 <= 7 && a.getRowID() - 0 >= 0 && a.getRowID() - 0 <= 7)
                {
                    if (a.getType() != arr[a.getRowID() - 0, a.getColID() + 1].getType())
                    {
                        array[sophantu, 0] = a.getRowID() - 0;
                        array[sophantu, 1] = a.getColID() + 1;
                        sophantu++;
                    }
                }
                if (a.getColID() + 1 >= 0 && a.getColID() + 1 <= 7 && a.getRowID() + 1 >= 0 && a.getRowID() + 1 <= 7)
                {
                    if (a.getType() != arr[a.getRowID() + 1, a.getColID() + 1].getType())
                    {
                        array[sophantu, 0] = a.getRowID() + 1;
                        array[sophantu, 1] = a.getColID() + 1;
                        sophantu++;
                    }
                }
                if (a.getColID() - 0 >= 0 && a.getColID() - 0 <= 7 && a.getRowID() + 1 >= 0 && a.getRowID() + 1 <= 7)
                {
                    if (a.getType() != arr[a.getRowID() + 1, a.getColID() - 0].getType())
                    {
                        array[sophantu, 0] = a.getRowID() + 1;
                        array[sophantu, 1] = a.getColID() - 0;
                        sophantu++;
                    }
                }
                if (a.getColID() - 1 >= 0 && a.getColID() - 1 <= 7 && a.getRowID() + 1 >= 0 && a.getRowID() + 1 <= 7)
                {
                    if (a.getType() != arr[a.getRowID() + 1, a.getColID() - 1].getType())
                    {
                        array[sophantu, 0] = a.getRowID() + 1;
                        array[sophantu, 1] = a.getColID() - 1;
                        sophantu++;
                    }
                }
                if (a.getColID() - 1 >= 0 && a.getColID() - 1 <= 7 && a.getRowID() - 0 >= 0 && a.getRowID() - 0 <= 7)
                {
                    if (a.getType() != arr[a.getRowID() - 0, a.getColID() - 1].getType())
                    {
                        array[sophantu, 0] = a.getRowID() - 0;
                        array[sophantu, 1] = a.getColID() - 1;
                        sophantu++;
                    }
                }
            }

        }


    }
    public class RadioPlus
    {
        public RadioButton radio;
        private int cap;
        private int loai;
        private int i;
        private int j;
        public int getrow() { return i; }
        public int getcol() { return j; }
        public int getLoai() { return loai; }
        public void setLoai(int n) { loai = n; }
        public void setRow(int n) { i = n; }
        public void setCol(int n) { j = n; }
        public RadioPlus()
        {
            radio = new RadioButton();
            cap = 0;
        }
        public int getCap() { return cap; }
        public void setCap(int n) { cap = n; }
        public void setradio(RadioButton n) { radio = n; }
        public RadioButton getradio() { return radio; }


    }
    public class arrayRadioPlus
    {
        public RadioPlus[] a = new RadioPlus[4];

        public arrayRadioPlus()
        {
            for (int i = 0; i < 4; i++)
            {
                a[i] = new RadioPlus();
            }
        }
        //public RadioPlus getRadioPlus() { return }
    }
}
