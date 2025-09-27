using System;
using System.Web.UI;
using LogicLibrary; // Đảm bảo rằng LogicLibrary đã được tham chiếu đúng

namespace WebApplication
{
    public partial class api : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                // Lấy dữ liệu từ client qua POST
                string input = Request.Form["input"];

                // Kiểm tra nếu input trống hoặc null
                if (string.IsNullOrEmpty(input))
                {
                    string jsonError = "{\"error\":\"Vui lòng nhập dãy số hợp lệ.\"}";
                    Response.ContentType = "application/json";
                    Response.Write(jsonError);
                    return;
                }

                // Chuyển chuỗi thành mảng số nguyên bằng vòng lặp thay cho LINQ
                string[] inputArray = input.Split(',');
                int[] numbers = new int[inputArray.Length];

                try
                {
                    // Sử dụng vòng lặp để chuyển chuỗi thành số nguyên
                    for (int i = 0; i < inputArray.Length; i++)
                    {
                        // Kiểm tra nếu phần tử không thể chuyển đổi thành số nguyên
                        if (!int.TryParse(inputArray[i].Trim(), out numbers[i]))
                        {
                            string jsonError = "{\"error\":\"Vui lòng nhập dãy số hợp lệ, mỗi số cách nhau bằng dấu phẩy.\"}";
                            Response.ContentType = "application/json";
                            Response.Write(jsonError);
                            return;
                        }
                    }

                    // Gọi phương thức từ DLL để tính tổng
                    var mathOperations = new MathOperations();
                    int result = mathOperations.Sum(numbers);

                    // Trả kết quả về client dưới dạng JSON
                    string jsonResponse = "{\"sum\":" + result + "}";
                    Response.ContentType = "application/json";
                    Response.Write(jsonResponse);
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi ngoài FormatException, hiển thị lỗi chung
                    string jsonError = "{\"error\":\"Đã xảy ra lỗi: " + ex.Message + "\"}";
                    Response.ContentType = "application/json";
                    Response.Write(jsonError);
                }
            }
        }
    }
}
