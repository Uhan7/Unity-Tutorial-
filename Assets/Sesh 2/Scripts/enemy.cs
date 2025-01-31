using UnityEngine;

public class enemy : MonoBehaviour
{
    private AudioSource aSource;

    public AudioClip hitSFX;

    private void Awake()
    {
        aSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        aSource.PlayOneShot(hitSFX);
    }
}
