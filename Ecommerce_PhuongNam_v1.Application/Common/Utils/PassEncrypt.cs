﻿namespace Ecommerce_PhuongNam_v1.Application.Common.Utils
{
    public class PassEncrypt
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            string hashPass = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return hashPass;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="hashPassword"></param>
        /// <returns></returns>
        public static bool VerifyPassword (string password, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashPassword);
        }
    }
}
