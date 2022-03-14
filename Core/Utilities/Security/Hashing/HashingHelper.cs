using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash// şifrenin salt ve hash değerlerini oluşturuyor
            (string password, out byte[] passwordHash, out byte[] passwordSalt)//out birden fazla veriyi döndürmek için
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())//hash oluştururken kullanılan algoritma
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//stringin byte değerini almak için
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)//password hashi doğrula
        {//sonradan sisteme girmek isteyen kişinin verdiği passwordun bizim veri kaynağımızdaki hashle ilgili salta göre eşleşip eşleşmediğini verdiğimiz yer
           
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))//doğrularken aynı algoritma ama daha önce oluştururken kullandığımız tuzu kullanarak onu doğruluyroz
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//hesaplanan hash
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])//passwordhash veritabanından gelen
                    {
                        return false;
                    }
                }
                return true;

            }
        }
    }
}
