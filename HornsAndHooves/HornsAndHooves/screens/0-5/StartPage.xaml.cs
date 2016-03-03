using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HornsAndHooves
{

	public partial class FifthPage : BaseScreen
	{

		public FifthPage (BookScreenManager manager = null) : base (manager, "pict5.jpg"){

		}

		override public void activate(){

			this.audioFileKey = "a06";

			base.activate ();

			// Тут или музло играет, или кот хвостом дергает - в общем, на усмотрение
		}


	}
}

