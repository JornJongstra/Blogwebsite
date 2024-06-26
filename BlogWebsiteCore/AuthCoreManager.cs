﻿using System.Text;
using System.Security.Cryptography;
using Classes;
using System.Text.RegularExpressions;

namespace BlogWebsiteCore
{
    public class AuthCoreManager
    {
        public User LoginCheck(string email, string password)
        {
			string hashedPassword = ComputeSha256Hash(password);

            if (string.IsNullOrWhiteSpace(email)) return null;
            if (string.IsNullOrWhiteSpace(password)) return null;
            string regexEmail = @"^[^@\s]+@[^@\s]+.(com|net|org|gov|nl)$";
            if (!Regex.IsMatch(email, regexEmail)) return null;

            var storedUser = ServiceHandler.Service.GetUserByEmail(email);
			if (storedUser.Password == hashedPassword)
			{
				return storedUser;
			}
            return null;
        }

		public bool RegisterUser(User user)
		{
			if (!RegisterInputCheck(user)) return false;
			user.SetPassword(ComputeSha256Hash(user.Password));

			if (ServiceHandler.Service.CreateUser(user))
			{
				return true;
			}
			return false;
		}

		static string ComputeSha256Hash(string rawData)
		{
			// Create a SHA256
			using (SHA256 sha256Hash = SHA256.Create())
			{
				// ComputeHash - returns byte array
				byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

				// Convert byte array to a string
				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < bytes.Length; i++)
				{
					builder.Append(bytes[i].ToString("x2"));
				}
				return builder.ToString();
			}
		}
		private bool RegisterInputCheck(User user)
		{
			if (string.IsNullOrWhiteSpace(user.Username)) return false;
			if (string.IsNullOrWhiteSpace(user.Email)) return false;
			if (string.IsNullOrWhiteSpace(user.Password)) return false;

            if (!Regex.IsMatch(user.Username, @"^[a-zA-Z0-9]+$")) return false;
            string regexEmail = @"^[^@\s]+@[^@\s]+.(com|net|org|gov|nl)$";
            if (!Regex.IsMatch(user.Email, regexEmail)) return false;
            if (user.Password.Length < 6) return false;

            return true;
		}
    }
}
