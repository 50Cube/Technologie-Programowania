using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace View.Validator
{
    class StringValidator : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            if (((string)value).Length >= Min && ((string)value).Length <= Max) { 
                return ValidationResult.ValidResult;
            }
            else{
                return new ValidationResult(false,
              $"Please enter string in the range: {Min}-{Max}.");
            }
        }
    }
}
