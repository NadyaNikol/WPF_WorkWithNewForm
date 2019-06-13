namespace WpfApp1
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public double Salary { get; set; }
        public string Birthday { get; set; }
        public string Position { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {SecondName}, {Birthday}, {Salary} грн., {Position}";
        }
    }
}