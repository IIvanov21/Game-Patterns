using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SimpleMove : MonoBehaviour
{
    private AudioSource m_AudioSource;
    public float speed = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime*speed);
    }
}
