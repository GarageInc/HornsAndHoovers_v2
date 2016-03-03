using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HornsAndHooves
{
	public partial class SeventhPage : BaseScreen
	{

		BoxView cat;
		double[] positions_params_cat;

		BoxView boy;
		double[] positions_params_boy;

		BoxView lampa;
		double[]  positions_params_lampa;

		BoxView darkView;
		public SeventhPage ( BookScreenManager manager = null ): base (manager, "pict7.jpg"){
		}

		override public void activate(){

            audioFileKey = "a08";
            current_text = "А Федя кушает сам и даже просит у мамы добавки, и растёт Федя крепким и сильным мальчиком.";

            base.activate ();

			// 770 x 970
			createAndAddBoxViewHandler ( ref cat, handler_catReadClick );
			getRL().Children.Add (cat, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_cat = ScreenPosition.getPosition(parent.Width, parent.Height,0.6,0.41,0.15,0.15);

						cat.WidthRequest = positions_params_cat[2];
						cat.HeightRequest = positions_params_cat[3];

						return positions_params_cat[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_cat[1];
					}));

			createAndAddBoxViewHandler ( ref boy, handler_boyClick );
			getRL().Children.Add (boy, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_boy = ScreenPosition.getPosition(parent.Width, parent.Height,0.33,0.42,0.25,0.2);

						boy.WidthRequest = positions_params_boy[2];
						boy.HeightRequest = positions_params_boy[3];

						return positions_params_boy[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_boy[1];
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


		protected void handler_catReadClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"Cat"
			);
		}

		protected void handler_boyClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"C8"
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

