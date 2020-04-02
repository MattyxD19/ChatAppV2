using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMExercises.Model
{
    class Conversation
    {
		private int id;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		private int userId;

		public int UserId
		{
			get { return userId; }
			set { userId = value; }
		}

		private string usernName;

		public string UserName
		{
			get { return usernName; }
			set { usernName = value; }
		}

		public string LastMessage { get; set; }

	}
}
