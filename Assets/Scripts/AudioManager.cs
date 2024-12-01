    using UnityEngine;

    public class AudioManager : MonoBehaviour
    {

        [SerializeField] AudioSource musicSource;
        [SerializeField] AudioSource sfxSource;

        public AudioClip background;
        public AudioClip printer;
    public void Start ()
    {
        musicSource.clip = background; 
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    }
