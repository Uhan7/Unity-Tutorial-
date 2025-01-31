using UnityEngine;
using UnityEngine.SceneManagement;

public class Emoji : MonoBehaviour
{
    public float rotationSpeed;
    public float moveSpeed;

    public GameObject winScreen;

    private bool keyIsHeld;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) keyIsHeld = true;
        else keyIsHeld = false;
    }

    void FixedUpdate()
    {
        if (!keyIsHeld) Spin();
        else Move();
    }

    void Move()
    {
        transform.position += transform.up * moveSpeed;
    }

    void Spin()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (col.gameObject.tag == "Diamond")
        {
            winScreen.SetActive(true);
        }
    }

}
