using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private AudioClip sfxDeath;
    Animator anim;
    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private bool jump = false;


    void Awake()
    {
        Assert.IsNotNull(sfxJump);
        Assert.IsNotNull(sfxDeath);
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!GameManager.instance.GameOver && GameManager.instance.GameStarted)
        {
            if (GameManager.instance.PlayerActive)
            {
                GameManager.instance.setScore(1f * Time.deltaTime);
            }
            if (Input.GetMouseButtonDown(0))
            {
                anim.Play("jump");
                GameManager.instance.PlayerStartedGame();
                audioSource.PlayOneShot(sfxJump);
                rigidBody.useGravity = true;
                
                jump = true;
            }
        }
       
        
    }

    void FixedUpdate()
    {
        if (jump == true )
        {
            jump = false;
            rigidBody.velocity = new Vector2(0f, 0f);
            rigidBody.AddForce(new Vector2(0, 100f), ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            rigidBody.AddForce(new Vector2(50, 20), ForceMode.Impulse);
            rigidBody.detectCollisions = false;
            audioSource.PlayOneShot(sfxDeath);
            GameManager.instance.PlayerCollided();
        }
    }
}
