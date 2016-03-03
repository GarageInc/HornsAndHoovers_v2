using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HornsAndHooves
{

	public partial class ThirdPage : BaseScreen
	{

		BoxView cat;
		double[] positions_params_cat;

		BoxView boys;
		double[] positions_params_boys;


		public ThirdPage (BookScreenManager manager = null) : base (manager, "pict3.jpg"){

		}

		override public void activate(){

			this.audioFileKey = "a04";
			this.current_text = "В один прекрасный день встретились мамы этих мальчиков и разговорились между собой...";

			base.activate ();
			// 770 x 970
			createAndAddBoxViewHandler ( ref cat, handler_catReadClick );
			getRL().Children.Add (cat, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_cat = ScreenPosition.getPosition(parent.Width, parent.Height,0.05,0,0.45,0.1);

						cat.WidthRequest = positions_params_cat[2];
						cat.HeightRequest = positions_params_cat[3];
					
						return positions_params_cat[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_cat[1];
					}));
			
			createAndAddBoxViewHandler ( ref boys, handler_boysClick );
			getRL().Children.Add(boys,
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_boys = ScreenPosition.getPosition(parent.Width, parent.Height, 0.70, 0.48, 0.3, 0.23);

						boys.WidthRequest = positions_params_boys[2];
						boys.HeightRequest = positions_params_boys[3];

						return positions_params_boys[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_boys[1];
					}));
			
		}

		protected void handler_catReadClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"Cat"
			);
		}

		protected void handler_boysClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"detskiy_smeh"
			);
		}


	}
}

