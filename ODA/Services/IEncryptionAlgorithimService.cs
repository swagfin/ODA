using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.Services
{
   public interface IEncryptionAlgorithimService
    {
        string Encrypt(string data, string passPhrase);
        string Decrypt(string data, string passPhrase);
    }

}
