using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;

namespace HornsAndHooves
{
	public partial class FirstPage : BaseScreen
	{
		BoxView grom;
		double[] positions_params_grom;


		public FirstPage ( BookScreenManager manager = null ): base (manager, "pict1.jpg"){

		}

		override public void activate(){

			this.audioFileKey = "a02";
			this.current_text = "В одном большом городе, в доме с голубой крышей и резными ставнями на окнах, жили два мальчика...";

			base.activate ();

			createAndAddBoxViewHandler ( ref grom, handler_gromClick );
			getRL().Children.Add (grom, 
				Constraint.RelativeToParent((parent) =>
					{
						positions_params_grom = ScreenPosition.getPosition(parent.Width, parent.Height, 0, 0, 1, 0.45);

						grom.WidthRequest = positions_params_grom[2];
						grom.HeightRequest = positions_params_grom[3];

						return positions_params_grom[0];;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return positions_params_grom[1];
					}));

			addDrops ();
		}

		List<Image> drops;

		void addDrops(){
			drops = new List<Image> ();
			int count = 9;

			for (int i = 0; i < count; i++) {
				drops.Add (new Image {Source ="drop.png"});
			}

			int countInRow = 3;
			int countRows = count / countInRow;

			var rowCounter = 0;

			for (double i = 0; i < count; i++) {
				if ( i % countInRow == 0) {
					rowCounter++;
				}

				double step = (((i+1) % countInRow) / countInRow);
				double currentRow = rowCounter;

				if ( rowCounter % 2 == 0 ) {
					getRL().Children.Add (drops[(int)i], 
						Constraint.RelativeToParent((parent) =>
							{
								return parent.Width * step + 5;
							}),
						Constraint.RelativeToParent((parent) =>
							{
								return 70*(currentRow);
							}));
				} else {
					getRL().Children.Add (drops[(int)i], 
						Constraint.RelativeToParent((parent) =>
							{
								return parent.Width * step + 70;
							}),
						Constraint.RelativeToParent((parent) =>
							{
								return 70*(currentRow);
							}));				
				}

			}

			//fade (0);

		}

		void fade(int value){
			foreach (Image img in drops) {
				img.FadeTo(value);  
			}
		}

		void  move(int value){


			//Task[] tasks= new Task[drops.Count];
			int i = 0;
			foreach (Image img in drops) {
				try{
					img.FadeTo (1);
					img.TranslateTo(0, value)
						.ContinueWith((a) => {
							img.TranslateTo(0, 0 );
							img.FadeTo(0);
							grom.IsEnabled = true;
						}); 
					//tasks[i] = t;
					i++;
					//Task.WaitAll (t);
				} catch{
				}
			}


		}

		void hide(){
			foreach (Image img in drops) {
				img.FadeTo(0, 750,Easing.Linear);  
			}
		}

		void moveBack(){
			foreach (Image img in drops) {
				img.TranslateTo(0, -250);  
			}			
		}

		protected void handler_gromClick(object sender, System.EventArgs e)
		{
			DependencyService.Get<IAudio>().PlayMp3File(
				"raskat_groma"
			);

			grom.IsEnabled = false;
			//fade(1);

			move (250);



			//fade(0);

			//move(250);

			//hide();
		}
	}
}

