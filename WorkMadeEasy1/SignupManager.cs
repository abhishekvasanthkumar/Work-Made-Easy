using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace WorkMadeEasy1
{
	public partial class SignupManager
	{
		static SignupManager defaultInstance = new SignupManager();
		MobileServiceClient client;

		IMobileServiceTable<Employee> Employeetable;

		const string offlineDbPath = @"localstore.db";

		public SignupManager()
		{
			this.client = new MobileServiceClient(Constants.ApplicationURL);


			this.Employeetable = client.GetTable<Employee>();

		}

		public static SignupManager DefaultManager
		{
			get
			{
				return defaultInstance;
			}
			private set
			{
				defaultInstance = value;
			}
		}

		public MobileServiceClient CurrentClient
		{
			get { return client; }
		}


		public async Task<ObservableCollection<Employee>> GetTodoItemsAsync(bool syncItems = false)
		{
			try
			{
				IEnumerable<Employee> items = await Employeetable
					.ToEnumerableAsync();
				
				
				return new ObservableCollection<Employee>(items);
			}
			catch (MobileServiceInvalidOperationException msioe)
			{
				Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
			}
			catch (Exception e)
			{
				Debug.WriteLine(@"Sync error: {0}", e.Message);
			}
			return null;
		}

	public async Task<String> getEmpID(String emailid)
		{
			//SELECT eid FROM Employee where Email = emailid;
			List<Employee> items = await Employeetable.Where(Employee => Employee.Email == emailid).ToListAsync();
			return items[0].EId;
		}

	

		public async Task<Boolean> SaveTaskAsync(Employee item)
		{
			List<Employee> items = await Employeetable.Where(Employee => Employee.Email == item.Email).ToListAsync();
			if (items.Count <= 0)
			{
				if (item.Id == null)
				{
					await Employeetable.InsertAsync(item);
				}
				else
				{
					await Employeetable.UpdateAsync(item);
				}
				return true;
			}
			else
			{
				return false;
			}

		}

		public async Task<Boolean> checkEmployee(String eId)
		{
			List<Employee> items = await Employeetable.Where(Employee => Employee.EId == eId).ToListAsync();
			if (items.Count >= 1)
			{
				return true;
			}
			else
			{
				return false;
			}

		}

		public async Task<Boolean> CheckTaskAsync(Employee item)
		{
			List<Employee> items = await Employeetable.Where(Employee => Employee.Email == item.Email && Employee.Password == item.Password).ToListAsync();
			if (items.Count == 1)
			{
				return true;
			}
			return false;
		}

		public async Task<List<Employee>> checkUserName(Employee item)
		{
			List<Employee> items = await Employeetable.Where(Employee=> Employee.Email == item.Email).ToListAsync();
			return items;
		}

		public async Task<List<Employee>> getEmails()
		{
			//
			List<Employee> emails = await Employeetable.Where(Employee => Employee.Email != null).ToListAsync();
			return emails;
		}

	}
	}

