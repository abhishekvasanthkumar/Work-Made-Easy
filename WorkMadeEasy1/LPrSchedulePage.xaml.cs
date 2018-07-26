using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorkMadeEasy1
{
	public partial class LPrSchedulePage : ContentPage
	{
		ScheduleManager manager;
		String day, shift;

		public LPrSchedulePage()
		{
			InitializeComponent();
			manager = ScheduleManager.DefaultManager;
		}

		async void OnSaveClicked(object s, EventArgs e)
		{

			if (LPrWorkDayU.SelectedIndex == 0)
			{
				day = "Monday";
			}
			if (LPrWorkDayU.SelectedIndex == 1)
			{
				day = "Tuesday";
			}
			if (LPrWorkDayU.SelectedIndex == 2)
			{
				day = "Wednesday";
			}
			if (LPrWorkDayU.SelectedIndex == 3)
			{
				day = "Thursday";
			}
			if (LPrWorkDayU.SelectedIndex == 4)
			{
				day = "Friday";
			}

			if (LPrshiftU.SelectedIndex == 0)
			{
				shift = "Shift1:9:00am to 12:00pm";
			}
			if (LPrshiftU.SelectedIndex == 1)
			{
				shift = "Shift2:12:00pm to 3:00pm";
			}
			if (LPrshiftU.SelectedIndex == 2)
			{
				shift = "Shift3:3:00pm to 6:00pm";
			}


			var todo1 = new Schedule
			{
				Workplace = "La Parilla",
				EmployeeId = LPremployeeidU.Text,
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
