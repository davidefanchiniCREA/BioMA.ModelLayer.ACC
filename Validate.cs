using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.ModelLayer.ACC
{
    internal class Validate
    {
        #region Constructor

        internal Validate (APIdefinition apidef)
        {
            _api = apidef;
            ValidationSuccess = ValidateDefinition();
        }

        #endregion

        private readonly APIdefinition _api;
        internal ValidationResult ValidationSuccess = ValidationResult.Ok;
        internal string ReturnMessage = "Validation Result\t\n\t\n";

        internal enum ValidationResult
        {
            Ok,
            Error,
        }

        private ValidationResult ValidateDefinition()
        {
            if (_api.Namespace == null | _api.Namespace == String.Empty)
                ReturnMessage += " - Namespace missing";
            if (_api.DomainClasses.Count == 0)
                ReturnMessage += "\t\n - No domain classes selected";
            if (_api.MethodName == null | _api.MethodName == String.Empty)
                ReturnMessage += "\t\n - Name of calculate method missing";
            if (_api.InterfaceStrategyPostfix == null | _api.InterfaceStrategyPostfix == String.Empty)
                ReturnMessage += "\t\n - Postfix of IStrategy realization missing";
            if (_api.MethodParameters == null | _api.MethodParameters == String.Empty)
                ReturnMessage += "\t\n - No method parameters";
            
            if (ReturnMessage != "Validation Result\t\n\t\n") ValidationSuccess = ValidationResult.Error;
            return ValidationSuccess;
        }
    }
}
