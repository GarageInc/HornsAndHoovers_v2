using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HornsAndHooves
{
	public partial class FifteenthPage : BaseScreen
	{
		BoxView boy;
		double[] positions_params_boy;

		public FifteenthPage ( BookScreenManager manager = null ): base (manager, "pict15.jpg"){

		}

		override public void activate(){

			audioFileKey = "a16";
            current_text = "С тех пор Петя начал хорошо кушать, много гулять и вовремя ложиться спать, уж очень ему хотелось кататься на велосипеде!";


            base.activate ();


			createAndAddBoxViewHandler ( ref boy, handler_boyClick );
			getRL().Children.Add (boy, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_boy = ScreenPosition.getPosition(parent.Width, parent.Height,0.3,0.12,0.45,0.45);

						boy.WidthRequest = positions_params_boy[2];
						boy.HeightRequest = positions_params_boy[3];

						return positions_params_boy[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_boy[1];
					}));
		}


		protected void handler_boyClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"C8"
			);
		}

	}
}

