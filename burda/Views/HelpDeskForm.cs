using burda.Controllers;
using burda.Helpers;
using burda.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace burda.Views
{
    public partial class HelpDeskForm : BaseForm
    {
        TicketController ticketController = new TicketController();
        public HelpDeskForm()
    {
        InitializeComponent();
    }
    private void HelpDeskPanel_Load(object sender, EventArgs e)
    {
            textBoxEmail.Focus();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string message = richTextBoxMessage.Text;
            if (email == "" || message == "" || email == null || message == null)
            {
                MessageBox.Show("Lütfen e-posta adresinizi ve mesajınızı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!email.Contains("@") || !email.Contains(".") || email.Length < 5)
            {
                MessageBox.Show("Lütfen geçerli bir e-posta adresi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            User emailUser = new UserController().FindUserByUserEmail(email);
            if (emailUser == null)
            {
                MessageBox.Show("Bu e-posta adresi ile kayıtlı bir kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Ticket ticket = new Ticket
            {
                Email = email,
                Message = message
            };

            ticketController.AddTicket(ticket);
            EmailHelper emailHelper = new EmailHelper();
            bool isSuccess = emailHelper.SendEmail(email, "BURDA: Yeni Destek Talebiniz", "Mesaj: " + message +
                "<br>" + "Tarih: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") +
                "<br>" + "Talebiniz alınmıştır. En kısa sürede dönüş yapılacaktır." +
                "<br>" + "BURDA Ekibi");

            if (isSuccess)
            {
                MessageBox.Show("E-posta adresinize bilgilendirme mesajı gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("E-posta gönderilirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBoxEmail.Clear();
            richTextBoxMessage.Clear();
            this.Close();
        }

    }
}