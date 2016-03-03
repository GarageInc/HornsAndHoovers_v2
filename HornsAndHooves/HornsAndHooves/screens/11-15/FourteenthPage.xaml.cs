using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HornsAndHooves
{
	public partial class FourteenthPage : BaseScreen
	{
		BoxView man;
		double[] positions_params_man;

		BoxView velosiped;
		double[] positions_params_velosiped;

		public FourteenthPage ( BookScreenManager manager = null ): base (manager, "pict14.jpg"){
		}

		override public void activate(){

			audioFileKey = "a15";
            current_text = "Очень обидно стало Пете, что в магазине не продали ему велосипед. А Федя домой поехал на новом велосипеде.";

            base.activate ();

			createAndAddBoxViewHandler ( ref man, handler_manClick );
			getRL().Children.Add (man, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_man = ScreenPosition.getPosition(parent.Width, parent.Height,0.8,0.31,0.2,0.2);

						man.WidthRequest = positions_params_man[2];
						man.HeightRequest = positions_params_man[3];

						return positions_params_man[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_man[1];
					}));

			createAndAddBoxViewHandler ( ref velosiped, handler_velosipedClick );
			getRL().Children.Add (velosiped, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_velosiped = ScreenPosition.getPosition(parent.Width, parent.Height,0.47,0.64,0.2,0.23);

						velosiped.WidthRequest = positions_params_velosiped[2];
						velosiped.HeightRequest = positions_params_velosiped[3];

						return positions_params_velosiped[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_velosiped[1];
					}));
		}

		protected void handler_manClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"C15"
			);
		}

		protected void handler_velosipedClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"zvonok_velosipeda"
			);
		}
	}
}

