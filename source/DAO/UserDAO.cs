using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using DTO;

namespace DAO
{
    public class UserDAO : AbstractDAO
    {
        public UserDTO getUserByID(string id)
        {
            //Step 1: connect to database
            OleDbConnection connection = Connect();

            //Step 2: get information by ID
            string sql = "SELECT * FROM tblUsers WHERE ID=@ID";
            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbParameter para = command.Parameters.Add("@ID", OleDbType.VarChar);
            para.Value = id;
            OleDbDataReader reader = command.ExecuteReader();

            UserDTO result = new UserDTO();

            while (reader.Read())
            {
                result.id = reader.GetString(0);
                result.name = reader.GetString(1);
                result.email = reader.GetString(2);
                result.password = reader.GetString(3);
                result.point = reader.GetInt16(4);
                result.wmatchs = reader.GetInt16(5);
                result.dmatchs = reader.GetInt16(6);
                result.lmatchs = reader.GetInt16(7);
            }
            reader.Close();

            // B3: Close connection
            connection.Close();
            return result;
        }

        public int InsertUser(UserDTO user)
        {
            // B1: Tạo kết nối
            OleDbConnection connection = Connect();

            // B2: Thêm tài khoản mới
            string sql = "INSERT INTO tblUsers  VALUES(@id, @name, @email, @password, 0, 0, 0, 0)";
            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbParameter para = command.Parameters.Add("@id", OleDbType.VarChar);
            para.Value = user.id;
            para = command.Parameters.Add("@name", OleDbType.VarChar);
            para.Value = user.name;
            para = command.Parameters.Add("@email", OleDbType.VarChar);
            para.Value = user.email;
            para = command.Parameters.Add("@password", OleDbType.VarChar);
            para.Value = user.password;

            int count = command.ExecuteNonQuery();

            if (count < 1)
                count = 0;
            else
                count = 1;

            // B3: Đóng kết nối
            connection.Close();
            return count;
        }

        public List<UserDTO> loadAllRankedUsers()
        {
            //Step 1: connect to database
            OleDbConnection connection = Connect();

            //Step 2: get information
            string sql = "SELECT * FROM tblUsers ORDER BY POINT DESC";
            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader reader = command.ExecuteReader();

            List<UserDTO> result = new List<UserDTO>();

            while (reader.Read())
            {
                UserDTO user = new UserDTO();
                user.id = reader.GetString(0);
                user.name = reader.GetString(1);
                user.email = reader.GetString(2);
                user.password = reader.GetString(3);
                user.point = reader.GetInt16(4);
                user.wmatchs = reader.GetInt16(5);
                user.dmatchs = reader.GetInt16(6);
                user.lmatchs = reader.GetInt16(7);
                result.Add(user);
            }
            reader.Close();

            // B3: Close connection
            connection.Close();
            return result;
        }

        public void updatePointForWinner(string id)
        {
            //Step 1: connect to database
            OleDbConnection connection = Connect();

            //Step 2: update point by ID
            string sql = "UPDATE tblUsers SET POINT = POINT + 30 WHERE ID=@ID";
            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbParameter para = command.Parameters.Add("@ID", OleDbType.VarChar);
            para.Value = id;
            OleDbDataReader reader = command.ExecuteReader();

            reader.Close();

            //Step 3: update WMATCH by ID
            sql = "UPDATE tblUsers SET WMATCHS = WMATCHS + 1 WHERE ID=@ID";
            command = new OleDbCommand(sql, connection);
            para = command.Parameters.Add("@ID", OleDbType.VarChar);
            para.Value = id;
            reader = command.ExecuteReader();

            reader.Close();

            //Step 4: Close connection
            connection.Close();
            return;
        }


        public void updatePointForLoser(string id)
        {
            //Step 1: connect to database
            OleDbConnection connection = Connect();

            //Step 2: update point by ID
            string sql = "UPDATE tblUsers SET POINT = POINT + 10 WHERE ID=@ID";
            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbParameter para = command.Parameters.Add("@ID", OleDbType.VarChar);
            para.Value = id;
            OleDbDataReader reader = command.ExecuteReader();

            reader.Close();

            //Step 3: update LMATCH by ID
            sql = "UPDATE tblUsers SET LMATCHS = LMATCHS + 1 WHERE ID=@ID";
            command = new OleDbCommand(sql, connection);
            para = command.Parameters.Add("@ID", OleDbType.VarChar);
            para.Value = id;
            reader = command.ExecuteReader();

            reader.Close();

            //Step 4: Close connection
            connection.Close();
            return;
        }

        public void updatePointForDraw(string id)
        {
            //Step 1: connect to database
            OleDbConnection connection = Connect();

            //Step 2: update point by ID
            string sql = "UPDATE tblUsers SET POINT = POINT + 20 WHERE ID=@ID";
            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbParameter para = command.Parameters.Add("@ID", OleDbType.VarChar);
            para.Value = id;
            OleDbDataReader reader = command.ExecuteReader();

            reader.Close();

            //Step 3: update DMATCH by ID
            sql = "UPDATE tblUsers SET DMATCHS = DMATCHS + 1 WHERE ID=@ID";
            command = new OleDbCommand(sql, connection);
            para = command.Parameters.Add("@ID", OleDbType.VarChar);
            para.Value = id;
            reader = command.ExecuteReader();

            reader.Close();

            // Step4: Close connection
            connection.Close();
            return;
        }
    }
}
