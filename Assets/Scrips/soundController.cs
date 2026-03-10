using UnityEngine.UI;
using UnityEngine;

public class soundController : MonoBehaviour
{
    public Image iconSound;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    

    public void toggleSound()
    {
        if(MusicbackGround.instance != null)
        {
            MusicbackGround.instance.toggleMusic();
            UpdateIcon();
        }
    }
    private void UpdateIcon()
    {
        if(MusicbackGround.instance != null && iconSound != null)
        {
            iconSound.sprite = MusicbackGround.instance.isMute() ? soundOffSprite : soundOnSprite;
        }
    }
}
