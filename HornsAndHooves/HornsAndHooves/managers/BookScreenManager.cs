using System;
using System.Collections.Generic;

namespace HornsAndHooves
{
	public class BookScreenManager: ScreenManager
	{
		public BookScreenManager ( App application ):base (application)
		{
		}

		override public void init( App app ){
			base.init(app);

			screens = new List<Type>() { 
				/**/
				typeof( StartPage ), 

				typeof( FirstPage ), 

				typeof( SecondPage ),
				typeof( ThirdPage ),
				typeof( FourthPage ),
				typeof( FifthPage ),

				typeof( SixthPage ),
				typeof( SeventhPage ),
				typeof( EightPage ),
				typeof( NinthPage ),
				typeof( TenthPage ),

				typeof( EleventhPage ),
				typeof( TwelwthPage ),
				typeof( ThirteensPage ),
				typeof( FourteenthPage ),
				typeof( FifteenthPage ),

				typeof( SixteentsPage )
			};

		}
	}
}

