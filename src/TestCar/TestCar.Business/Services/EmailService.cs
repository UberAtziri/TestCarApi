using System;
using TestCar.Business.Services.Interfaces;

namespace TestCar.Business.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string message, string reciever)
        {
            Console.WriteLine("Job done!");
        }
    }
}