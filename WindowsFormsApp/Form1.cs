using System;
using System.Windows.Forms;
using LogicLibrary; // Tham chiếu DLL LogicLibrary

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ TextBox
            string input = txtInput.Text;

            // Chuyển chuỗi input thành mảng số nguyên
            int[] numbers;
            try
            {
                // Tách chuỗi dựa trên dấu phẩy và chuyển thành mảng số nguyên thủ công
                string[] inputArray = input.Split(',');
                numbers = new int[inputArray.Length];

                for (int i = 0; i < inputArray.Length; i++)
                {
                    numbers[i] = int.Parse(inputArray[i].Trim()); // Chuyển mỗi phần tử thành số nguyên
                }
            }
            catch (FormatException)
            {
                // Nếu người dùng nhập sai định dạng, hiển thị thông báo lỗi
                MessageBox.Show("Vui lòng nhập dãy số hợp lệ, cách nhau bởi dấu phẩy.");
                return;
            }

            // Tạo đối tượng của lớp MathOperations từ DLL
            var mathOperations = new MathOperations();

            // Tính tổng các số và hiển thị kết quả trên Label
            int result = mathOperations.Sum(numbers);
            lblResult.Text = "Tổng dãy số là: " + result;
        }
    }
}
