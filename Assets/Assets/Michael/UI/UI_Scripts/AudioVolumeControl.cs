using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeControl : MonoBehaviour
{
    public static AudioVolumeControl instance;
    public AudioSource sfxSource;
    public AudioSource bgmSource;
    private float sfxVolume;
    private float bgmVolume;
    public Slider sfxSlider;
    public Slider bgmSlider;
    private bool sfxEnabled = true;
    private bool bgmEnabled = true;


    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        // Link the slider's value change event to a method
        sfxSlider.onValueChanged.AddListener(OnSfxSliderChanged);
        bgmSlider.onValueChanged.AddListener(OnBgmSliderChanged);
    }

    private void OnSfxSliderChanged(float volume)
    {
        // Set the audio source volume based on the slider value
        sfxSource.volume = volume;
        sfxVolume = volume;
    }

    private void OnBgmSliderChanged(float volume)
    {
        // Set the audio source volume based on the slider value
        bgmSource.volume = volume;
        bgmVolume = volume;
    }

    public void ToggleSfx()
    {
        sfxEnabled = !sfxEnabled; // Toggle audio state

        if (sfxEnabled)
        {
            sfxSource.volume = sfxVolume; // Set volume back to slider value
        }
        else
        {
            sfxSource.volume = 0f; // Mute audio
        }
    }

    public void ToggleBGM()
    {
        bgmEnabled = !bgmEnabled; // Toggle audio state

        if (bgmEnabled)
        {
            bgmSource.volume = bgmVolume; // Set volume back to slider value
        }
        else
        {
            bgmSource.volume = 0f; // Mute audio
        }
    }
}
