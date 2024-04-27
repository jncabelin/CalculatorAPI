namespace CalculatorApp.Application.Messages
{
    public class ResponseMessage
    {
        public static string INVALID_PARAMETERS => "1 or 2 Parameters are invalid.";
        public static string INDETERMINATE => "Result is Indeterminate.";
        public static string DIVISION_BY_0 => "Divisor cannot be 0.";
    }
}

