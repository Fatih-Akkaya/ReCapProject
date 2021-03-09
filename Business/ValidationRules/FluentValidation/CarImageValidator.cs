using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator:AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(c => c.ImagePath).NotEmpty();
            RuleFor(c => c.CarId).NotEmpty();
            RuleFor(c => c.ImagePath).Must(CheckAllowedExtensions).WithMessage("Yalnız .png, .jpg ve .jpeg uzantılarına izin verilmektedir.");
        }
        private bool CheckAllowedExtensions(string arg)
        {
            string[] extensions = new string[] { ".jpg", ".png", ".jpeg" };
            var extension = Path.GetExtension(arg.ToLower());
            if (!extensions.Contains(extension.ToLower()))
            {
                return false;
            }
            return true;
        }
    }
}
