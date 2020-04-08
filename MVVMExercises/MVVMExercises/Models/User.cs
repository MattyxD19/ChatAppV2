using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMExercises.Models
{
    class User
    {
		private int id;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}


		private string username;

		public string Username
		{
			get { return username; }
			set { username = value; }
		}

		private string password;

		public  string Password
		{
			get { return password; }
			set { password = value; }
		}


	}
}
