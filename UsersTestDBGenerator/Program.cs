using System;
using System.IO;
using System.Linq;

namespace UsersTestDBGenerator
{
	class Program
	{
		public static Random rnd = new Random();
		public static void Main(string[] args)
		{
			var path =@"DATA\users_testDB.csv";
			var targetPath = @"DATA\users_testDB.cs";
			string[] countrees = { "England", "Australia", "Germany", "France", "Belarus" }; 
			
			using(StreamReader reader = new StreamReader(path))
			{
				using(StreamWriter wrt = new StreamWriter(File.Create(targetPath)))
				{
				
					wrt.WriteLine("new User[]{");
					while(!reader.EndOfStream)
					{
						var personArray = reader.ReadLine().Split(',');
						int year = rnd.Next(1970, 2000);
						int month = rnd.Next(1,12);
						int day = rnd.Next(1, 28);
						var BirthDate = string.Format("DateTime.Parse(\"{0}.{1}.{2}\", new System.Globalization.CultureInfo(\"ru-ru\", true))",day, month, year);
						//var BirthDate = string.Format("DateTime.Now.AddYears({0}).AddMonths({1}).AddDays({2})",year, month, day);
						
						var result = string.Format("new User{{FirstName = \"{0}\", LastName = \"{1}\", Email = \"{2}\", Login = \"{3}\", Password = \"{4}\", " +
												   "Sex = \"{5}\", Country = \"{6}\", PhoneNumber = \"{7}\", IsDeleted = false, UserRole = 0, ConfirmedEmail = true, BirthDate= {8}}},",
												   personArray[0], personArray[1], personArray[2], string.Concat(personArray[3].Take(14)), PasswordEncryptor.GetHashString(personArray[4]),
												   personArray[5].ToUpperInvariant(), countrees[rnd.Next(0,5)], personArray[7], BirthDate);
						wrt.WriteLine(result);
					}
					wrt.WriteLine($"new User{{FirstName = \"test_user\", LastName = \"test_user\", Email = \"test_user@gmail.com\", Login = \"test_user\", Password = \"{PasswordEncryptor.GetHashString("test_user1!")}\", " +
												   "Sex = \"M\", Country = \"Belarus\", PhoneNumber = \"(29) 227 02 83\", IsDeleted = false, UserRole = 0, ConfirmedEmail = true},");
					wrt.WriteLine($"new User{{FirstName = \"test_admin\", LastName = \"test_admin\", Email = \"test_admin@gmail.com\", Login = \"test_admin\", Password = \"{PasswordEncryptor.GetHashString("test_admin1!")}\", " +
							   "Sex = \"M\", Country = \"Belarus\", PhoneNumber = \"(29) 227 02 83\", IsDeleted = false, UserRole = UserRoles.Admin, ConfirmedEmail = true}");
					wrt.WriteLine("}");
				}
				
				
				
			}
			Console.ReadKey(true);
		}
	}
}