using System;

namespace TightCoupling
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataAccess dal = new DataAccess();
            IBusiness biz = new Business(dal);
            var userInterface = new UserInterface(biz);
        }
    }
    public class UserInterface
    {
        private readonly IBusiness _business;
        public UserInterface(IBusiness business)
        {
            _business = business;
        }
        public void GetData()
        {
            Console.Write("Enter your username:");
            var userName = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            var password = Console.ReadLine();

            IDataAccess dal = new DataAccess();
            IBusiness business = new Business(dal);
            _business.SignUp(userName, password);
        }

    }
    public class BusinessV2 : IBusiness
    {
        void IBusiness.SignUp(string userName, string password)
        {
           //new implementation of the SignUp
        }
    }
    public class Business : IBusiness
    {
        private readonly IDataAccess _dataAccess;
        public Business(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public void SignUp(string userName, string password)
        {
            //validation for the userName and the passwrod;
            
            _dataAccess.Store(userName, password);
        }
    }

    public class DataAccess : IDataAccess
    {
        public void Store(string userName, string password)
        {
            //write the data to db
        }
    }

    public interface IBusiness
    {
        void SignUp(string userName, string password);
    }
    public interface IDataAccess
    {
        void Store(string username, string password);
    }
}
