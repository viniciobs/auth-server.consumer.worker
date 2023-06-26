namespace AuthServer.Consumer.Worker.Settings
{
    public record ExternalServices(
        string MailSender,
        string MailConfirmation);
}