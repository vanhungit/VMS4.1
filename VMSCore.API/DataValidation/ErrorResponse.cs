using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMSCore.API.DataValidation
{
    public class ErrorResponse
    {
        public ErrorDetail Error { get; set; }
    }

    public class ErrorDetail
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        public List<ValidationError> ValidationErrors { get; set; } = new List<ValidationError>();
    }

    public class ValidationError
    {
        public string Message { get; set; }
        public List<string> Members { get; set; } = new List<string>();
    }
}
