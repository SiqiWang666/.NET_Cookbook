namespace PracticeNotebook.CSharpLanguage.CSharp_8._0
{
    public struct ReadonlyInstanceMember
    {
        public decimal Salary { get; }
        private const decimal taxRate = 0.3m;

        public ReadonlyInstanceMember(decimal salary)
        {
            Salary = salary;
        }

        public readonly decimal PayTax => Salary * taxRate;
    }
}