using System.Linq;

namespace WebshopAPI.Lib
{
    public static class Extensions
    {

        public static async Task WriteLogAsync(this Log log)
        {
            using (SQL sql = new SQL())
            {
                await sql.Logs.AddAsync(log);
                await sql.SaveChangesAsync();
            }
        }

        public static void WriteLog(this Log log)
        {
            using (SQL sql = new SQL())
            {
                sql.Logs.Add(log);
                sql.SaveChanges();
            }
        }

        public static async Task WriteLogAsync(this string message)
        {
            await WriteLogAsync(new Log()
            {
                Message = message
            });
        }

        public static void WriteLog(this string message)
        {
            WriteLog(new Log()
            {
                Message = message
            });
        }

        public static async Task WriteLogAsync(this string message, string userId)
        {
            await WriteLogAsync(new Log()
            {
                Message = message,
                UserEmail = userId
            });
        }

        public static void WriteLog(this string message, string UserId)
        {
            WriteLog(new Log()
            {
                Message = message,
                UserEmail = UserId
            });
        }

        public static void WriteError(this string message)
        {
            WriteLog(new Log()
            {
                Message = message,
                Severity = ESeverity.Error
            });
        }

        public static async Task WriteErrorAsync(this string message)
        {
            await WriteLogAsync(new Log()
            {
                Message = message,
                Severity = ESeverity.Error
            });
        }

        public static void WriteError(this string message, string UserID)
        {
            WriteLog(new Log()
            {
                Message = message,
                Severity = ESeverity.Error,
                UserEmail = UserID
            });
        }

        public static async Task WriteErrorAsync(this string message, string UserID)
        {
            await WriteLogAsync(new Log()
            {
                Message = message,
                Severity = ESeverity.Error,
                UserEmail = UserID
            });
        }

        public static string Dump(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string GetExceptionMessage(this Exception e)
        {
            return (e.InnerException != null ? (e.InnerException.InnerException != null ? (e.InnerException.InnerException.InnerException != null ? e.InnerException.InnerException.InnerException.Message : e.InnerException.InnerException.Message) : e.InnerException.Message) : e.Message);
        }

        public static int CountOf(this string message, char character)
        {
            int count = 0;
            foreach (char c in message)
            {
                if (c == character)
                {
                    count++;
                }
            }
            return count;
        }

        public static int CountOf(this string message, string character)
        {
            return message.CountOf(char.Parse(character));
        }
    }
}
