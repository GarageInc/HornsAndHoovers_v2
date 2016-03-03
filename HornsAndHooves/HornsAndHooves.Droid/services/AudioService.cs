
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using HornsAndHooves.Droid;
using Android.Media;
using Android.Graphics;
using Java.Net;
using Java.IO;

[assembly: Dependency(typeof(AudioService))]

namespace HornsAndHooves.Droid
{
	public class AudioService : IAudio
	{
		public Resource resources;

		public AudioService() {}

		private MediaPlayer _mediaPlayer;

		public void stopPlayer(){
			if (_mediaPlayer!=null && _mediaPlayer.IsPlaying) {
				_mediaPlayer.Stop ();
			}
		}

		public bool PlayMp3File(string fileName)
		{
			stopPlayer ();

			_mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, getAudioFileId( fileName ) );
			_mediaPlayer.Start();

			return true;
		}

		public static int getAudioFileId(string fileName){
			Dictionary<string, int> audio = new Dictionary<string,int> {
				{ "a01", Resource.Raw.a01},
				{ "a02", Resource.Raw.a02},
				{ "a03", Resource.Raw.a03},
				{ "a04", Resource.Raw.a04},
				{ "a05", Resource.Raw.a05},
				{ "a06", Resource.Raw.a06},
				{ "a07", Resource.Raw.a07},
				{ "a08", Resource.Raw.a08},
				{ "a09", Resource.Raw.a09},
				{ "a10", Resource.Raw.a10},
				{ "a11", Resource.Raw.a11},
				{ "a12", Resource.Raw.a12},
				{ "a13", Resource.Raw.a13},
				{ "a14", Resource.Raw.a14},
				{ "a15", Resource.Raw.a15},
				{ "a16", Resource.Raw.a16},
				{ "a17", Resource.Raw.a17},
				{ "C3_1", Resource.Raw.C3_1},
				{ "C3_2", Resource.Raw.C3_2},
				{ "C7", Resource.Raw.C7},
				{ "C8", Resource.Raw.C8},
				{ "C9", Resource.Raw.C9},
				{ "C10", Resource.Raw.C10},
				{ "C11_1", Resource.Raw.C11_1},
				{ "C11_2", Resource.Raw.C11_2},
				{ "C12_1", Resource.Raw.C12_1},
				{ "C12_2", Resource.Raw.C12_2},
				{ "C13", Resource.Raw.C13},
				{ "C14", Resource.Raw.C14},
				{ "C15", Resource.Raw.C15},
				{ "kryshka_kastuli", Resource.Raw.kryshka_kastuli},
				{ "teapot", Resource.Raw.teapot},
				{ "zvonok_velosipeda", Resource.Raw.zvonok_velosipeda},
				{ "Cat", Resource.Raw.Cat},
				{ "dog", Resource.Raw.dog},
				{ "raskat_groma", Resource.Raw.raskat_groma},
				{ "upal", Resource.Raw.upal},
				{ "detskiy_smeh", Resource.Raw.detskiy_smeh}

			};

			return audio [fileName];
		}

	}
}

