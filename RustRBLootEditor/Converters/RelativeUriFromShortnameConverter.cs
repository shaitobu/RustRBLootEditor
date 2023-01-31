﻿using RustRBLootEditor.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace RustRBLootEditor.Converters
{
    public class RelativeUriFromShortnameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DependencyProperty.UnsetValue;
            else
            {
                string partialpath = "";

                if(parameter != null && parameter.ToString() != null) { partialpath = parameter.ToString(); }

                string debugpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string imagepath = Path.Combine(debugpath, partialpath, value.ToString());

                if(!imagepath.EndsWith(".png") && !imagepath.EndsWith(".jpg") && !imagepath.EndsWith(".jpeg"))
                {
                    imagepath = imagepath + ".png";
                }

                if (File.Exists(imagepath))
                {
                    return new Uri(imagepath, UriKind.RelativeOrAbsolute);
                }
                else
                {
                    return new Uri("/RustRBLootEditor;component/Assets/unavailable.png", UriKind.Relative);
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
