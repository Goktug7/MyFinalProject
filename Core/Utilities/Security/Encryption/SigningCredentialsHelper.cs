using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)//asp.net için
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            //hashing işlemi yapacaksın anahtar olarak securityKey kullan şifreleme olarak güvenlik algoritmalarında sha512 kullan
        }
    }
}
