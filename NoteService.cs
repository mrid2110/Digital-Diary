using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyJournal
{
    public class NoteService
    {
        NotesDataAccess nda;
        public NoteService()
        {
            nda = new NotesDataAccess();
        }

        public int AddNote(string Title,string CreatedDate,string ModifiedDate,int UserId,string Priority)
        {
            Notes n = new Notes() { Title = Title, CreatedDate = CreatedDate, ModifiedDate = ModifiedDate, UserId = UserId,Priority=Priority};
            return nda.AddNote(n);
        }

        public int DeleteNote(int id)
        {
            return nda.DeleteNote(id);
        }

        public int EditNote(string title, string moddate, int noteid, string prio)
        {
            return nda.EditNote(title, moddate,noteid,prio);
        }
    }
}
