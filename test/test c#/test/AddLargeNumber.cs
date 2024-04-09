namespace test
{
    public class AddLargeNumber
    {
        public static string AddLargeNumbers(string a, string b)
        {
            int maxLength = Math.Max(a.Length, b.Length);
            char[] result = new char[maxLength + 1];
            int carry = 0;

            for (int i = 0; i < maxLength; i++)
            {
                int numA = i < a.Length ? a[a.Length - 1 - i] - '0' : 0;
                int numB = i < b.Length ? b[b.Length - 1 - i] - '0' : 0;

                int sum = numA + numB + carry;
                carry = sum / 10;
                result[maxLength - i] = (char)(sum % 10 + '0');
            }
            result[0] = (char)(carry + '0');

            return new string(result).TrimStart('0');
        }
    }
}
