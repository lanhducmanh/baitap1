using System;

namespace LogicLibrary
{
    public class MathOperations
    {
        // Phương thức tính tổng một dãy số
        public int Sum(int[] numbers)
        {
            int sum = 0;
            foreach (var num in numbers)
            {
                sum += num;
            }
            return sum;
        }
    }
}
