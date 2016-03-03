using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HornsAndHooves
{
	public class App : Application
	{
		BookScreenManager manager;

		public App ()
		{
			// The root page of your application
			manager = new BookScreenManager( this );

			manager.showFirst();
		}

		protected override void OnStart ()
		{
            // Handle when your app starts
            base.OnStart();
		}

		protected override void OnSleep ()
		{
            // Handle when your app sleeps
            base.OnSleep();
		}

		protected override void OnResume ()
		{
            // Handle when your app resumes
            base.OnResume();
		}
	}
}
