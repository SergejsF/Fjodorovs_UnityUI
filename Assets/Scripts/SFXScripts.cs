
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SFXScript : MonoBehaviour
{
    public AudioSource sFXSource;
    public AudioSource backGroundSound;
    public Slider backGroundVolumeSlider;
    public TMP_Text backGroundVolumeText;
    public AudioClip[] audioClip;
    public TMP_Text muteLabel;
    public Color mutedColor = Color.red;

    private Color normalColor;
    private string normalLabelText;

    private void Awake()
    {
        if (muteLabel != null)
        {
            normalColor = muteLabel.color;
            normalLabelText = muteLabel.text;
        }

        SetupBackGroundVolumeSlider();

        UpdateMuteVisual();
    }

    private void OnDisable()
    {
        if (backGroundVolumeSlider != null)
        {
            backGroundVolumeSlider.onValueChanged.RemoveListener(SetBackGroundVolume);
        }
    }

    private void SetupBackGroundVolumeSlider()
    {
        if (backGroundVolumeSlider == null || backGroundSound == null)
        {
            return;
        }

        backGroundVolumeSlider.minValue = 1f;
        backGroundVolumeSlider.maxValue = 100f;

        float currentValue = Mathf.Clamp(backGroundSound.volume * 100f, 1f, 100f);
        backGroundVolumeSlider.SetValueWithoutNotify(currentValue);
        backGroundVolumeSlider.onValueChanged.RemoveListener(SetBackGroundVolume);
        backGroundVolumeSlider.onValueChanged.AddListener(SetBackGroundVolume);
        SetBackGroundVolume(currentValue);
    }

    public void PlaySFX(int ix) {
        if(sFXSource.isPlaying)
            sFXSource.Stop();

        sFXSource.PlayOneShot(audioClip[ix]);
    }

    public void ToggleMute()
    {
        AudioListener.pause = !AudioListener.pause;
        UpdateMuteVisual();
    }

    public void SetBackGroundVolume(float sliderValue)
    {
        if (backGroundSound == null)
        {
            return;
        }

        float clampedValue = Mathf.Clamp(sliderValue, 1f, 100f);
        float normalizedVolume = clampedValue / 100f;
        backGroundSound.volume = normalizedVolume;
        UpdateBackGroundVolumeText(clampedValue);
    }

    private void UpdateBackGroundVolumeText(float value)
    {
        if (backGroundVolumeText == null)
        {
            return;
        }

        backGroundVolumeText.text = "Volume: " + Mathf.RoundToInt(value);
    }

    private void UpdateMuteVisual()
    {
        if (muteLabel == null)
        {
            return;
        }

        if (AudioListener.pause)
        {
            muteLabel.color = mutedColor;
            muteLabel.text = "<s>" + normalLabelText + "</s>";
        }
        else
        {
            muteLabel.color = normalColor;
            muteLabel.text = normalLabelText;
        }
    }
}
