using System;
using System.Globalization;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using View.Validator;

namespace Tests
{
    [TestClass]
    public class ViewTest
    {
        [TestMethod]
        public void StringValidatorMinTest()
        {
            StringValidator sv = new StringValidator();
            sv.Min = 20;
            String s = "ZaKrotki";
            CultureInfo ci = new CultureInfo("pl-PL", false);
            Assert.AreEqual(sv.Validate(s, ci), new ValidationResult(false,$"Validation Error"));
        }

        [TestMethod]
        public void StringValidatorMaxTest()
        {
            StringValidator sv = new StringValidator();
            sv.Max = 2;
            String s = "ZaDlugi";
            CultureInfo ci = new CultureInfo("pl-PL", false);
            Assert.AreEqual(sv.Validate(s, ci), new ValidationResult(false, $"Validation Error"));
        }

        [TestMethod]
        public void StringValidatorValidTest()
        {
            StringValidator sv = new StringValidator();
            sv.Min = 2;
            sv.Max = 20;
            String s = "WSamRaz";
            CultureInfo ci = new CultureInfo("pl-PL", false);
            Assert.AreEqual(sv.Validate(s, ci), ValidationResult.ValidResult);
        }

        [TestMethod]
        public void DecimalValidatorValidTest()
        {
            DecimalValidator dv = new DecimalValidator();
            String s = "5,0";
            CultureInfo ci = new CultureInfo("pl-PL", false);
            Assert.AreEqual(dv.Validate(s, ci), ValidationResult.ValidResult);
        }

        [TestMethod]
        public void DecimalValidatorInValidTest()
        {
            DecimalValidator dv = new DecimalValidator();
            String s = "-5,0";
            CultureInfo ci = new CultureInfo("pl-PL", false);
            Assert.AreEqual(dv.Validate(s, ci), new ValidationResult(false,
              $"Please enter positive decimal "));
     
        }
    }
}
