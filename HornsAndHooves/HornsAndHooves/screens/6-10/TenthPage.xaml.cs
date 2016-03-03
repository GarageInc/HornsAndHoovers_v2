using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HornsAndHooves
{
	public partial class TenthPage : BaseScreen
	{
		BoxView petja;
		double[] positions_params_petja;

		BoxView fedja;
		double[] positions_params_fedja;

		BoxView velosiped_1;
		double[] positions_params_velosiped_1;

		BoxView velosiped_2;
		double[] positions_params_velosiped_2;

		public TenthPage ( BookScreenManager manager = null ): base (manager, "pict10.jpg"){

		}

		override public void activate(){

			audioFileKey = "a11";
            current_text = "Придя в магазин, мальчики выбрали себе велосипеды и захотели прокатиться. Петя выбрал зеленый велосипед, а Федя желтый.";


            base.activate ();

			createAndAddBoxViewHandler ( ref petja, handler_petjaClick );
			getRL().Children.Add (petja, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_petja = ScreenPosition.getPosition(parent.Width, parent.Height,0.34,0.28,0.15,0.4);

						petja.WidthRequest = positions_params_petja[2];
						petja.HeightRequest = positions_params_petja[3];

						return positions_params_petja[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_petja[1];
					}));

			createAndAddBoxViewHandler ( ref fedja, handler_fedjaClick );
			getRL().Children.Add (fedja, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_fedja = ScreenPosition.getPosition(parent.Width, parent.Height,0.5,0.28,0.15,0.4);

						fedja.WidthRequest = positions_params_fedja[2];
						fedja.HeightRequest = positions_params_fedja[3];

						return positions_params_fedja[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_fedja[1];
					}));
			
			/////////
			createAndAddBoxViewHandler ( ref velosiped_1, handler_velosipedClick );
			getRL().Children.Add (velosiped_1, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_velosiped_1 = ScreenPosition.getPosition(parent.Width, parent.Height,0.2,0.52,0.13,0.3);

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
						positions_params_velosiped_2 = ScreenPosition.getPosition(parent.Width, parent.Height,0.66,0.52,0.13,0.3);

						velosiped_2.WidthRequest = positions_params_velosiped_2[2];
						velosiped_2.HeightRequest = positions_params_velosiped_2[3];

						return positions_params_velosiped_2[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_velosiped_2[1];
					}));
		}

		protected void handler_petjaClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"C11_1"
			);
		}

		protected void handler_fedjaClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"C11_2"
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

