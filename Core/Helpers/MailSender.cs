using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Reflection;
using System.Text;

namespace Core.Helpers;

public class MailSender
{
    private readonly SMTPOption _smtpOption;

    public MailSender(IOptions<SMTPOption> smtpOption)
    {
        _smtpOption = smtpOption.Value;
    }

    public async Task SendResetPasswordMail(string mailTo, string resetPasswordUrl)
    {
        // Get mail content
        var mailContent = GetResetPasswordMailContnent(resetPasswordUrl);

        // Create mail
        var mail = new MimeMessage();
        mail.From.Add(MailboxAddress.Parse(_smtpOption.MailAddress));
        mail.To.Add(MailboxAddress.Parse(mailTo));
        mail.Subject = "Reset Your Password";
        mail.Body = new TextPart("html") { Text = mailContent };

        await SendEmailAsync(mail);
    }

    private string GetResetPasswordMailContnent(string resetPasswordUrl)
    {
        var mailTamplte = GetMailTemplate("ResetPasswordMailTemplate.html");

        var mailContent = mailTamplte.Replace("{ResetPasswordUrl}", resetPasswordUrl);

        return mailContent;
    }

    private string GetMailTemplate(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourcePath = assembly.GetManifestResourceNames()
            .Single(str => str.EndsWith(resourceName)) ?? throw new Exception("Mail template resource not found");

        using Stream stream = assembly.GetManifestResourceStream(resourcePath) ?? throw new Exception("Mail template resource not found");
        using StreamReader reader = new StreamReader(stream, Encoding.UTF8);
        return reader.ReadToEnd();
    }

    private async Task SendEmailAsync(MimeMessage mail)
    {
        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_smtpOption.Host, _smtpOption.Port, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_smtpOption.Username, _smtpOption.Password);
        await smtp.SendAsync(mail);
        await smtp.DisconnectAsync(true);
    }
}

public class SMTPOption
{
    public const string SMTP = "SMTPServer";

    public string Host { get; set; } = null!;
    public int Port { get; set; }
    public string MailAddress { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}