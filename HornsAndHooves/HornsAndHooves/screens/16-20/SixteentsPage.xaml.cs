using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HornsAndHooves
{
	public partial class SixteentsPage : BaseScreen
	{
		BoxView velosiped_1;
		double[] positions_params_velosiped_1;

		BoxView velosiped_2;
		double[] positions_params_velosiped_2;

		public SixteentsPage ( BookScreenManager manager = null ): base (manager, "pict16.jpg"){
		}

		override public void activate(){

			audioFileKey = "a17";
            current_text = "После этого Петя быстро вырос, сил набрал и купили ему наконец велосипед. И стал Петя вместе с Федей кататься на велосипеде.";

			base.activate ();

			createAndAddBoxViewHandler ( ref velosiped_1, handler_velosipedClick );
			getRL().Children.Add (velosiped_1, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_velosiped_1 = ScreenPosition.getPosition(parent.Width, parent.Height,0.3,0.6,0.2,0.15);

						velosiped_1.WidthRequest = positions_params_velosiped_1[2];
						velosiped_1.HeightRequest = positions_params_velosiped_1[3];

						return positions_params_velosiped_1[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_velosiped_1[1];
					}));

			createAndAddBoxViewHandler ( ref velosiped_2, handler_velosipedClick );
			getRL().Children.Add (velosiped_2, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_velosiped_2 = ScreenPosition.getPosition(parent.Width, parent.Height,0.66,0.44,0.22,0.13);

						velosiped_2.WidthRequest = positions_params_velosiped_2[2];
						velosiped_2.HeightRequest = positions_params_velosiped_2[3];

						return positions_params_velosiped_2[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_velosiped_2[1];
					}));
		}


		protected void handler_velosipedClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"zvonok_velosipeda"
			);
		}

	}
}

