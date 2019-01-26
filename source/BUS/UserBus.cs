using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class UserBUS
    {
        public UserDTO loadOneUser(string id)
        {
            UserDAO dao = new UserDAO();
            UserDTO result = dao.getUserByID(id);

            return result;
        }

        //Register
        //0: fail
        //1: succeed
        //2: ID is existed
        public int Register(UserDTO user)
        {
            UserDAO dao = new UserDAO();
            UserDTO temp = dao.getUserByID(user.id);
            if (temp.id != null)
                return 2;
            return dao.InsertUser(user);
        }

        public List<UserDTO> loadAllRankedUser()
        {
            UserDAO dao = new UserDAO();
            List<UserDTO> result = dao.loadAllRankedUsers();

            return result;
        }

        //Login
        //0: wrong password
        //1: succeed
        //2: id is invalid
        public int Login(string id, string password)
        {
            UserDAO dao = new UserDAO();
            UserDTO temp = dao.getUserByID(id);
            if (temp.id == null)
                return 2;
            if (password == temp.password)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void playerWin(string id)
        {
            UserDAO dao = new UserDAO();
            dao.updatePointForWinner(id);
        }

        public void playerLose(string id)
        {
            UserDAO dao = new UserDAO();
            dao.updatePointForLoser(id);
        }

        public void playerDraw(string id)
        {
            UserDAO dao = new UserDAO();
            dao.updatePointForDraw(id);
        }
    }
}
