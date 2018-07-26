using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace WorkMadeEasy1
{
	public class Employee
	{
		string id;
		string eid;
		string fname;
		string lname;
		string email;
		string password;
		string cnumber;
		string question;
		string answer;

		[JsonProperty(PropertyName = "id")]
		public string Id
		{
			get { return id; }
			set { id = value; }
		}

		[JsonProperty(PropertyName = "Eid")]
		public string EId
		{
			get { return eid; }
			set { eid = value; }
		}

		[JsonProperty(PropertyName = "First_Name")]
		public string FirstName
		{
			get { return fname; }
			set { fname = value; }
		}

		[JsonProperty(PropertyName = "Last_Name")]
		public string LastName
		{
			get { return lname; }
			set { lname = value; }
		}

		[JsonProperty(PropertyName = "Email")]
		public string Email
		{
			get { return email; }
			set { email = value; }
		}

		[JsonProperty(PropertyName = "Password")]
		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		[JsonProperty(PropertyName = "ContactNumber")]
		public string ContactNumber
		{
			get { return cnumber; }
			set { cnumber = value; }
		}

		[JsonProperty(PropertyName = "Question")]
		public string SecurityQuestion
		{
			get { return question; }
			set { question = value; }
		}

		[JsonProperty(PropertyName = "Answer")]
		public string Answer
		{
			get { return answer; }
			set { answer = value; }
		}

	}
}
