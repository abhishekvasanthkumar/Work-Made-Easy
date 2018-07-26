﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorkMadeEasy1
{
	public partial class CSchedulePage : ContentPage
	{
		ScheduleManager manager;
		String day, shift;

		public CSchedulePage()
		{
			InitializeComponent();
			manager = ScheduleManager.DefaultManager;
		}

		async void OnSaveClicked(object s, EventArgs e)
		{

			if (CWorkDayU.SelectedIndex == 0)
			{
				day = "Monday";
			}
			if (CWorkDayU.SelectedIndex == 1)
			{
				day = "Tuesday";
			}
			if (CWorkDayU.SelectedIndex == 2)
			{
				day = "Wednesday";
			}
			if (CWorkDayU.SelectedIndex == 3)
			{
				day = "Thursday";
			}
			if (CWorkDayU.SelectedIndex == 4)
			{
				day = "Friday";
			}

			if (CshiftU.SelectedIndex == 0)
			{
				shift = "Shift1:9:00am to 12:00pm";
			}
			if (CshiftU.SelectedIndex == 1)
			{
				shift = "Shift2:12:00pm to 3:00pm";
			}
			if (CshiftU.SelectedIndex == 2)
			{
				shift = "Shift3:3:00pm to 6:00pm";
			}


			var todo1 = new Schedule
			{

				Workplace = "Cadence",
				EmployeeId = CemployeeidU.Text,
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
