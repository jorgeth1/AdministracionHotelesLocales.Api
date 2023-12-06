namespace AdministracionHotelesLocales.Infra.Ports
{
    public interface IMessenger
    {
        Task SendEmail(string EmailReceiver);
    }
}
