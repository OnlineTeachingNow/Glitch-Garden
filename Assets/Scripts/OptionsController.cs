using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [Header("Volume Properties")]
    [SerializeField] Slider _volumeSlider;
    [SerializeField] float _defaultVolumeSlider = 0.8f;

    [Header("Difficulty Properties")]
    [SerializeField] Slider _difficultySlider;
    [SerializeField] float _defaultDifficulty = 1;


    void Start()
    {
        _volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        _difficultySlider.value = PlayerPrefsController.GetDifficultyLevel();
    }

    // Update is called once per frame
    void Update()
    {
        MusicPlayer _musicPlayer = FindObjectOfType<MusicPlayer>();
        if (_musicPlayer)
        {
            _musicPlayer.SetVolume(_volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found. Did you start from Splash screen?");
        }
    }
    public void SaveOptionsAndExit()
    {
        PlayerPrefsController.SetMasterVolume(_volumeSlider.value);
        PlayerPrefsController.SetDifficultyLevel(_difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefaults()
    {
        _volumeSlider.value = _defaultVolumeSlider;
        _difficultySlider.value = _defaultDifficulty;
    }
}
