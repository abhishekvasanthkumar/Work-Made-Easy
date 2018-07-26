using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;
namespace WorkMadeEasy1
{
	public class Zoo
	{
		public string ImageUrl { get; set; }
		public string Name { get; set; }
	}
	public class Model
	{
		public ObservableCollection<Zoo> Zoos { get; set; }
		public Model()
		{
			Zoos = new ObservableCollection<Zoo>
			{
				new Zoo
				{
					ImageUrl = "https://s-media-cache-ak0.pinimg.com/originals/e2/22/88/e22288112cec369951d9b5bf1963ca07.jpg",
					Name = "LA PARILLA"
				},
				 new Zoo
				{
					ImageUrl = "http://www.wallpapers-web.com/data/out/82/4454310-food-wallpapers.jpg",
					Name = "BISTRO"
				 },
				new Zoo
				{
					ImageUrl = "http://blog.hdwallsource.com/wp-content/uploads/2016/03/pasta-wallpaper-50272-51960-hd-wallpapers-1024x640.jpg",
					Name = "SAUTE"
				},
				new Zoo
				{
					ImageUrl = "http://kbcrestaurant.com/spree/products/28/xlarge/ClubSandwich-1.jpg?1438781721",
					Name = "DELI"
				},
				new Zoo
				{
					ImageUrl = "http://hdwallpaperbackgrounds.net/wp-content/uploads/2015/10/Download-Food-Wallpapers-HD.jpg",
					Name = "CADENCE"
				}
			};
		}
	}
}