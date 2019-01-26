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
    public class MatchDAO : AbstractDAO
    {
        public MatchDTO loadMatchByID(string id)
        {
            //Step 1: connect to database
            OleDbConnection connection = Connect();

            //Step 2: get information by ID
            string sql = "SELECT * FROM tblMatchs WHERE ID=@ID";
            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbParameter para = command.Parameters.Add("@ID", OleDbType.VarChar);
            para.Value = id;
            OleDbDataReader reader = command.ExecuteReader();

            MatchDTO result = new MatchDTO();

            while (reader.Read())
            {
                result.id = reader.GetString(0);
                result.player1 = reader.GetString(1);
                result.player2 = reader.GetString(2);
                result.password = reader.GetString(3);
                result.time1 = reader.GetInt16(4);
                result.time2 = reader.GetInt16(5);
                result.type = reader.GetInt16(6);
                result.chessboard = reader.GetString(7);
                result.check = reader.GetString(8);
                result.turn = reader.GetInt16(9);
                result.ate = reader.GetString(10);
            }
            reader.Close();


            // B3: Close connection
            connection.Close();
            return result;
        }

        public int saveMatch(MatchDTO match)
        {
            // B1: Tạo kết nối
            OleDbConnection connection = Connect();

            // B2: Thêm tài khoản mới
            string sql = "INSERT INTO tblMatchs VALUES(@id, @player1, @player2, @password, @time1, @time2, @type, @chessboard, @check, @turn, @ate)";
            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbParameter para = para = command.Parameters.Add("@id", OleDbType.VarChar);
            para.Value = match.id;
            para = command.Parameters.Add("@player1", OleDbType.VarChar);
            para.Value = match.player1;
            para = command.Parameters.Add("@player2", OleDbType.VarChar);
            para.Value = match.player2;
            para = command.Parameters.Add("@password", OleDbType.VarChar);
            para.Value = match.password;
            para = command.Parameters.Add("@time1", OleDbType.Integer);
            para.Value = match.time1;
            para = command.Parameters.Add("@time2", OleDbType.Integer);
            para.Value = match.time2;
            para = command.Parameters.Add("@type", OleDbType.Integer);
            para.Value = match.type;
            para = command.Parameters.Add("@chessboard", OleDbType.VarChar);
            para.Value = match.chessboard;
            para = command.Parameters.Add("@check", OleDbType.VarChar);
            para.Value = match.check;
            para = command.Parameters.Add("@turn", OleDbType.Integer);
            para.Value = match.turn;
            para = command.Parameters.Add("@ate", OleDbType.VarChar);
            para.Value = match.ate;


            int count = command.ExecuteNonQuery();

            if (count < 1)
                count = 0;
            else
                count = 1;

            // B3: Đóng kết nối
            connection.Close();
            return count;
        }

        public List<MatchDTO> loadAllSavedMatchs()
        {
            //Step 1: connect to database
            OleDbConnection connection = Connect();

            //Step 2: get information
            string sql = "SELECT * FROM tblMatchs";
            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbDataReader reader = command.ExecuteReader();

            List<MatchDTO> result = new List<MatchDTO>();

            while (reader.Read())
            {
                MatchDTO match = new MatchDTO();
                match.id = reader.GetString(0);
                match.player1 = reader.GetString(1);
                match.player2 = reader.GetString(2);
                match.password = reader.GetString(3);
                match.time1 = reader.GetInt16(4);
                match.time2 = reader.GetInt16(5);
                match.type = reader.GetInt16(6);
                match.chessboard = reader.GetString(7);
                match.check = reader.GetString(8);
                match.turn = reader.GetInt16(9);
                match.ate = reader.GetString(10);
                result.Add(match);
            }
            reader.Close();

            // B3: Close connection
            connection.Close();
            return result;
        }

        public void deleteMatchByID(string id)
        {
            //Step 1: connect to database
            OleDbConnection connection = Connect();

            //Step 2: delete match by ID
            string sql = "DELETE FROM tblMatchs WHERE ID=@ID";
            OleDbCommand command = new OleDbCommand(sql, connection);
            OleDbParameter para = command.Parameters.Add("@ID", OleDbType.VarChar);
            para.Value = id;
            OleDbDataReader reader = command.ExecuteReader();

            reader.Close();

            // B3: Close connection
            connection.Close();
            return;
        }
    }
}
