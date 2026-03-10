using UnityEngine;

public class ResultController : MonoBehaviour
{
    // Hàm cho nút Chơi Lại
    public void ChoiLai()
    {
        // Đặt lại timeScale phòng trường hợp game đang bị pause
        Time.timeScale = 1; 
        // Thay "GamePlay" bằng tên scene chơi game chính của bạn nếu khác
        loadingController.LoadScene("GamePlay"); 
    }

    // Hàm cho nút Chơi Tiếp
    public void ChoiTiep()
    {
        Time.timeScale = 1;
        // Nếu bạn có nhiều level, thay "GamePlay" bằng biến lưu tên level tiếp theo
        // Tạm thời mình set load lại GamePlay
        loadingController.LoadScene("GamePlay"); 
    }

    // Hàm cho nút Thoát
    public void ThoatVeMenu()
    {
        Time.timeScale = 1;
        // Load về scene Menu chính
        loadingController.LoadScene("StartGame"); 
    }
}