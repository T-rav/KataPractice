using System.Collections.Generic;

namespace Numbers_to_Words
{
    public class NumberToWordConverter
    {
        private readonly IDictionary<int, string> _lookupDigits = new Dictionary<int, string>()
        {
            {0, "zero"},
            {1, "one"},
            {2, "two"},
            {3, "three"},
            {4, "four"},
            {5, "five"},
            {6, "six"},
            {7, "seven"},
            {8, "eight"},
            {9, "nine"},

            {10,"ten"},
            {20,"twenty"},
            {30,"thirty"},
            {40,"fourty"},
            {50,"fifty"},
            {60,"sixty"},
            {70,"seventy"},
            {80,"eighty"},
            {90,"ninety"},
        };

        public string Convert(int input)
        {
            if (HasDirectNumberToStringTranslation(input))
            {
                return GetNumberAsString(input);
            }

            var oneDigitKey = input%10;
            var twoDigitKey = input - oneDigitKey;

            return GetNumberAsString(twoDigitKey)+"-"+GetNumberAsString(oneDigitKey);
        }

        private string GetNumberAsString(int input)
        {
            return _lookupDigits[input];
        }

        private bool HasDirectNumberToStringTranslation(int input)
        {
            return _lookupDigits.ContainsKey(input);
        }
    }
}