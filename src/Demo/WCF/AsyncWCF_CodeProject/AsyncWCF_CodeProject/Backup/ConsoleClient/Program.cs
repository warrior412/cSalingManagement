using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCFServiceContract;
using WCFCommon;
namespace ConsoleClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Main started.....");
               
                AddServiceAsyncWithDataContract();
                
                Console.WriteLine("Execution of Main continue");
                for (int i = 0; i < 40; i++)
                {
                    Console.WriteLine(i.ToString());
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Console.WriteLine("Main ends here.....Press any key to exit.");
                Console.ReadLine();
            }
        }

        #region AddService

        static ProxyFactory<IAddService> addProxy = null;
        static IAddService service = null;

        static void AddServiceAsyncWithDataContract()
        {
            try
            {
                Console.Title = "Asynchronous Pattern in Windows Communication Foundation";

                Console.WriteLine("Enter Number 1:");
                int number1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Number 2:");
                int number2 = Convert.ToInt32(Console.ReadLine());
                AddDataContract input = new AddDataContract();
                input.Nbr1 = number1;
                input.Nbr2 = number2;
                Console.ForegroundColor = ConsoleColor.Yellow;
                addProxy = new ProxyFactory<IAddService>("AddService");
                service = addProxy.CreateProxy();
                Console.WriteLine("Proxy created.");
                Console.WriteLine("Calling BeginAdd of WCF service");
                IAsyncResult res = service.BeginAddDC(input, new AsyncCallback(AddCallbackDC), service);
                Console.WriteLine("Sent request BeginAdd of WCF service");
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Console.ResetColor();
            }
        }
        static void AddCallbackDC(IAsyncResult ar)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("in AddCallbackDC");
                IAddService res = ar.AsyncState as IAddService;
                if (res != null)
                {
                    Console.WriteLine("Result returned from WCF service");
                    Console.WriteLine(res.EndAddDC(ar).Result.ToString());
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (addProxy != null)
                {
                    addProxy.CloseProxy();
                    Console.WriteLine("Proxy closed.");
                }
                Console.ResetColor();
            }
        }

        static void AddServiceAsync()
        {
            Console.Title = "Asynchronous Pattern in Windows Communication Foundation";

            Console.WriteLine("Enter Number 1:");
            int number1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Number 2:");
            int number2 = Convert.ToInt32(Console.ReadLine());
            addProxy = new ProxyFactory<IAddService>("AddService");
            service = addProxy.CreateProxy();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Calling BeginAdd of WCF service");
            IAsyncResult res= service.BeginAdd(number1, number2, new AsyncCallback(AddCallback), service);
            Console.WriteLine("Sent request BeginAdd of WCF service");
            Console.ResetColor();
        }
        static void AddCallback(IAsyncResult ar)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("in AddCallback");
                IAddService res = ar.AsyncState as IAddService;
                if (res != null)
                {
                    Console.WriteLine("Result from callback");
                    Console.WriteLine(res.EndAdd(ar).ToString());
                }
            }
            finally
            {
                Console.ResetColor();
                if (addProxy != null)
                    addProxy.CloseProxy();
            }
        }

        #endregion AddService
    }
}
