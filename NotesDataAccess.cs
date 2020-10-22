using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyJournal
{
    public class NotesDataAccess
    {
        DataAccess da;
        public NotesDataAccess()
        {
            da = new DataAccess();
        }

        public List<Notes> GetNotes()
        {
            string sql = "SELECT * FROM Journals WHERE UserId='" + Global.id+"';";
            SqlDataReader reader = da.GetData(sql);
            List<Notes> list = new List<Notes>();
            while(reader.Read())
            {
                Notes n = new Notes();
                n.NoteId = (int)reader["NoteId"];
                n.Title = reader["Title"].ToString();
                n.CreatedDate = reader["CreatedDate"].ToString();
                n.ModifiedDate = reader["ModifiedDate"].ToString();
                n.UserId=(int)reader["UserId"];
                n.Priority= reader["Priority"].ToString();
                list.Add(n);
            }
            return list;
        }

        public int AddNote(Notes n)
        {
            string sql = "INSERT INTO Journals(Title,CreatedDate,ModifiedDate,UserId,Priority)" +
                " VALUES('" + n.Title + "','" + n.CreatedDate + "','" + n.ModifiedDate + "','" + n.UserId + "','"+n.Priority+"')";
            return da.Execute(sql);
        }

        public int DeleteNote(int i)
        {
            string sql = "DELETE FROM Journals WHERE NoteId='" + i + "';"; 
            return da.Execute(sql);
        }

        public int EditNote(string e, string md, int id, string p)
        {
            string sql = "UPDATE Journals SET Title='" + e + "' , ModifiedDate='" + md + "',Priority='"+p+"' WHERE NoteId='" + id + "'";
            return da.Execute(sql);
        }
    }
}
