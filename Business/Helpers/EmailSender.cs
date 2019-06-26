using System;
using System.Collections.Generic;
using System.Net.Mail;
using TimeshEAT.Business.Logging.Interfaces;
using TimeshEAT.Business.Logging.Wrappers;
using TimeshEAT.Common;

namespace TimeshEAT.Business.Helpers
{
    public class EmailSender
    {
        private readonly ILogger _logger;

        public EmailSender(ILogger logger = null)
        {
            _logger = logger ?? new SerilogWrapper(AppSettings.SerilogPath);
        }

        public void Send(string receiver, string sender, string subject, string message, IEnumerable<Attachment> attachments = null)
        {
            try
            {
                MailAddress senderAddress = new MailAddress(sender);
                MailAddress receiverAddress = new MailAddress(receiver);
                MailMessage mailMessage = new MailMessage(senderAddress, receiverAddress);
                mailMessage.Subject = subject;
                mailMessage.Body = message;
                if (attachments != null)
                {
                    foreach (Attachment attachment in attachments)
                    {
                        mailMessage.Attachments.Add(attachment);
                    }
                }

                new SmtpClient().Send(mailMessage);
            }
            catch (Exception ex)
            {
                _logger.WriteErrorLog("Error occured while sending email", ex);
                throw;
            }
        }
    }
}
