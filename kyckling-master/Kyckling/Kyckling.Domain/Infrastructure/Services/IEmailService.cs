using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Kyckling.Domain.Models;

namespace Kyckling.Domain.Infrastructure.Services
{
    public interface IEmailService
    {
        void Send(MailMessage mail);

        MailMessage GenerateReservationConfirmation(Reservation reservation);

        MailMessage GenerateCancellationConfirmation(Reservation reservation);

        MailMessage GenerateActivationMail(User user);
    }
}
