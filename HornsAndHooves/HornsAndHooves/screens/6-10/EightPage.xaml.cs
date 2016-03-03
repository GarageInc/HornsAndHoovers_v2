using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HornsAndHooves
{
	public partial class EightPage : BaseScreen
	{
		BoxView boys;
		double[] positions_params_teapot;

		public EightPage ( BookScreenManager manager = null ): base (manager, "pict8.jpg"){
		}

		override public void activate(){

            audioFileKey = "a09";
            current_text = "Как-то захотелось мальчикам научиться кататься на велосипедах и стали они просить у своих родителей, чтобы им купили велосипеды.";

            base.activate ();

			createAndAddBoxViewHandler ( ref boys, handler_boysClick );
			getRL().Children.Add(boys,
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_teapot = ScreenPosition.getPosition(parent.Width, parent.Height, 0.53, 0.53, 0.4, 0.27);

						boys.WidthRequest = positions_params_teapot[2];
						boys.HeightRequest = positions_params_teapot[3];

						return positions_params_teapot[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_teapot[1];
					}));
		}


		protected void handler_boysClick(object sender, System.EventArgs e){

			DependencyService.Get<IAudio>().PlayMp3File(
				"C9"
			);
		}
	}
}

