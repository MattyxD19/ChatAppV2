using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMExercises.Model
{
    class Message
    {
		private int id;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		private int conversationId;

		public int ConversationId
		{
			get { return conversationId; }
			set { conversationId = value; }
		}

		private int userId;

		public int UserId
		{
			get { return userId; }
			set { userId = value; }
		}

		public string Text { get; set; }

		public DateTime Date { get; set; }

		public bool Incoming { get; set; }


	}
}
