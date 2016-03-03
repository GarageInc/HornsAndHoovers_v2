using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HornsAndHooves{
	public class ScreenManager{

		protected List<Type> screens; 
		protected int currentCounter = 0;
		protected App application;

		public ScreenManager( App app ){
			init( app );
		}

		virtual public void init( App app ){

			application = app;
		}		

		protected void show(){


			BaseScreen screen = (BaseScreen) Activator.CreateInstance (screens[ currentCounter ], this );//new Type.GetType( screens[currentCounter] ) ();
			screen.activate ();
			application.MainPage = screen;
		}

		public void showFirst(){
			currentCounter = 0;

			show ();
		}

		public void showNext(){
			
			if (currentCounter == screens.Count - 1) {
				currentCounter = 0;
			} else {
				currentCounter = currentCounter + 1;
			}

			show ();
		}

		public void showPrevious(){

			if (currentCounter <= 0) {
				currentCounter = 0;
			} else {
				currentCounter = currentCounter - 1;
			}

			show ();
		}

	}
}

