namespace StringCalculatorAPI.Model
{
    public class BadRequestJSONegativesNotAllowed
    {
        public string Type => "Negatives not allowed";
        public string Title => "Bad Request";
        public int Status => 400;
    }
}