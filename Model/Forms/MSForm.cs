using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movieDb.Model.Forms
{
    public partial class MSForm : Form
    {
        MDB mdb = new MDB();
        public MSForm()
        {
            InitializeComponent();
        }

        private void Search(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(mdb.SearchMovieByName(textBox1.Text).ToArray());
        }
       
        private void Cancel(object sender, EventArgs e)
        {
            mdb.WriteMovie();
            Close();
        }

        private void Delete(object sender, EventArgs e)
        {
            mdb.RemoveMovieByN(textBoxMovieName.Text);
            textBoxMovieName.Text = "";
        }
        private void Cnfrm(object sender, EventArgs e)
        {
            mdb.AddMovie(textBoxGanre.Text,textBoxMoiveNameCreate.Text,textBoxIAM.Text,
                textBoxCreatorName.Text,textBoxSS.Text);
            textBoxGanre.Text = "";
            textBoxMoiveNameCreate.Text = "";
            textBoxIAM.Text = "";
            textBoxCreatorName.Text = "";
            textBoxSS.Text = "";
        }

        private void SearchByGanre(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Items.AddRange(mdb.SearchMoviesByGanre(textBox2.Text).ToArray());
        }

        private void SearchByCN(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            listBox3.Items.AddRange(mdb.SearchMoviesByCreatorName(textBox3.Text).ToArray());
        }

        private void DeleteByCN(object sender, EventArgs e)
        {
            mdb.RemoveMovieByCN(textBoxCn.Text);
            textBoxMovieName.Text = "";
        }

        private void MSForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            DialogResult dialog = MessageBox.Show("Are you sure?" ,"Exit",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                mdb.WriteMovie();
                Application.Exit();
            }
            else if(dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
