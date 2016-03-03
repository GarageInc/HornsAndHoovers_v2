using System;

namespace HornsAndHooves
{
	public class SessionConfig
	{
		public bool SPEAKER_ON = false;
		public bool TEXT_ON = true;

		public SessionConfig ()
		{
		}

		protected static SessionConfig config;

		public static SessionConfig getInstance(){
		
			if (config == null) {
				config = new SessionConfig();
			}

			return config;
		}
	}
}

