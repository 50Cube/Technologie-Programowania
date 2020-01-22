using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace View.Validator
{
    public class DecimalValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string s = ((string)value);
            decimal d = 0.00m;
            try
            {
                 d = Decimal.Parse(s);
   
            }
            catch(System.Exception fe)
            {
              return new ValidationResult(false,
              $"Please enter positive decimal ");
            }
        
            if (d>0.00m){ 
                return ValidationResult.ValidResult;
            }
            else{
                return new ValidationResult(false,
              $"Please enter positive decimal ");
            }
        }
    }
}
