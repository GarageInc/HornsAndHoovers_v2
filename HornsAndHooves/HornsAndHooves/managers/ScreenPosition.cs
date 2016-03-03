using System;

namespace HornsAndHooves
{
	public class ScreenPosition
	{
		public ScreenPosition ()
		{
		}

		static double picture_height = 970;
		static double picture_width = 770;
			
		public static double[] getPosition(double device_width, double device_height, 
									   double x0_percent, double y0_percent,
									   double width_py_percent = 0, double height_by_percent = 0){
			double current_height = 0;
			double current_width = 0;

			////
			current_width = device_width;
			double width_koef =	picture_width / current_width;
			current_height = picture_height / width_koef;

			if ( current_height <= device_height ) {
				// so good
			} else {
				current_height = device_height;
				double height_coef = picture_height / current_height;
				current_width = picture_width / height_coef;
			}

			// Нашли высоту и ширину

			// Найдем позиции:
			double position_x = current_width * x0_percent + ( device_width - current_width ) / 2;
			double position_y = current_height * y0_percent + (device_height - current_height) / 2;

			// Найдём ширины-высоты элементов в соотношениях:
			double width = current_width * width_py_percent;
			double height = current_height * height_by_percent; 


			return new double[]{ position_x, position_y, width, height };
		}
	}
}

