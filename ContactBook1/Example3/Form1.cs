using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Example3
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

            LoadContacts();
        }

        BLL bll = default(BLL);

        private void LoadContacts()
        {

            
            ContactDB contacts2 = new ContactDB();

            bll = new BLL(contacts2);

            bindingSource1.DataSource = bll.GetContacts();


            bindingNavigator1.BindingSource = bindingSource1;
            dataGridView1.DataSource = bindingSource1;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = bll.GetContacts().Count.ToString();
            bindingSource1.DataSource = bll.GetContacts();
        }

       

        CreateContactForm createContactForm = new CreateContactForm();
        CreateContactCommand command;



        private void button2_Click(object sender, EventArgs e)
        {
            if (createContactForm.ShowDialog() == DialogResult.OK)
            {
                command = new CreateContactCommand();
                command.Name = createContactForm.nameTxtBx.Text;
                command.Phone = createContactForm.phoneTxtBx.Text;
                command.Addr = createContactForm.addressTxtBx.Text;
                bll.CreateContact(command);
                bindingSource1.DataSource = bll.GetContacts();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(createContactForm.ShowDialog() == DialogResult.OK)
            {
               
                command.Name = createContactForm.nameTxtBx.Text;
                command.Phone = createContactForm.phoneTxtBx.Text;
                command.Addr = createContactForm.addressTxtBx.Text;
                bll.UpdateContactById(dataGridView1.CurrentRow.Cells["Id"].Value.ToString(), command);
                bindingSource1.DataSource = bll.GetContacts();
            }
        }

        

        

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            bll.DeleteContact(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());

        }

       
    }
}
