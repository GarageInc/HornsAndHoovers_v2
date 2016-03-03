using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HornsAndHooves
{
	public partial class SecondPage : BaseScreen
	{

		BoxView cat;
		double[] positions_params_cat;

		BoxView petja;
		double[] positions_params_petja;

		BoxView fedja;
		double[] positions_params_fedja;

		public SecondPage ( BookScreenManager manager = null): base (manager, "pict2.jpg"){

		}

		override public void activate(){

			this.audioFileKey = "a03";
			this.current_text = "Звали мальчиков Петя и Федя. Были они друзьями. Петя одет в красную футболку, а Федя в зеленую футболку. Федя чуть больше Пети и крупнее.";

			base.activate ();

			createAndAddBoxViewHandler (ref cat, handler_catReadClick);
			getRL ().Children.Add (cat, 
				Constraint.RelativeToParent ((parent) => {
					positions_params_cat = ScreenPosition.getPosition (parent.Width, parent.Height, 0.075, 0.2, 0.15, 0.1);

					cat.WidthRequest = positions_params_cat [2];
					cat.HeightRequest = positions_params_cat [3];

					return positions_params_cat [0];
					;
				}),
				Constraint.RelativeToParent ((parent) => {
					return positions_params_cat [1];
				}));

			createAndAddBoxViewHandler (ref petja, handler_petjaClick);
			getRL ().Children.Add (petja,
				Constraint.RelativeToParent ((parent) => {
					positions_params_petja = ScreenPosition.getPosition (parent.Width, parent.Height, 0.3, 0.48, 0.2, 0.2);

					petja.WidthRequest = positions_params_petja [2];
					petja.HeightRequest = positions_params_petja [3];

					return positions_params_petja [0];
					;
				}),
				Constraint.RelativeToParent ((parent) => {
					return positions_params_petja [1];
				}));

			createAndAddBoxViewHandler (ref fedja, handler_fedjaClick);
			getRL ().Children.Add (fedja,
				Constraint.RelativeToParent ((parent) => {
					positions_params_fedja = ScreenPosition.getPosition (parent.Width, parent.Height, 0.5, 0.5, 0.25, 0.25);

					fedja.WidthRequest = positions_params_fedja [2];
					fedja.HeightRequest = positions_params_fedja [3];

					return positions_params_fedja [0];
					;
				}),
				Constraint.RelativeToParent ((parent) => {
					return positions_params_fedja [1];
				}));
		}

		//Label sampleLabel;


		protected void handler_catReadClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"Cat"
			);
		}

		protected void handler_petjaClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"C3_2"
			);
		}

		protected void handler_fedjaClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"C3_1"
			);
		}
	}
}

