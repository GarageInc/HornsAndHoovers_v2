using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HornsAndHooves
{

	public partial class StartPage : BaseScreen
	{
		BoxView iWillRead;
		double[] positions_params_iWillRead;

		BoxView iReadAndListen;
		double[] positions_params_iReadAndListen;

		BoxView tellMeAStory;
		double[] positions_params_tellMeAStory;

		public StartPage (BookScreenManager manager = null) : base (manager, "title_background.jpg"){
		}

		override public void activate(){
			this.audioFileKey = "a01";

			this.nextButtonImage.IsVisible = false;
			this.previousButtonImage.IsVisible = false;
			this.homeButtonImage.IsVisible = false;
			this.speakerButtonImage.IsVisible = false;
			this.textButtonImage.IsVisible = false;

			this.textFrame.IsVisible = false;

			////
			createAndAddBoxViewHandler (ref iWillRead, handler_iWillReadClick);
			getRL ().Children.Add (iWillRead, 
				Constraint.RelativeToParent ((parent) => {
					positions_params_iWillRead = ScreenPosition.getPosition (parent.Width, parent.Height, 0.25, 0.375, 0.5, 0.105);

					iWillRead.WidthRequest = positions_params_iWillRead [2];
					iWillRead.HeightRequest = positions_params_iWillRead [3];

					return positions_params_iWillRead [0];
					;
				}),
				Constraint.RelativeToParent ((parent) => {
					return positions_params_iWillRead [1];
				}));

			////
			createAndAddBoxViewHandler (ref iReadAndListen, handler_iReadAndListenClick);
			getRL ().Children.Add (iReadAndListen, 
				Constraint.RelativeToParent ((parent) => {
					positions_params_iReadAndListen = ScreenPosition.getPosition (parent.Width, parent.Height, 0.25, 0.485, 0.5, 0.09);

					iReadAndListen.WidthRequest = positions_params_iReadAndListen [2];
					iReadAndListen.HeightRequest = positions_params_iReadAndListen [3];

					return positions_params_iReadAndListen [0];
					;
				}),
				Constraint.RelativeToParent ((parent) => {
					return positions_params_iReadAndListen [1];
				}));

			////
			createAndAddBoxViewHandler (ref tellMeAStory, handler_tellMeAStoryClick);
			getRL ().Children.Add (tellMeAStory, 
				Constraint.RelativeToParent ((parent) => {
					positions_params_tellMeAStory = ScreenPosition.getPosition (parent.Width, parent.Height, 0.25, 0.58, 0.5, 0.1);

					tellMeAStory.WidthRequest = positions_params_tellMeAStory [2];
					tellMeAStory.HeightRequest = positions_params_tellMeAStory [3];

					return positions_params_tellMeAStory [0];
					;
				}),
				Constraint.RelativeToParent ((parent) => {
					return positions_params_tellMeAStory [1];
				}));
			
			// при открытии воспроизводится звуковой файл всегда
			DependencyService.Get<IAudio> ().PlayMp3File (
				audioFileKey
			);
		}



		/*
		 * HANDLERS
		 */

		protected void handler_iWillReadClick(object sender, System.EventArgs e)
		{
			SessionConfig.getInstance ().TEXT_ON = true;
			SessionConfig.getInstance ().SPEAKER_ON = false;

			iWillRead.IsEnabled = false;
			screenManager.showNext();
		}

		protected void handler_iReadAndListenClick(object sender, System.EventArgs e)
		{
			SessionConfig.getInstance ().TEXT_ON = true;
			SessionConfig.getInstance ().SPEAKER_ON = true;

			iReadAndListen.IsEnabled = false;
			screenManager.showNext();
		}

		protected void handler_tellMeAStoryClick(object sender, System.EventArgs e)
		{
			// screenManager.showNext();
		}

	}
}

