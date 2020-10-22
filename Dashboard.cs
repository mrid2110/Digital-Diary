using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyJournal
{
    public partial class Dashboard : Form
    {

        NotesDataAccess nda;
        NoteService ns;
        public Dashboard()
        {
            InitializeComponent();
            nda = new NotesDataAccess();
            ns = new NoteService();
            dataGridView.DataSource = nda.GetNotes();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(highRadioButton.Checked)
            {
                highRadioButton.Text = "High";
                int result = ns.EditNote(titleTextbox.Text, DateTime.Now.ToLongDateString(), NoteId, highRadioButton.Text);
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\DailyJournalNotes\\" + titleTextbox.Text + ".txt");
                sw.WriteLine(messageTextbox.Text);
                sw.Close();
                nda = new NotesDataAccess();
                dataGridView.DataSource = nda.GetNotes();
                MessageBox.Show("Successfully saved!");
            }

            else if (moderateRadioButton.Checked)
            {
                moderateRadioButton.Text = "Moderate";
                int result = ns.EditNote(titleTextbox.Text, DateTime.Now.ToLongDateString(), NoteId, moderateRadioButton.Text);
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\DailyJournalNotes\\" + titleTextbox.Text + ".txt");
                sw.WriteLine(messageTextbox.Text);
                sw.Close();
                nda = new NotesDataAccess();
                dataGridView.DataSource = nda.GetNotes();
                MessageBox.Show("Successfully saved!");
            }

            else if (lessRadioButton.Checked)
            {
                lessRadioButton.Text = "Less Important";
                int result = ns.EditNote(titleTextbox.Text, DateTime.Now.ToLongDateString(), NoteId, lessRadioButton.Text);
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\DailyJournalNotes\\" + titleTextbox.Text + ".txt");
                sw.WriteLine(messageTextbox.Text);
                sw.Close();
                nda = new NotesDataAccess();
                dataGridView.DataSource = nda.GetNotes();
                MessageBox.Show("Successfully saved!");
            }

            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            messageTextbox.Clear();
            titleTextbox.Clear();
            pictureBox1.Image = null ;
            highRadioButton.Checked = false;
            moderateRadioButton.Checked = false;
            lessRadioButton.Checked = false;
        }

        private void add_Click(object sender, EventArgs e)
        {
            if(highRadioButton.Checked)
            {
                highRadioButton.Text = "High";
                int result = ns.AddNote(titleTextbox.Text, DateTime.Now.ToLongDateString(), DateTime.Now.ToLongDateString(),
                    Convert.ToInt32(Global.id),highRadioButton.Text);
                if (result == 1)
                {
                    StreamWriter sw = new StreamWriter(Application.StartupPath + "\\DailyJournalNotes\\" + titleTextbox.Text + ".txt");
                    sw.WriteLine(messageTextbox.Text);
                    sw.Close();
                    MessageBox.Show("Succeesfully added!");
                    nda = new NotesDataAccess();
                    dataGridView.DataSource = nda.GetNotes();
                }
            }

            else if (moderateRadioButton.Checked)
            {
                highRadioButton.Text = "Moderate";
                int result = ns.AddNote(titleTextbox.Text, DateTime.Now.ToLongDateString(), DateTime.Now.ToLongDateString(), 
                    Convert.ToInt32(Global.id), highRadioButton.Text);
                if (result == 1)
                {
                    StreamWriter sw = new StreamWriter(Application.StartupPath + "\\DailyJournalNotes\\" + titleTextbox.Text + ".txt");
                    sw.WriteLine(messageTextbox.Text);
                    sw.Close();
                    MessageBox.Show("Succeesfully added!");
                    nda = new NotesDataAccess();
                    dataGridView.DataSource = nda.GetNotes();
                }
            }

            else if (lessRadioButton.Checked)
            {
                highRadioButton.Text = "Less Important";
                int result = ns.AddNote(titleTextbox.Text, DateTime.Now.ToLongDateString(), DateTime.Now.ToLongDateString(),
                    Convert.ToInt32(Global.id), highRadioButton.Text);
                if (result == 1)
                {
                    StreamWriter sw = new StreamWriter(Application.StartupPath + "\\DailyJournalNotes\\" + titleTextbox.Text + ".txt");
                    sw.WriteLine(messageTextbox.Text);
                    sw.Close();
                    MessageBox.Show("Succeesfully added!");
                    nda = new NotesDataAccess();
                    dataGridView.DataSource = nda.GetNotes();
                }
            }

            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int result = ns.DeleteNote(Convert.ToInt32(deleteTextbox.Text));
            if (result == 1)
            {
                MessageBox.Show("Succeesfully deleted!");
                deleteTextbox.Clear();
                nda = new NotesDataAccess();
                dataGridView.DataSource = nda.GetNotes();
                titleTextbox.Clear();
                messageTextbox.Clear();
                pictureBox1.Image = null;
                if (highRadioButton.Checked)
                {
                    highRadioButton.Checked = false;
                }
                else if (moderateRadioButton.Checked)
                {
                    moderateRadioButton.Checked = false;
                }
                else if (lessRadioButton.Checked)
                {
                    lessRadioButton.Checked = false;
                }
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }

        int NoteId,UserId;
        string cd, md;

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(titleTextbox.Text))
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                string path = Application.StartupPath + "\\DailyJournalPictures\\" + titleTextbox.Text + ".jpg";
                File.Copy(ofd.FileName, path, true);
            }
            else
            {
                MessageBox.Show("Give a Title.");
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NoteId = (int)dataGridView.Rows[e.RowIndex].Cells[0].Value;
            titleTextbox.Text= dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            TextReader reader = new StreamReader(Application.StartupPath + "\\DailyJournalNotes\\" + titleTextbox.Text + ".txt");
            messageTextbox.Text = reader.ReadToEnd();
            reader.Close();
            cd= dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            md= dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            UserId = (int)dataGridView.Rows[e.RowIndex].Cells[4].Value;
            string path = Application.StartupPath + "\\DailyJournalPictures\\" + titleTextbox.Text + ".jpg";
            if(File.Exists(path))
            {
                pictureBox1.Image = Image.FromFile(path);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox1.Image=null;
            }


            if(dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString()=="High")
            {
                highRadioButton.Checked = true;
            }
            else if (dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString() == "Moderate")
            {
                moderateRadioButton.Checked = true;
            }
            else if (dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString() == "Less Important")
            {
                lessRadioButton.Checked = true;
            }
        }
    }
}
