using RecycleBin.Manager.Manager;
using System.ComponentModel.DataAnnotations;


namespace DataAnnotationsValidations.Attributes
{
    public class UniqeCodeAttribute : ValidationAttribute
    {
        CategoryManager _categoryManager = new CategoryManager();
        public bool My { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var code = (string)value;
            if(code == "MEHE")
                return ValidationResult.Success;
            else
            {
                var errorMessage = FormatErrorMessage((validationContext.DisplayName));
                return new ValidationResult(errorMessage);
            }
        }

        //    public override bool IsValid(object value)
        //    {

        //        if (value == null)
        //        {
        //            return false;
        //        }

        //        var code = (string) value;
        //        if (_categoryManager.IsCodeExist(code))
        //            return false;

        //        return true;
        //    }
    }
}