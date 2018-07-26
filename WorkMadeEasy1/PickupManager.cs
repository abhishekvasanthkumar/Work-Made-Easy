using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace WorkMadeEasy1
{
	public class PickupManager
	{
		static PickupManager defaultInstance = new PickupManager();

		MobileServiceClient client;

		IMobileServiceTable<PickUp> Pickuptable;

		const string offlineDbPath = @"localstore.db";
		public PickupManager()
		{
			this.client = new MobileServiceClient(Constants.ApplicationURL);
			this.Pickuptable = client.GetTable<PickUp>();
		}

		public static PickupManager DefaultManager
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


		public async Task<ObservableCollection<PickUp>> GetTodoItemsAsync(bool syncItems = false)
		{
			try
			{
				IEnumerable<PickUp> pickups = await Pickuptable
					.ToEnumerableAsync();

				return new ObservableCollection<PickUp>(pickups);
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

		public async Task<Boolean> SaveTaskAsync(PickUp item)
		{

			List<PickUp> pickups = await Pickuptable.Where(PickUp => PickUp.Workplace == item.Workplace && PickUp.CalloutId == item.CalloutId && PickUp.Shift == item.Shift && PickUp.Day == item.Day).ToListAsync();

			if (pickups.Count <= 0)
			{
				await Pickuptable.InsertAsync(item);
				return true;
			}
			else
			{
				await Pickuptable.UpdateAsync(item);
				return false;
			}

		}



		public async Task<Boolean> DeleteTaskAsync(PickUp item)
		{
			List<PickUp> pickups = await Pickuptable.Where(PickUp => PickUp.Workplace == item.Workplace && PickUp.CalloutId == item.CalloutId && PickUp.Shift == item.Shift && PickUp.Day == item.Day).ToListAsync();

			if (pickups.Count >= 1)
			{
				await Pickuptable.DeleteAsync(pickups[0]);
				return true;
			}
			else
			{
				return false;
			}

		}

		public async Task<List<PickUp>> getPickupList()
		{
			List<PickUp> pickups = await Pickuptable.ToListAsync();
			return pickups;
		}

	}
}
