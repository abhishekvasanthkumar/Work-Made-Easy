using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace WorkMadeEasy1
{
	public class ScheduleManager
	{
		static ScheduleManager defaultInstance = new ScheduleManager();
		MobileServiceClient client;

		IMobileServiceTable<Employee> Employeetable;

		IMobileServiceTable<Schedule> Scheduletable;

		const string offlineDbPath = @"localstore.db";

		public ScheduleManager()
		{
			this.client = new MobileServiceClient(Constants.ApplicationURL);
			this.Scheduletable = client.GetTable<Schedule>();

		}

		public static ScheduleManager DefaultManager
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

		public async Task<ObservableCollection<Schedule>> GetTodoItemsAsync(bool syncItems = false)
		{
			try
			{
				IEnumerable<Schedule> schedules = await Scheduletable
					.ToEnumerableAsync();

				return new ObservableCollection<Schedule>(schedules);
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

		public async Task<Boolean> SaveTaskAsync(Schedule item)
		{
			SignupManager manager = SignupManager.DefaultManager;
			Boolean isPresent = await manager.checkEmployee(item.EmployeeId);
			List<Schedule> schedules = await Scheduletable.Where(Schedule => Schedule.EmployeeId == item.EmployeeId && Schedule.Shift== item.Shift && Schedule.Day == item.Day).ToListAsync();

			if (schedules.Count <= 0 && isPresent==true)
			{
				
				await Scheduletable.InsertAsync(item);
				return true;
			}
			else
			{
				//await Scheduletable.UpdateAsync(item);
				return false;
			}

		}

		public async Task<Boolean> UpdateTaskAsync(Schedule item)
		{
				return true;
		} 

		public async Task<Boolean> DeleteTaskAsync(Schedule item)
		{
			List<Schedule> schedules = await Scheduletable.Where(Schedule => Schedule.Workplace == item.Workplace && Schedule.EmployeeId == item.EmployeeId && Schedule.Shift == item.Shift && Schedule.Day == item.Day).ToListAsync();

			if (schedules.Count >= 1)
	{
				await Scheduletable.DeleteAsync(schedules[0]);
				return true;
			}
			else
			{
				return false;
			}

		}

		public async Task<List<Schedule>> getScheduleList(String empId)
		{
			
			List<Schedule> schedules = await Scheduletable.Where(Schedule => Schedule.EmployeeId == empId).ToListAsync();

			return schedules;
		}

	

	}
}
