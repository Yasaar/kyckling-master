using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Kyckling.Domain.Models;

namespace Kyckling.Domain.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private SmtpClient _client;
        

        public EmailService()
        {
            _client = new SmtpClient();

           
           
        }
        public void Send(MailMessage mail)
        {
            //"Skicka" mailet här.


            // Spottar ur all Mail till mappen EmailContent i Projectet
            _client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            
            _client.PickupDirectoryLocation = HttpRuntime.AppDomainAppPath + "EmailContent";

            
          

            _client.Send(mail);
        }

        public MailMessage GenerateReservationConfirmation(Reservation reservation)
        {
            var mail = new MailMessage("bokning@kycklingrestauranger.se", reservation.Email);
            mail.IsBodyHtml = true;
            string subject = "Bokningsbekräftelse - " + reservation.Restaurant.Name;
            mail.Subject = subject;

            var body = "<h2>Hej " + reservation.Name + "!</h2><br/>";
            body += "Du har bokat bord på restaurang <b>" + reservation.Restaurant.Name + "</b> den " +
                    reservation.TimeSlot + " för " + reservation.PersonCount + " personer.";

            mail.Body = body;

            SmtpClient client = new SmtpClient();
            client.PickupDirectoryLocation = "";
            
           
            
            return mail;
        }

        public MailMessage GenerateCancellationConfirmation(Reservation reservation)
        {
            var mail = new MailMessage("bokning@kycklingrestauranger.se", reservation.Email);
            mail.IsBodyHtml = true;
            string subject = "Avbokningsbekräftelse - " + reservation.Restaurant.Id;
            mail.Subject = subject;

            var body = "<h2>Hej " + reservation.Name + "!</h2><br/>";
            body += "Du har avbokat ditt bord på restaurang <b>" + reservation.Restaurant.Id + "</b> den " +
                    reservation.TimeSlot + " för " + reservation.PersonCount + " personer.";

            mail.Body = body;
            return mail;
        }

        public MailMessage GenerateActivationMail(User user)
        {
            var mail = new MailMessage("aktivering@kycklingrestauranger.se", user.Email);
                mail.IsBodyHtml = true;

                var subject = "Aktivering av konto: Kyckling Restaurangbokningar";
                var body = "<h2>Hej " + user.Firstname + "</h2>!<br/>";
                body += "För att aktivera ditt konto och registrera en restaurang, vänligen klicka på följande länk:<br/>";
                //Länk till aktivering, typ "Acivate", "User"
                body += "<a href=\"~/Account/Activate/" + user.UserId + "\" target=\"_blank\"/>";

                mail.Subject = subject;
                mail.Body = body;

            return mail;
        }
    }
}
