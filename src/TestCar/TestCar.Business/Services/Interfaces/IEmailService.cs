namespace TestCar.Business.Services.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(string message, string reciever);
    }
}