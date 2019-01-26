using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        private string ID;
        private string NAME;
        private string EMAIL;
        private string PASSWORD;
        private int POINT;
        private int WMATCHS;
        private int DMATCHS;
        private int LMATCHS;

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

        public string name
        {
            get
            {
                return NAME;
            }
            set
            {
                NAME = value;
            }
        }

        public string email
        {
            get
            {
                return EMAIL;
            }
            set
            {
                EMAIL = value;
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

        public int point
        {
            get
            {
                return POINT;
            }
            set
            {
                POINT = value;
            }
        }

        public int wmatchs
        {
            get
            {
                return WMATCHS;
            }
            set
            {
                WMATCHS = value;
            }
        }

        public int dmatchs
        {
            get
            {
                return DMATCHS;
            }
            set
            {
                DMATCHS = value;
            }
        }

        public int lmatchs
        {
            get
            {
                return LMATCHS;
            }
            set
            {
                LMATCHS = value;
            }
        }

    }
}
