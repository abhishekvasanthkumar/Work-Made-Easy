using System;
using Newtonsoft.Json;

namespace WorkMadeEasy1
{
	public class Schedule
	{
		string id;
		string workplace;
		string shift;
		string day;
		string eid;

		[JsonProperty(PropertyName = "id")]
		public string Id
		{
			get { return id; }
			set { id = value; }
		}

		[JsonProperty(PropertyName = "Workplaces")]
		public string Workplace
		{
			get { return workplace; }
			set { workplace = value; }
		}

		[JsonProperty(PropertyName = "Days")]
		public string Day
		{
			get { return day; }
			set { day = value; }
		}


		[JsonProperty(PropertyName = "Shifts")]
		public string Shift
		{
			get { return shift; }
			set { shift = value; }
		}

		[JsonProperty(PropertyName = "Eid")]
		public string EmployeeId
		{
			get { return eid; }
			set { eid = value; }
		}

	}
}
