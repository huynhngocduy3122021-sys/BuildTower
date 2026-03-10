using UnityEngine;

public class MusicbackGround : MonoBehaviour
{
    public static MusicbackGround instance;
    private AudioSource audioSource;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void toggleMusic()
    {
        if(audioSource != null)
        {
            audioSource.mute = !audioSource.mute;
        }
    }

    public bool isMute()
    {
        return audioSource != null && audioSource.mute;
    }
}
