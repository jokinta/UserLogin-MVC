using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace UserLogin1
{
    public class User
    {
        private byte[] bytes = new byte[] {1,2, 3, 4, 5, 6, 7, 8};
    public static string ComputeHash(string input, HashAlgorithm algorithm, Byte[] salt)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Combine salt and input bytes
            Byte[] saltedInput = new Byte[salt.Length + inputBytes.Length];
            salt.CopyTo(saltedInput, 0);
            inputBytes.CopyTo(saltedInput, salt.Length);

            Byte[] hashedBytes = algorithm.ComputeHash(saltedInput);

            return BitConverter.ToString(hashedBytes);
        }

        public string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private int fakNomer;
        public int FakNomer
        {
            get { return fakNomer; }
            set { fakNomer = value; }
        }
        private Int32 role;
        public Int32 Role
        {
            get { return role; }
            set { role = value; }
        }

        private DateTime created;
        public DateTime Created
        {
            get { return created; }
            set { created = value; }
        }
        private DateTime? activeTime;
        public DateTime? ActiveTime
        {
            get { return activeTime; }
            set { activeTime = value; }
        }

        public Int32 UserId { get; set; }  



        public User (string userName, string password, int fakNomer, Int32 role)
        {
            UserName = userName;
            Password = ComputeHash(password, new SHA256CryptoServiceProvider(), bytes);
            FakNomer = fakNomer;
            Role = role;
            Created = DateTime.Now;
            ActiveTime = DateTime.MaxValue;
        }

        public User (string userName, string password)
        {

            UserName = userName;
            Password = ComputeHash(password, new SHA256CryptoServiceProvider(), bytes);
            
        }

        public User()
        {

        }
 
    }

    internal class BigInteger
    {
    }
}
