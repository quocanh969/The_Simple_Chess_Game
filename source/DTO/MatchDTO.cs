using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MatchDTO
    {
        private string ID;
        private string PLAYER1;
        private string PLAYER2;
        private string PASSWORD;
        private int TIME1;
        private int TIME2;
        private int TYPE;
        private string CHESSBOARD;
        private string CHECK;
        private int TURN;
        private string ATE;


        public string id
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }

        public string player1
        {
            get
            {
                return PLAYER1;
            }
            set
            {
                PLAYER1 = value;
            }
        }

        public string player2
        {
            get
            {
                return PLAYER2;
            }
            set
            {
                PLAYER2 = value;
            }
        }

        public string password
        {
            get
            {
                return PASSWORD;
            }
            set
            {
                PASSWORD = value;
            }
        }

        public int time1
        {
            get
            {
                return TIME1;
            }
            set
            {
                TIME1 = value;
            }
        }

        public int time2
        {
            get
            {
                return TIME2;
            }
            set
            {
                TIME2 = value;
            }
        }

        public int type
        {
            get
            {
                return TYPE;
            }
            set
            {
                TYPE = value;
            }
        }

        public string chessboard
        {
            get
            {
                return CHESSBOARD;
            }
            set
            {
                CHESSBOARD = value;
            }
        }

        public string check
        {
            get
            {
                return CHECK;
            }
            set
            {
                CHECK = value;
            }
        }

        public int turn
        {
            get
            {
                return TURN;
            }
            set
            {
                TURN = value;
            }
        }

        public string ate
        {
            get
            {
                return ATE;
            }
            set
            {
                ATE = value;
            }
        }

    }
}
