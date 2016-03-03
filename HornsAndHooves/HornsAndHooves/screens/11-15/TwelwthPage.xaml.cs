using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HornsAndHooves
{
	public partial class TwelwthPage : BaseScreen
	{

		BoxView man;
		double[] positions_params_man;

		BoxView petja;
		double[] positions_params_petja;

		public TwelwthPage ( BookScreenManager manager = null ): base (manager, "pict12.jpg"){

		}

		override public void activate(){

			audioFileKey = "a13";
            current_text = "Следующим сел Петя. Только не вышло у него ничего: он не смог даже дотянуться ногами до педалей и упал.";

			base.activate ();


			createAndAddBoxViewHandler ( ref man, handler_manClick );
			getRL().Children.Add (man, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_man = ScreenPosition.getPosition(parent.Width, parent.Height,0.75,0.28,0.2,0.6);

						man.WidthRequest = positions_params_man[2];
						man.HeightRequest = positions_params_man[3];

						return positions_params_man[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_man[1];
					}));


			createAndAddBoxViewHandler ( ref petja, handler_petjaClick );
			getRL().Children.Add(petja,
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_petja = ScreenPosition.getPosition(parent.Width, parent.Height, 0.2, 0.55, 0.4, 0.4);

						petja.WidthRequest = positions_params_petja[2];
						petja.HeightRequest = positions_params_petja[3];

						return positions_params_petja[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_petja[1];
					}));
		}

		protected void handler_manClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"C13"
			);
		}


		protected void handler_petjaClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"upal"
			);
		}
	}
}

