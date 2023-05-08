using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public static VolumeManager instance { get; private set; }
    private AudioSource source;

    [SerializeField] Slider volumeSlider;
    void Awake() 
    {
        source = GetComponent<AudioSource>();
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(AudioClip sound)
    {
        source.PlayOneShot(sound);
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }
}
