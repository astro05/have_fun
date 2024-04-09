namespace test.LinkedIn
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        ComplexNumber c1 = new ComplexNumber(5, 7); //Output: 5+i7
    //        c1.Display();

    //        ComplexNumber c2 = new ComplexNumber(2, 1); //Output: 2+i1
    //        c2.Display();

    //        ComplexNumber c3 = c1 + c2; //Output: 7+i8
    //        c3.Display();

    //        ComplexNumber c4 = -c1; //Output: -5-i7
    //        c4.Display();

    //        ComplexNumber c5 = ++c1; //Output: 6+i7
    //        c5.Display();

    //        Console.WriteLine(c1 == c2); //Output: False

    //        Console.ReadKey();
    //    }
    //}
    public class ComplexNumber
    {
        private int real;
        private int imaginary;
        public ComplexNumber(int r = 0, int i = 0)
        {
            real = r;
            imaginary = i;
        }

        //All Binary Operators(+, -, *, /, %, &, |, <<, >>) can be overloaded.
        public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
        {
            ComplexNumber temp = new ComplexNumber();
            temp.real = c1.real + c2.real;
            temp.imaginary = c1.imaginary + c2.imaginary;
            return temp;
        }

        //All Unary Operators(+, -, !,  ~, ++, --, true, false) can be overloaded.
        public static ComplexNumber operator -(ComplexNumber c)
        {
            return new ComplexNumber(-c.real, -c.imaginary);
        }

        public static ComplexNumber operator ++(ComplexNumber c)
        {
            return new ComplexNumber(c.real + 1, c.imaginary);
        }

        //All Relational Operators(==, !=, <, >, <= , >=) can be overloaded, but only as pairs to ensure consistency.
        public static bool operator ==(ComplexNumber c1, ComplexNumber c2)
        {
            return c1.real == c2.real && c1.imaginary == c2.imaginary;
        }

        public static bool operator !=(ComplexNumber c1, ComplexNumber c2)
        {
            return !(c1 == c2);
        }

        public void Display()
        {
            Console.WriteLine($"Complex Number: {real} + i{imaginary}");
        }
    };
}
