using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static API.Enums;

namespace API.Helpers
{
    public static class Extensions
    {

        public static string ToMD5(this String input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                    sb.Append(hashBytes[i].ToString("X2"));     //--- formattazione in esadecimale
                
                return sb.ToString();
            }
        }

        public static string ToMessage(this ErrorCode input)
        {
            var msg = "";
            switch (input)
            {
                case ErrorCode.InvalidExam: 
                    msg = "Invalid Date/duration/topic of exam 😱";
                    break;
                case ErrorCode.RequiredOtherFields:
                    msg = "";
                    break;
                case ErrorCode.IDInUse:
                    msg = "";
                    break;
                case ErrorCode.RecordNotFound:
                    msg = "";
                    break;
                case ErrorCode.CouldNotCreate:
                    msg = "";
                    break;
                case ErrorCode.CouldNotUpdate:
                    msg = "";
                    break;
                case ErrorCode.CouldNotDelete:
                    msg = "";
                    break;
                case ErrorCode.Unauthorized:
                    msg = "you are not authorized! 😱";
                    break;
                case ErrorCode.InvalidCredential:
                    msg = "Username or password is incorrect 😱";
                    break;
                default:
                    msg = $"Error! {input} 😡";
                    break;
            }
            
            if(string.IsNullOrWhiteSpace(msg))
               return $"Error! {input} 😡";

            return msg;
        }
    }
}
