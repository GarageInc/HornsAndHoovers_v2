using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HornsAndHooves
{
	public partial class SixthPage : BaseScreen
	{
		BoxView boy;
		double[] positions_params_boy;

		BoxView teapot;
		double[] positions_params_teapot;

		BoxView lampa;
		double[]  positions_params_lampa;

		BoxView darkView;

		public SixthPage ( BookScreenManager manager = null ): base (manager, "pict6.jpg"){

		}

		override public void activate(){

			audioFileKey = "a07";
            current_text = "Мама Пети пытается накормить сына: готовит разные вкусные блюда, только Петя не желает взять ложечку и покушать, все ждет, когда же мама его накормит, поэтому растёт слабеньким и бледненьким.";


            base.activate ();

			createAndAddBoxViewHandler ( ref boy, handler_boyClick );
			getRL().Children.Add (boy, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_boy = ScreenPosition.getPosition(parent.Width, parent.Height,0.75,0.6,0.25,0.25);

						boy.WidthRequest = positions_params_boy[2];
						boy.HeightRequest = positions_params_boy[3];

						return positions_params_boy[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_boy[1];
					}));

			createAndAddBoxViewHandler ( ref teapot, handler_teapotClick );
			getRL().Children.Add (teapot, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_teapot = ScreenPosition.getPosition(parent.Width, parent.Height,0.25,0.43,0.25,0.25);

						teapot.WidthRequest = positions_params_teapot[2];
						teapot.HeightRequest = positions_params_teapot[3];

						return positions_params_teapot[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_teapot[1];
					}));

			createAndAddBoxViewHandler ( ref lampa, handler_lampaClick );
			getRL().Children.Add (lampa, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_lampa = ScreenPosition.getPosition(parent.Width, parent.Height,0.4,0.05,0.3,0.15);

						lampa.WidthRequest = positions_params_lampa[2];
						lampa.HeightRequest = positions_params_lampa[3];

						return positions_params_lampa[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_lampa[1];
					}));

			///
			darkView = new BoxView
			{
				Color = Color.Black,
				Opacity = 0.0
			};

			getRL().Children.Add (darkView, 
				Constraint.RelativeToParent((parent) =>
					{
						return 0;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return 0;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return parent.Width;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return parent.Height;
					}));
		}

		protected void handler_boyClick(object sender, System.EventArgs e){
			
			DependencyService.Get<IAudio>().PlayMp3File(
				"C7"
			);
		}

		protected void handler_teapotClick(object sender, System.EventArgs e){

			DependencyService.Get<IAudio>().PlayMp3File(
				"kryshka_kastuli"
			);
		}

		protected void handler_lampaClick(object sender, System.EventArgs e){
			if (darkView.Opacity == 0.0) {

				darkView.Opacity = 0.8;
			} else {

				darkView.Opacity = 0.0;
			};
		}
	}
}

