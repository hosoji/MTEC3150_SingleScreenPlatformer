using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] footsteps;
    private AudioSource audioSource;
    private int index;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();   
    }

    public void PlayFootstep()
    {
        audioSource.Stop();
        index = Random.Range(0, footsteps.Length);
        float pitch = Random.Range(0.8f, 1.2f);

        audioSource.clip = footsteps[index];
        audioSource.pitch = pitch;
        audioSource.Play();

    }


}
