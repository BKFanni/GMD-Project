using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
public class settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown graphicsDropdown;
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void setMusic(float music)
    {
        audioMixer.SetFloat("music", music);
    }
    public void changeGraphicQuality()
    {
        QualitySettings.SetQualityLevel(graphicsDropdown.value);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
