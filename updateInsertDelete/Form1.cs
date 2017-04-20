using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace updateInsertDelete
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=BLACKWATER;Initial Catalog=InsertDeleteUpdate;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmd.Connection = con;
            loadList();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(txtId.Text != "" & txtName.Text != "")
            {
                con.Open();
                cmd.CommandText = "insert into info (id,name) values ('"+txtId.Text+"','"+txtName.Text+"')";
                cmd.ExecuteNonQuery();
                con.Close();
                txtName.Text = "";
                txtId.Text = "";
                loadList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtId.Text != "")
            {
                con.Open();
                cmd.CommandText = "delete from info where id='"+txtId.Text+"'";
                cmd.ExecuteNonQuery();
                con.Close();
                txtId.Text = "";
                loadList();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtId.Text != "" & txtName.Text != "")
            {
                con.Open();
                cmd.CommandText = "update info set id='"+txtId.Text+"',name='"+txtName.Text+"' where id='"+listBox2.SelectedItem+"'";
                cmd.ExecuteNonQuery();
                con.Close();
                txtId.Text = "";
                txtName.Text = "";
                loadList();
            }
        }
        private void loadList()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            con.Open();
            cmd.CommandText = "select * from info";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    listBox2.Items.Add(dr[0].ToString());
                    listBox1.Items.Add(dr[1].ToString());
                }
            }
            con.Close();
        }
    }
}
