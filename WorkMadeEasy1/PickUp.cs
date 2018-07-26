using System;
using Newtonsoft.Json;

namespace WorkMadeEasy1
{
	public class PickUp
	{
		string id;
		string workplace;
		string shift;
		string day;
		bool ispicked;
		string cid;
		string pid;

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


		[JsonProperty(PropertyName = "Workdays")]
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

		[JsonProperty(PropertyName = "isPickedup")]
		public bool IsPickedUp
		{
			get { return ispicked; }
			set { ispicked = value; }
		}

		[JsonProperty(PropertyName = "Cid")]
		public string CalloutId
		{
			get { return cid; }
			set { pid = value; }
		}

		[JsonProperty(PropertyName = "Pid")]
		public string PickupId
		{
			get { return pid; }
			set { pid = value; }
		}

	}
}
