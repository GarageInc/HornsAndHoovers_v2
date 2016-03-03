using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HornsAndHooves
{
	public partial class NinthPage : BaseScreen
	{
		BoxView man;
		double[] positions_params_man;

		BoxView velosiped;
		double[] positions_params_velosiped;

		public NinthPage ( BookScreenManager manager = null ): base (manager, "pict9.jpg"){
		}

		override public void activate(){

			audioFileKey = "a10";
            current_text = "Родители подумали и согласились пойти в магазин и купить велосипеды своим сыновьям.";

			base.activate ();

			createAndAddBoxViewHandler ( ref man, handler_manClick );
			getRL().Children.Add (man, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_man = ScreenPosition.getPosition(parent.Width, parent.Height,0.55,0.28,0.4,0.3);

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
						positions_params_velosiped = ScreenPosition.getPosition(parent.Width, parent.Height,0.1,0.7,0.3,0.3);

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
				"C10"
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

