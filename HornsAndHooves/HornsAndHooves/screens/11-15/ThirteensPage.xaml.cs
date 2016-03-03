using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HornsAndHooves
{
	public partial class ThirteensPage : BaseScreen
	{
		BoxView man;
		double[] positions_params_man;

		BoxView velosiped;
		double[] positions_params_velosiped;

		public ThirteensPage ( BookScreenManager manager = null ): base (manager, "pict13.jpg"){
		}

		override public void activate(){

			audioFileKey = "a14";
            current_text = "Продавец подошел к Пете и сказал: \"Tы наверное совсем мало кушаешь, вовремя спать не ложишься, на свежем воздухе не гуляешь, поэтому ты плохо растешь и такой слабенький. Ты пока иди домой, а когда подрастешь - приходи\". ";
                 
			base.activate ();

			createAndAddBoxViewHandler ( ref man, handler_manClick );
			getRL().Children.Add (man, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_man = ScreenPosition.getPosition(parent.Width, parent.Height,0.72,0.28,0.2,0.6);

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
						positions_params_velosiped = ScreenPosition.getPosition(parent.Width, parent.Height,0.58,0.63,0.13,0.23);

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
				"C14"
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

