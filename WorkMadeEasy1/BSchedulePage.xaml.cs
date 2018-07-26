using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorkMadeEasy1
{
	public partial class BSchedulePage : ContentPage
	{
		ScheduleManager manager;
		String day, shift;


		public BSchedulePage()
		{
			InitializeComponent();
			manager = ScheduleManager.DefaultManager;
		}

		async void OnSaveClicked(object s, EventArgs e)
		{

			if (BWorkDayU.SelectedIndex == 0)
			{
				day = "Monday";
			}
			if (BWorkDayU.SelectedIndex == 1)
			{
				day = "Tuesday";
			}
			if (BWorkDayU.SelectedIndex == 2)
			{
				day = "Wednesday";
			}
			if (BWorkDayU.SelectedIndex == 3)
			{
				day = "Thursday";
			}
			if (BWorkDayU.SelectedIndex == 4)
			{
				day = "Friday";
			}

			if (BshiftU.SelectedIndex == 0)
			{
				shift = "Shift1:9:00am to 12:00pm";
			}
			if (BshiftU.SelectedIndex == 1)
			{
				shift = "Shift2:12:00pm to 3:00pm";
			}
			if (BshiftU.SelectedIndex == 2)
			{
				shift = "Shift3:3:00pm to 6:00pm";
			}


			var todo1 = new Schedule
			{
				Workplace = "Bistro",
				EmployeeId = BemployeeidU.Text,
				Day = day,
				Shift = shift,

			};
			await AddItem(todo1);
		}

		async Task AddItem(Schedule item)

		{
			Boolean result = await manager.SaveTaskAsync(item);
			if (result == true)
			{
				await DisplayAlert("Alert", "Schedule is saved", "OK");
			}
			else
			{
				await DisplayAlert("Alert", "Schedule couldnot save. Please try again!", "OK");
			}



		}
	}
}
