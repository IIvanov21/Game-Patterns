using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip, clipTwo, clipThree;
    float horizontal, vertical;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        audioSource.loop = false;
        audioSource.clip = clip;//Attached the sound to the audio source
        audioSource.spatialBlend = 0f;
        //audioSource.minDistance = 2f;
        //audioSource.maxDistance = 100f;
        audioSource.volume = 0.5f;
        audioSource.playOnAwake = false;
        audioSource.pitch = 2;
        audioSource.loop = true;
    }

    private void Start()
    {
        audioSource.Play();//Start the walking sound
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if(horizontal != 0f || vertical != 0f)//If we are walking UnPause
        {
            audioSource.UnPause();
        }
        else//Pause
        {
            audioSource.Pause();
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            audioSource.PlayOneShot(clip);
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            audioSource.PlayOneShot(clipTwo);
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            audioSource.PlayOneShot(clipThree);
        }
    }

    public void AudioSettings()
    {
        audioSource.Play();//General function that plays the sound attached to the audio source
        audioSource.PlayDelayed(5f);// Play with delay
        audioSource.PlayOneShot(clipTwo);

        audioSource.Pause();
        audioSource.UnPause();
        audioSource.Stop();
    }
}
