using System;
using Android.Graphics;

namespace HornsAndHooves
{
	public interface IAudio
	{
		bool PlayMp3File(string fileName);
		void stopPlayer ();
	}
}

