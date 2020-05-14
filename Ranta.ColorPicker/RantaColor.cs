using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Ranta.ColorPicker
{
    public class RantaColor : DependencyObject, INotifyPropertyChanged
    {
        public static DependencyProperty RedProperty = DependencyProperty.Register("Red", typeof(byte), typeof(RantaColor), new PropertyMetadata((byte)0, new PropertyChangedCallback(RedPropertyChanged)));

        public static DependencyProperty GreenProperty = DependencyProperty.Register("Green", typeof(byte), typeof(RantaColor), new PropertyMetadata((byte)0, new PropertyChangedCallback(GreenPropertyChanged)));

        public static DependencyProperty BlueProperty = DependencyProperty.Register("Blue", typeof(byte), typeof(RantaColor), new PropertyMetadata((byte)0, new PropertyChangedCallback(BluePropertyChanged)));

        public static DependencyProperty ScaleProperty = DependencyProperty.Register("Scale", typeof(string), typeof(RantaColor), new PropertyMetadata("0.2f", new PropertyChangedCallback(ScalePropertyChanged)));
        public static DependencyProperty RGBAProperty = DependencyProperty.Register("RGBA", typeof(string), typeof(RantaColor), new PropertyMetadata("1,1,1", new PropertyChangedCallback(RGBAPropertyChanged)));

        public event PropertyChangedEventHandler PropertyChanged;

        public string RGBA
        {
            get
            {
                return (string)GetValue(RGBAProperty);
            }
            set
            {

            }
        }
        public float Scale
        {
            get
            {
                try
                {
                    return float.Parse((string)GetValue(ScaleProperty));
                }
                catch (Exception e){
                    return 1.0f;
                }
            }
            set
            {

            }
        }

        public byte Red
        {
            get
            {
                return (byte)GetValue(RedProperty);
            }
            set
            {
                SetValue(RedProperty, value);
            }
        }

        public byte Green
        {
            get
            {
                return (byte)GetValue(GreenProperty);
            }
            set
            {
                SetValue(GreenProperty, value);
            }
        }

        public byte Blue
        {
            get
            {
                return (byte)GetValue(BlueProperty);
            }
            set
            {
                SetValue(BlueProperty, value);
            }
        }

        public RantaColor()
        {
            color = Color.FromRgb(0, 0, 0);
            brush = new SolidColorBrush(color);
        }

        private Color color;

        private SolidColorBrush brush;

        public Color Color
        {
            get
            {
                return color;
            }
        }

        public SolidColorBrush Brush
        {
            get
            {
                return brush;
            }
        }

        public static void RedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RantaColor rantaColor = (RantaColor)d;

            rantaColor.color = Color.FromRgb(rantaColor.Red, rantaColor.Green, rantaColor.Blue);

            rantaColor.brush = new SolidColorBrush(rantaColor.color);

            rantaColor.OnColorChanged();
        }
        public static void GreenPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RantaColor rantaColor = (RantaColor)d;

            rantaColor.color = Color.FromRgb(rantaColor.Red, rantaColor.Green, rantaColor.Blue);

            rantaColor.brush = new SolidColorBrush(rantaColor.color);

            rantaColor.OnColorChanged();
        }
        public static void BluePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RantaColor rantaColor = (RantaColor)d;

            rantaColor.color = Color.FromRgb(rantaColor.Red, rantaColor.Green, rantaColor.Blue);

            rantaColor.brush = new SolidColorBrush(rantaColor.color);

            rantaColor.OnColorChanged();
        }
        public static void ScalePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RantaColor rantaColor = (RantaColor)d;

            var rgba = rantaColor.RGBA.Split(',');
            var scale = 1.0f / (rantaColor.Scale > 0 ? rantaColor.Scale : 1.0f);
            if (rgba.Count() > 2)
            {
                byte r = (byte)(float.Parse(rgba[0]) * 255 * scale);
                byte g = (byte)(float.Parse(rgba[1]) * 255 * scale);
                byte b = (byte)(float.Parse(rgba[2]) * 255 * scale);
                rantaColor.color = Color.FromRgb(r, g, b);
            }
            else
            {
                rantaColor.color = Color.FromRgb(rantaColor.Red, rantaColor.Green, rantaColor.Blue);
            }

            rantaColor.brush = new SolidColorBrush(rantaColor.color);

            rantaColor.OnColorChanged();
        }
        
        public static void RGBAPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RantaColor rantaColor = (RantaColor)d;

            var rgba = rantaColor.RGBA.Split(',');
            var scale = 1.0f / (rantaColor.Scale > 0 ? rantaColor.Scale : 1.0f);
            if (rgba.Count() > 2)
            {
                byte r = (byte)(float.Parse(rgba[0]) * 255 * scale);
                byte g = (byte)(float.Parse(rgba[1]) * 255 * scale);
                byte b = (byte)(float.Parse(rgba[2]) * 255 * scale);
                rantaColor.color = Color.FromRgb(r, g, b);
            }
            else
            {
                rantaColor.color = Color.FromRgb(rantaColor.Red, rantaColor.Green, rantaColor.Blue);
            }

            rantaColor.brush = new SolidColorBrush(rantaColor.color);

            rantaColor.OnColorChanged();
        }

        private void OnColorChanged()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Color"));

                PropertyChanged(this, new PropertyChangedEventArgs("Brush"));
            }
        }
    }
}
