using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BillsPaymentSystem.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class XorAttribute : ValidationAttribute
    {
        private string targetProperty;

        public XorAttribute(string TargetProperty)
        {
            this.targetProperty = TargetProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var targetProperyValue = validationContext
                .ObjectType
                .GetProperty(targetProperty)
                .GetValue(validationContext.ObjectInstance);

            if (value == null && targetProperyValue == null || value != null && targetProperyValue != null)
            {
                return new ValidationResult("The two properties must have opposite values!");
            }

            return ValidationResult.Success;
        }
    }
}
