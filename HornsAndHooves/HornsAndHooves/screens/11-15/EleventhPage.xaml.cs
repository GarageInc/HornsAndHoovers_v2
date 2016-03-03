using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HornsAndHooves
{
	public partial class EleventhPage : BaseScreen
	{
		BoxView man;
		double[] positions_params_man;

		BoxView boy;
		double[] positions_params_boy;

		BoxView dog;
		double[] positions_params_dog;

		public EleventhPage ( BookScreenManager manager = null ): base (manager, "pict11.jpg"){
		}

		override public void activate(){

			audioFileKey = "a12";
            current_text = "Первым на велосипед сел Федя, нажал на педали и покатился, ни разу не упав. Продавец очень удивился и похвалил Федю: \"Какой ты молодец, сразу видно, кушаешь хорошо\".";

            base.activate ();

			createAndAddBoxViewHandler ( ref man, handler_manClick );
			getRL().Children.Add (man, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_man = ScreenPosition.getPosition(parent.Width, parent.Height,0.85,0.33,0.15,0.33);

						man.WidthRequest = positions_params_man[2];
						man.HeightRequest = positions_params_man[3];

						return positions_params_man[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_man[1];
					}));

			createAndAddBoxViewHandler ( ref boy, handler_boyClick );
			getRL().Children.Add (boy, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_boy = ScreenPosition.getPosition(parent.Width, parent.Height,0.2,0.55,0.2,0.3);

						boy.WidthRequest = positions_params_boy[2];
						boy.HeightRequest = positions_params_boy[3];

						return positions_params_boy[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_boy[1];
					}));

			createAndAddBoxViewHandler ( ref dog, handler_dogClick );
			getRL().Children.Add (dog, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_dog = ScreenPosition.getPosition(parent.Width, parent.Height,0.2,0.4,0.2,0.15);

						dog.WidthRequest = positions_params_dog[2];
						dog.HeightRequest = positions_params_dog[3];

						return positions_params_dog[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_dog[1];
					}));
		}

		protected void handler_dogClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"dog"
			);
		}
		protected void handler_boyClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"C12_1"
			);
		}
		protected void handler_manClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"C12_2"
			);
		}
	}
}

