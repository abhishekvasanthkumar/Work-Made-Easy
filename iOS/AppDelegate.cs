using System;
using System.Collections.Generic;
using System.Linq;
using SQLitePCL;
//using Xamarin.Forms;

using Foundation;
using UIKit;

namespace WorkMadeEasy1.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			
			global::Xamarin.Forms.Forms.Init();
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
			SQLitePCL.Batteries.Init();
			//var cv = typeof(Xamarin.Forms.CarouselView);
			//var assembly = Assembly.Load(cv.FullName);

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
