using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.ModelLayer.ACC
{
    [Serializable]
    public class SignatureParsingException : ApplicationException
    {
        public SignatureParsingException() { }
        public SignatureParsingException(string message, string oldSignature) : base(message)
        {
            _oldSignature = oldSignature;
        }

        private string _oldSignature;

        public string OldSignature
        {
            get
            {
                return _oldSignature;
            }
        }
    }
}
