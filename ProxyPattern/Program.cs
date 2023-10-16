using System;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
// This program is to implement a proxy pattern. The proxy is designed to check if a client has access before calling the main 
program that would generate a random secret code.
//
namespace ProxyPattern
{
    class Example
    {
        public interface IInformation
        {
            int GetInformation();

        }
        public class SecretInformation :IInformation
        {
            public int GetInformation()
            {
                Random codeNumber = new Random();
                return codeNumber.Next(0, 99999);
            }
            
        }
        public class Proxy
        {
            IInformation secretInfo;
            public int GetSecretInfo(bool hasSecurityClearance = false)
            {
                if (hasSecurityClearance)        // if the boolean value is true, the proxy will proceed to call the original class 
                {
                    secretInfo = new SecretInformation(); // assigns secret info to an initialisation of the class SecretInformation
                    return secretInfo.GetInformation();   // Uses the GetInformation method to retrieve a random secret code
                }else
                {
                    return -1; 
                }
            }
        }

        public static void Main(string[] args)
        {
            Proxy proxy = new Proxy();
            int info = proxy.GetSecretInfo(true);  // assigns info to the method GetSecretInfo called from class Proxy 
            Debug.WriteLine("secret info  is " + info);
        }

    }

}
