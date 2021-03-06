﻿/*
 | Version 10.1.84
 | Copyright 2013 Esri
 |
 | Licensed under the Apache License, Version 2.0 (the "License");
 | you may not use this file except in compliance with the License.
 | You may obtain a copy of the License at
 |
 |    http://www.apache.org/licenses/LICENSE-2.0
 |
 | Unless required by applicable law or agreed to in writing, software
 | distributed under the License is distributed on an "AS IS" BASIS,
 | WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 | See the License for the specific language governing permissions and
 | limitations under the License.
 */

using System;
using System.Globalization;
using System.Windows.Data;
using ESRI.ArcLogistics.Services;

namespace ESRI.ArcLogistics.App.Converters
{
    /// <summary>
    /// Converts host names into their validation error values.
    /// </summary>
    [ValueConversion(typeof(string), typeof(string))]
    class HostNameToErrorValidationConverter : IValueConverter
    {
        /// <summary>
        /// Converts the specified host name value to a localizable string describing validation
        /// error if any.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <param name="targetType">The type to convert source value to.</param>
        /// <param name="parameter">The converter parameter.</param>
        /// <param name="culture">The culture to be used for conversion.</param>
        /// <returns>a localizable string describing validation error if any.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var validator = new HostNameValidator();
            var result = validator.Validate(value as string);

            return result.ErrorContent as string;
        }

        /// <summary>
        /// Backward conversion is not supported, so this method does nothing
        /// and returns null always.
        /// </summary>
        /// <param name="value">The value obtained from the binding target.</param>
        /// <param name="targetType">The type to convert value to.</param>
        /// <param name="parameter">The converter parameter.</param>
        /// <param name="culture">The culture to be used for conversion.</param>
        /// <returns>null reference.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
