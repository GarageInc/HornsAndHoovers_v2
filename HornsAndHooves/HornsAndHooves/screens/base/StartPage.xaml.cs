using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HornsAndHooves
{

	public partial class StartPage : BaseScreen
	{

		public StartPage (BookScreenManager manager = null) : base (manager, "title_background.jpg"){

		}

		override public void activate(){

			base.activate ();

			// Тут или музло играет, или кот хвостом дергает - в общем, на усмотрение
		}


	}
}

