using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;
public class settings : MonoBehaviour
{
    public AudioMixer volumeMixer;
    public AudioMixer musicMixer;
    public TMP_Dropdown graphicsDropdown;
    public float volumeValue;
    public float musicValue;
    public Slider volumeSlider;
    void start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("");
    }
    void update()
    {
        volumeMixer.SetFloat("volume", volumeValue);
        musicMixer.SetFloat("music", musicValue);
        PlayerPrefs.SetFloat("volume", volumeValue);
        PlayerPrefs.SetFloat("music", musicValue);
    }
    public void setVolume(float volume)
    {
        volumeValue = volume;
    }
    public void setMusic(float music)
    {
        musicValue = music;
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
