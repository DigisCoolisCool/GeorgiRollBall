using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    public float speed; //zdes primaja skorost
    private Rigidbody rb; //zdes delaem ssylku na rigidb
    private float movementX;
    private float movementY;
    public AudioSource soundtrack;
    public AudioSource collectMusic;
    public int wallet;
    public Text scoretext;
    public GameObject finishtext;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scoretext.text = "My wallet: " + wallet;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "finish")
        {
            finishtext.SetActive(true);
        }
    
        if (other.gameObject.tag == "collect")
        {
            other.gameObject.SetActive(false);
            collectMusic.Play();
            wallet++;
            scoretext.text = "My wallet: " + wallet;
            if (wallet <= 0)
            {
                wallet = 0;
                scoretext.text = "My wallet: " + wallet;
            }
        }
        if (other.gameObject.tag == "respawn")
            {
            Application.LoadLevel(Application.loadedLevel);
        }

        if(other.gameObject.tag == "Music1")
        {
            soundtrack.Play();
        }

        if (other.gameObject.tag == "Pirat")
        {
            other.gameObject.SetActive(false);
            collectMusic.Play();
            wallet--;
            scoretext.text = "My wallet: " + wallet;
            if (wallet <= 0)
            {
                wallet = 0;
                scoretext.text = "My wallet: " + wallet;
            }
            
    }
    }


}

