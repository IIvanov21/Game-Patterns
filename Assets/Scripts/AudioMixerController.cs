using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerController : MonoBehaviour
{
    [Header("Audio Mixer")]
    public AudioMixer audioMixer;

    [Header("UI Elements")]
    //Master Volume controls
    public Slider masterSlider;
    public TMP_Text masterText;

    //Background Music Volume controls
    public Slider backgroundMusicSlider;
    public TMP_Text backgroundMusicText;

    //Player Music Volume controls
    public Slider playerMusicSlider;
    public TMP_Text playerMusicText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Subsribing to the slider events
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        backgroundMusicSlider.onValueChanged.AddListener(SetBackgroundMusicVolume);
        playerMusicSlider.onValueChanged.AddListener(SetPlayerMusicVolume);

        //Update text values and audio mixer values
        SetMasterVolume(masterSlider.value);
        SetBackgroundMusicVolume(backgroundMusicSlider.value);
        SetPlayerMusicVolume(playerMusicSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("Master",volume);
        UpdateText(masterText,volume);
    }

    public void SetPlayerMusicVolume(float volume)
    {
        audioMixer.SetFloat("Player Music",volume);
        UpdateText(playerMusicText,volume);
    }

    public void SetBackgroundMusicVolume(float volume)
    {
        audioMixer.SetFloat("Background Music", volume);
        UpdateText(backgroundMusicText,volume);
    }

    private void UpdateText(TMP_Text textElement, float volume)
    {
        float percent = Mathf.InverseLerp(-80f, 0f, volume) * 100f;
        textElement.text=$"{Mathf.RoundToInt(percent)}";
    }
}
