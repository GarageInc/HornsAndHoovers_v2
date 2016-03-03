using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HornsAndHooves
{
	public partial class BaseScreen : ContentPage
	{
		protected BookScreenManager screenManager;

		protected Image nextButtonImage;
		protected Image previousButtonImage;
		protected Image homeButtonImage;
		protected Image textButtonImage;
		protected Image speakerButtonImage;

		protected Image backgroundImage;
		protected string backgroundImagePath = "";

		protected string audioFileKey = "";
		protected double boxes_opasity = 0.0;

		protected Frame textFrame;
		protected string current_text = "";


		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();

			nextButtonImage.Source = null;
			previousButtonImage.Source = null;
			homeButtonImage.Source = null;
			backgroundImage.Source = null;
			textButtonImage.Source = null;
			speakerButtonImage.Source = null;

			GC.Collect ();
		}


		public BaseScreen ( BookScreenManager manager = null, String imagePath = "")
		{
			InitializeComponent ();

			screenManager = manager;

			backgroundImagePath  = imagePath;

			loadBackGroundImage ();
			addBaseComponents();
		}

		protected void addImageHandler (ref Image image, string imagePath,  handlerDelegate handler ){
			image = new Image { Source = imagePath,Aspect = Aspect.AspectFit};

			var tap = new TapGestureRecognizer ();
			tap.Tapped += (object sender, EventArgs e) => {
				handler( sender, e );
			};

			image.GestureRecognizers.Add ( tap );
		}

		protected delegate void handlerDelegate( object sender, EventArgs e );

		protected  void loadBackGroundImage(){
			
			backgroundImage = new Image {
				Source = backgroundImagePath
			};

			relativeLayout.Children.Add (backgroundImage,
				Constraint.RelativeToParent ((parent) => {
					return 0;
				}),
				Constraint.RelativeToParent ((parent) => {
					return 0;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height;
				})); 			
		}


		protected void addBaseComponents()
		{
			this.Content = relativeLayout;

			var widthHeightParam = 60;
						
            ////

			string fileName = SessionConfig.getInstance ().SPEAKER_ON ? "speaker_on.png" : "speaker_off.png";
			addImageHandler(ref speakerButtonImage, fileName, handler_bSpeakerClick);
			relativeLayout.Children.Add(speakerButtonImage,
				Constraint.RelativeToParent((parent) =>
					{
						return 0;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return 0;
					}),
				Constraint.RelativeToParent((parent) => // ширина
					{
						return widthHeightParam;
					}),
				Constraint.RelativeToParent((parent) => // высота
					{
						return widthHeightParam;
					})); 
            
			////
			addImageHandler(ref homeButtonImage, "home_default.png", handler_bHomeClick); 
			relativeLayout.Children.Add ( homeButtonImage, 
				Constraint.RelativeToParent((parent) =>
					{
						return parent.Width - widthHeightParam;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return 0;
					}),
				Constraint.RelativeToParent((parent) => // ширина
					{
						return widthHeightParam;
					}),
				Constraint.RelativeToParent((parent) => // высота
					{
						return widthHeightParam;
					}));
			///
			addImageHandler(ref nextButtonImage, "next_default.png", handler_bNextClick); 
			relativeLayout.Children.Add (nextButtonImage, 
				Constraint.RelativeToParent((parent) =>
					{
						return parent.Width - widthHeightParam;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return parent.Height - widthHeightParam - 10;
					}),
				Constraint.RelativeToParent((parent) => // ширина
					{
						return widthHeightParam;
					}),
				Constraint.RelativeToParent((parent) => // высота
					{
						return widthHeightParam;
					}));

			////
			addImageHandler(ref previousButtonImage, "previous_default.png", handler_bPreviousClick); 
			relativeLayout.Children.Add (previousButtonImage, 
				Constraint.RelativeToParent((parent) =>
					{
						return 0;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return parent.Height - widthHeightParam - 10;
					}),
				Constraint.RelativeToParent((parent) => // ширина
					{
						return widthHeightParam;
					}),
				Constraint.RelativeToParent((parent) => // высота
					{
						return widthHeightParam;
					}));

            ////


			fileName = SessionConfig.getInstance ().TEXT_ON ? "text_on.png" : "text_off.png";
			addImageHandler(ref textButtonImage, fileName, handler_bTextClick);
			relativeLayout.Children.Add(textButtonImage,
				Constraint.RelativeToParent((parent) =>
					{
						return parent.Width / 2 - widthHeightParam / 2;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return 0;
					}),
				Constraint.RelativeToParent((parent) => // ширина
					{
						return widthHeightParam;
					}),
				Constraint.RelativeToParent((parent) => // высота
					{
						return widthHeightParam;
					}));    
            
			

			////
			textFrame = new Frame{
				Opacity = 0.9,
				OutlineColor = Color.Silver,
				BackgroundColor = Color.White,
			};

			relativeLayout.Children.Add (textFrame, 
				Constraint.RelativeToParent((parent) =>
					{
						return 15;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return widthHeightParam + 20;
					}),
				Constraint.RelativeToParent((parent) => // ширина
					{
						return parent.Width - 15*2;
					}));
		}

		public virtual void activate(){
			
			// Console.WriteLine (current_text);
			textFrame.Content = new Label {
				FontSize = 20,
				TextColor = Color.Black,
				Text = current_text + "\n",
				XAlign = Xamarin.Forms.TextAlignment.Center,
			};
				
			if (SessionConfig.getInstance ().SPEAKER_ON) {
			
				// при открытии воспроизводится звуковой файл - если такое условие поставлено
				DependencyService.Get<IAudio>().PlayMp3File(
					audioFileKey
				);
			}	

			// если есть текст - то его показываем
			textFrame.IsVisible = SessionConfig.getInstance ().TEXT_ON;
		}

		protected void createAndAddBoxViewHandler (ref BoxView box, handlerDelegate handler ){
			box = new BoxView
			{
				Color = Color.Accent,
				Opacity = this.boxes_opasity
			};

			var tap = new TapGestureRecognizer ();
			tap.Tapped += (object sender, EventArgs e) => {
				handler( sender, e );
			};

			box.GestureRecognizers.Add ( tap );
		}


		// следующий экран
		protected void handler_bNextClick(object sender, System.EventArgs e)
		{
			screenManager.showNext();
		}

		// предыдущий экран
		protected void handler_bPreviousClick(object sender, System.EventArgs e)
		{
			screenManager.showPrevious();
		}

		// добавить хендлеры кнопок конфигов сверху
		protected void handler_bTextClick(object sender, System.EventArgs e)
		{
			SessionConfig.getInstance ().TEXT_ON = (!SessionConfig.getInstance ().TEXT_ON);
			textFrame.IsVisible = SessionConfig.getInstance ().TEXT_ON;

			textButtonImage.Source = SessionConfig.getInstance ().TEXT_ON ? "text_on.png" : "text_off.png";
		}

		protected void handler_bSpeakerClick(object sender, System.EventArgs e)
		{
			SessionConfig.getInstance ().SPEAKER_ON = (!SessionConfig.getInstance ().SPEAKER_ON);

			speakerButtonImage.Source = SessionConfig.getInstance ().SPEAKER_ON ? "speaker_on.png" : "speaker_off.png";

			if (SessionConfig.getInstance ().SPEAKER_ON) {
				DependencyService.Get<IAudio> ().PlayMp3File (
					audioFileKey
				);
			} else {
				DependencyService.Get<IAudio> ().stopPlayer ();
			}
        }

		protected void handler_bHomeClick(object sender, System.EventArgs e)
		{
			screenManager.showFirst ();
		}

		public RelativeLayout getRL(){
			return this.relativeLayout;
		}
	}
}

