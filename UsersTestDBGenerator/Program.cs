/*
 * Created by SharpDevelop.
 * User: GVadmin
 * Date: 07.04.2017
 * Time: 12:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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
			int count = 0;
			
			using(StreamReader reader = new StreamReader(path))
			{
				using(StreamWriter wrt = new StreamWriter(File.Create(targetPath)))
				{
				
					wrt.WriteLine("new User[]{");
					while(!reader.EndOfStream)
					{
						var personArray = reader.ReadLine().Split(',');
						int year = rnd.Next(-60, -17);
						int month = rnd.Next(-12,0);
						int day = rnd.Next(-30, 0);						
						var BirthDate = string.Format("DateTime.Now.AddYears({0}).AddMonths({1}).AddDays({2})",year, month, day);
						var result = string.Format("new User{{FirstName = \"{0}\", LastName = \"{1}\", Email = \"{2}\", Login = \"{3}\", Password = \"{4}\", " +
						                           "Sex = \"{5}\", Country = \"{6}\", PhoneNumber = \"{7}\", IsDeleted = false, UserRole = 0, ConfirmedEmail = true, BirthDate= {8}}}",
						                           personArray[0], personArray[1], personArray[2], string.Concat(personArray[3].Take(14)), PasswordEncryptor.GetHashString(personArray[4]),
						                           personArray[5].ToUpperInvariant(), personArray[6], personArray[7], BirthDate);
						if(count<99)
						{
							wrt.WriteLine(result+",");
						}
						else
						{
							wrt.WriteLine(result);
						}
						count++;
					}
					wrt.WriteLine("}");
				}
				
				
				
			}
			Console.ReadKey(true);
		}
	}
}