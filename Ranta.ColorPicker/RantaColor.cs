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

        public event PropertyChangedEventHandler PropertyChanged;

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
