using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
public class settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void setMusic(float music)
    {
        audioMixer.SetFloat("music", music);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
