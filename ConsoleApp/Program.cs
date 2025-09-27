using System;
using LogicLibrary; // Tham chiếu DLL LogicLibrary

class Program
{
    static void Main(string[] args)
    {
        // Hướng dẫn người dùng nhập dữ liệu
        Console.WriteLine("Nhập dãy số cách nhau bởi dấu phẩy (ví dụ: 1,2,3):");

        // Đọc chuỗi nhập vào từ người dùng
        string input = Console.ReadLine();

        // Chuyển chuỗi nhập vào thành mảng số nguyên
        int[] numbers = Array.ConvertAll(input.Split(','), int.Parse);

        // Tạo đối tượng của MathOperations để tính tổng
        var mathOperations = new MathOperations();

        // Tính tổng dãy số
        int result = mathOperations.Sum(numbers);

        // Hiển thị kết quả tính tổng
        Console.WriteLine("Tổng dãy số là: " + result);

        // Chờ người dùng nhấn phím trước khi đóng ứng dụng
        Console.ReadLine();
    }
}
