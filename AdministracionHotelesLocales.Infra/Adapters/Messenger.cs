using AdministracionHotelesLocales.Infra.Ports;

namespace AdministracionHotelesLocales.Infra.Adapters
{
    public class Messenger : IMessenger
    {
        public async Task SendEmail(string EmailReceiver)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"Enviando Mensaje a {EmailReceiver}");
            });
        }
    }
}
