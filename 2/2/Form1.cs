using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _2
{
    public partial class Form1 : Form
    {   SqlConnection  sqlConnection;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Соня\Desktop\учеба\кремза\уп\2\2\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
        }

    //ВЫБОРКА
        private async void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [отдыхающие]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync()) {
                    listBox1.Items.Add(
                        Convert.ToString(sqlReader["ид_отдыхающего"]) + "     "+
                        Convert.ToString(sqlReader["ФИО"]) + "     " +
                        Convert.ToString(sqlReader["ид_номера"]) + "     " +
                        Convert.ToString(sqlReader["ид_гида"]) + "     " +
                        Convert.ToString(sqlReader["ид_путевки"])
                        );
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),ex.Source.ToString(), MessageBoxButtons.OK);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        
        }
       

        private async void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Гиды]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox2.Items.Add(
                        Convert.ToString(sqlReader["ид_гида"]) + "     " +
                        Convert.ToString(sqlReader["ФИО"]) + "     " +
                        Convert.ToString(sqlReader["возраст"]) )
                        ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Номера]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox3.Items.Add(
                        Convert.ToString(sqlReader["ид_номера"]) + "     " +
                        Convert.ToString(sqlReader["кол_во_комнат"]) + "     " +
                        Convert.ToString(sqlReader["класс"]) + "     " +
                        Convert.ToString(sqlReader["кол_во_кроватей"]))
                        ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [путевки]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox4.Items.Add(
                        Convert.ToString(sqlReader["ид_путевки"]) + "     " +
                        Convert.ToString(sqlReader["дата_выезда"]) + "     " +
                        Convert.ToString(sqlReader["дата_заезда"]) )
                        ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

        }
        // ЗАКРЫТИЕ 


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }
        //ДОБАВЛЕНИЕ
        private async void button5_Click(object sender, EventArgs e)
        {
            if(label1.Visible) label1.Visible = false;
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [отдыхающие](ид_отдыхающего,ФИО,ид_гида,ид_номера,ид_путевки) VALUES (@ид_отдыхающего,@ФИО,@ид_номера,@ид_путевки,@ид_гида) ", sqlConnection);
               command.Parameters.AddWithValue("ид_отдыхающего", textBox1.Text);
                command.Parameters.AddWithValue("ФИО", textBox2.Text);
                command.Parameters.AddWithValue("ид_гида", textBox3.Text);
                command.Parameters.AddWithValue("ид_номера", textBox5.Text);
                command.Parameters.AddWithValue("ид_путевки", textBox4.Text);
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label1.Visible = true;
                label1.Text = "Идентификатор не заполнен";
            }
            
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            if (label12.Visible) label12.Visible = false;
            if (!string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Гиды](ид_гида,ФИО,возраст) VALUES (@ид_гида,@ФИО,@возраст) ", sqlConnection);
                command.Parameters.AddWithValue("ид_гида", textBox10.Text);
                command.Parameters.AddWithValue("ФИО", textBox9.Text);
                command.Parameters.AddWithValue("возраст", textBox8.Text);
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label12.Visible = true;
                label12.Text = "Идентификатор не заполнен";
            }
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            if (label28.Visible) label28.Visible = false;
            if (!string.IsNullOrEmpty(textBox21.Text) && !string.IsNullOrWhiteSpace(textBox21.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Номера](ид_номера, кол_во_комнат, класс, кол_во_кроватей) VALUES (@ид_номера, @кол_во_комнат, @класс, @кол_во_кроватей) ", sqlConnection);
                command.Parameters.AddWithValue("ид_номера", textBox21.Text);
                command.Parameters.AddWithValue("кол_во_комнат", textBox18.Text);
                command.Parameters.AddWithValue("класс", textBox17.Text);
                command.Parameters.AddWithValue("кол_во_кроватей", textBox22.Text);
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label28.Visible = true;
                label28.Text = "Идентификатор не заполнен";
            }
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            if (label34.Visible) label34.Visible = false;
            if (!string.IsNullOrEmpty(textBox26.Text) && !string.IsNullOrWhiteSpace(textBox26.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [путевки](ид_путевки, дата_заезда, дата_выезда) VALUES (@ид_путевки, @дата_заезда, @дата_выезда) ", sqlConnection);
                command.Parameters.AddWithValue("ид_путевки", textBox26.Text);
                command.Parameters.AddWithValue("дата_заезда", textBox25.Text);
                command.Parameters.AddWithValue("дата_выезда", textBox24.Text);
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label34.Visible = true;
                label34.Text = "Идентификатор не заполнен";
            }
        }

       
        //ИЗМЕНЕНИЕ
        private async void button7_Click(object sender, EventArgs e)
        {
            if (label18.Visible) label18.Visible = false;
            if (!string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text) &&
                !string.IsNullOrEmpty(textBox14.Text) && !string.IsNullOrWhiteSpace(textBox14.Text) &&
                !string.IsNullOrEmpty(textBox13.Text) && !string.IsNullOrWhiteSpace(textBox13.Text) &&
                !string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text) &&
                !string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text))
            {
                SqlCommand command= new SqlCommand("UPDATE [отдыхающие] SET [ид_отдыхающего]=@ид_отдыхающего,[ФИО]=@ФИО,[ид_гида]=@ид_гида,[ид_номера]=@ид_номера,[ид_путевки]=@ид_путевки  WHERE [ид_отдыхающего]=@ид_отдыхающего", sqlConnection);
                command.Parameters.AddWithValue("ид_отдыхающего", textBox15.Text);
                command.Parameters.AddWithValue("ФИО", textBox14.Text);
                command.Parameters.AddWithValue("ид_гида", textBox13.Text);
                command.Parameters.AddWithValue("ид_номера", textBox12.Text);
                command.Parameters.AddWithValue("ид_путевки", textBox11.Text);
                await command.ExecuteNonQueryAsync();
            }
            else if (!string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text)) {
                label18.Visible = true;
                label18.Text = "Идентификатор не заполнен";
            };
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            if (label20.Visible) label20.Visible = false;
            if (!string.IsNullOrEmpty(textBox16.Text) && !string.IsNullOrWhiteSpace(textBox16.Text) &&
                !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) )
            {
                SqlCommand command = new SqlCommand("UPDATE [Гиды] SET [ид_гида]=@ид_гида,[ФИО]=@ФИО,[возраст]=@возраст WHERE [ид_гида]=@ид_гида", sqlConnection);
                command.Parameters.AddWithValue("ид_гида", textBox16.Text);
                command.Parameters.AddWithValue("ФИО", textBox7.Text);
                command.Parameters.AddWithValue("возраст", textBox4.Text);
                await command.ExecuteNonQueryAsync();
            }
            else if (!string.IsNullOrEmpty(textBox16.Text) && !string.IsNullOrWhiteSpace(textBox16.Text))
            {
                label20.Visible = true;
                label20.Text = "Идентификатор не заполнен";
            };
        }

        private async void button13_Click(object sender, EventArgs e)
        {

            if (label42.Visible) label42.Visible = false;
            if (!string.IsNullOrEmpty(textBox32.Text) && !string.IsNullOrWhiteSpace(textBox32.Text) &&
                !string.IsNullOrEmpty(textBox31.Text) && !string.IsNullOrWhiteSpace(textBox31.Text) &&
                !string.IsNullOrEmpty(textBox30.Text) && !string.IsNullOrWhiteSpace(textBox30.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [путевки] SET [ид_путевки]=@ид_путевки,[дата_выезда]=@дата_выезда ,[дата_заезда]=@дата_заезда WHERE [ид_путевки]=@ид_путевки", sqlConnection);
                command.Parameters.AddWithValue("ид_путевки", textBox32.Text);
                command.Parameters.AddWithValue("дата_выезда", textBox31.Text);
                command.Parameters.AddWithValue("дата_заезда", textBox30.Text);
                await command.ExecuteNonQueryAsync();
            }
            else if (!string.IsNullOrEmpty(textBox32.Text) && !string.IsNullOrWhiteSpace(textBox32.Text))
            {
                label42.Visible = true;
                label42.Text = "Идентификатор не заполнен";
            };
        }
        //УДАЛЕНИЕ
        private async void button8_Click(object sender, EventArgs e)
        {
            if (label24.Visible) label24.Visible = false;
            if (!string.IsNullOrEmpty(textBox20.Text) && !string.IsNullOrWhiteSpace(textBox20.Text))
            {
                SqlCommand command = new SqlCommand("DELETE  FROM  [отдыхающие]  WHERE [ид_отдыхающего]=@ид_отдыхающего", sqlConnection);
                command.Parameters.AddWithValue("ид_отдыхающего", textBox20.Text);
                await command.ExecuteNonQueryAsync();
            }
            else if (!string.IsNullOrEmpty(textBox20.Text) && !string.IsNullOrWhiteSpace(textBox20.Text))
            {
                label24.Visible = true;
                label24.Text = "Идентификатор не заполнен";
            };
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            if (label26.Visible) label26.Visible = false;
            if (!string.IsNullOrEmpty(textBox19.Text) && !string.IsNullOrWhiteSpace(textBox19.Text))
            {
                SqlCommand command = new SqlCommand("DELETE  FROM  [Гиды]  WHERE [ид_гида]=@ид_гида", sqlConnection);
                command.Parameters.AddWithValue("ид_гида", textBox19.Text);
                await command.ExecuteNonQueryAsync();
            }
            else if (!string.IsNullOrEmpty(textBox19.Text) && !string.IsNullOrWhiteSpace(textBox19.Text))
            {
                label26.Visible = true;
                label26.Text = "Идентификатор не заполнен";
            };
        }

        private async void button15_Click(object sender, EventArgs e)
        {
            if (label47.Visible) label47.Visible = false;
            if (!string.IsNullOrEmpty(textBox36.Text) && !string.IsNullOrWhiteSpace(textBox36.Text))
            {
                SqlCommand command = new SqlCommand("DELETE  FROM  [Номера]  WHERE [ид_номера]=@ид_номера", sqlConnection);
                command.Parameters.AddWithValue("ид_номера", textBox36.Text);
                await command.ExecuteNonQueryAsync();
            }
            else if (!string.IsNullOrEmpty(textBox36.Text) && !string.IsNullOrWhiteSpace(textBox36.Text))
            {
                label47.Visible = true;
                label47.Text = "Идентификатор не заполнен";
            };
        }

        private async void button16_Click(object sender, EventArgs e)
        {
            if (label48.Visible) label48.Visible = false;
            if (!string.IsNullOrEmpty(textBox35.Text) && !string.IsNullOrWhiteSpace(textBox35.Text))
            {
                SqlCommand command = new SqlCommand("DELETE  FROM  [путевки]  WHERE [ид_путевки]=@ид_путевки", sqlConnection);
                command.Parameters.AddWithValue("ид_путевки", textBox35.Text);
                await command.ExecuteNonQueryAsync();
            }
            else if (!string.IsNullOrEmpty(textBox35.Text) && !string.IsNullOrWhiteSpace(textBox35.Text))
            {
                label48.Visible = true;
                label48.Text = "Идентификатор не заполнен";
            };
        }
    }
}
