using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HornsAndHooves
{
	public partial class FourthPage : BaseScreen
	{
		public FourthPage ( BookScreenManager manager = null ): base (manager, "pict4.jpg"){

		}

		override public void activate(){

			this.audioFileKey = "a05";
			this.current_text = "Мама Пети говорит: \"Мой сынок кушает мало, я очень огорчена этим\"";

			base.activate ();

			// Тут или музло играет, или кот хвостом дергает - в общем, на усмотрение
		}

	}
}

