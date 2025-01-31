using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float rotationRate;
    public float moveSpeed;

    public KeyCode moveKey;

    private bool isSpinning;

    public GameObject winScreen;

    void Update()
    {
        if (Input.GetKey(moveKey)) isSpinning = false;
        else isSpinning = true;
    }

    void FixedUpdate()
    {
        if (isSpinning) transform.Rotate(0, 0, rotationRate);
        else transform.position += transform.up * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall") SceneManager.LoadScene("Maze Game");
        if (col.gameObject.tag == "Diamond") winScreen.SetActive(true);
    }
}
