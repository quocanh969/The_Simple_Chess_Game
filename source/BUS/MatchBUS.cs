using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class MatchBUS
    {
        public MatchDTO LoadMatch(string id)
        {
            MatchDAO dao = new MatchDAO();
            MatchDTO result = dao.loadMatchByID(id);

            return result;
        }

        public void deleteMatch(string id)
        {
            MatchDAO dao = new MatchDAO();
            dao.deleteMatchByID(id);
        }

        //saveMatch
        //0: fail
        //1: succeed
        public int SaveMatch(MatchDTO Match)
        {
            MatchDAO dao = new MatchDAO();
            MatchDTO temp = dao.loadMatchByID(Match.id);
            if (temp.player1 != null)
                return 2;
            return dao.saveMatch(Match);
        }

        public List<MatchDTO> loadAllSavedMatch()
        {
            MatchDAO dao = new MatchDAO();
            List<MatchDTO> result = dao.loadAllSavedMatchs();

            return result;
        }
    }
}
