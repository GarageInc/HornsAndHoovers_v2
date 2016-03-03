using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HornsAndHooves
{
	public partial class FifthPage : BaseScreen
	{

		BoxView cat;
		double[] positions_params_cat;

		BoxView pan;
		double[] positions_params_pan;

		public FifthPage ( BookScreenManager manager = null ): base (manager, "pict5.jpg"){
		}

		override public void activate(){

			this.audioFileKey = "a06";
			this.current_text = "А мама Феди сказала, что ее сыночек кушает очень хорошо: ничего в своей тарелочке не оставляет!";
			base.activate ();

			// 770 x 970
			createAndAddBoxViewHandler ( ref cat, handler_catReadClick );
			getRL().Children.Add (cat, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_cat = ScreenPosition.getPosition(parent.Width, parent.Height,0.65,0.48,0.1,0.1);

						cat.WidthRequest = positions_params_cat[2];
						cat.HeightRequest = positions_params_cat[3];

						return positions_params_cat[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_cat[1];
					}));
			
			createAndAddBoxViewHandler ( ref pan, handler_panClick );
			getRL().Children.Add (pan, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_pan = ScreenPosition.getPosition(parent.Width, parent.Height,0.05,0.28,0.2,0.2);

						pan.WidthRequest = positions_params_pan[2];
						pan.HeightRequest = positions_params_pan[3];

						return positions_params_pan[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_pan[1];
					}));
		}

		protected void handler_catReadClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"Cat"
			);
		}

		protected void handler_panClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"teapot"
			);
		}
	}
}

