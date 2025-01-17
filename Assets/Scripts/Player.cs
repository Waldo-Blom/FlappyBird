using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    //Variaibles used for sprites
    private SpriteRenderer spriteRenderer;
    public  Sprite[] sprites; //Arry of sprites that will be used

    private int spriteIndex;


    //Physics variables
    private Vector3 direction;

    public float gravity = -9.8f; //Change this value to make the game more difficult
                                  // When in Unity only the public varibles will show in the editor
    public float strength = 5f; //Also used to dictate how diffcult the game is
    private void Awake() // Awake is auto called by unity when the object is intialized i.e it is only called once per object
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start() //Start is auto called by unity the very first frame the object is called
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }
    public void Update() //Update is a fucntion that Unity automatically calls every frame the game is running //Is used for things like inputs recieved
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            direction = Vector3.up * strength;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime; //Update the position of the player and also make it framerate indepenedant 

        //Make the nose of the bird flap down and up
        Quaternion rot = transform.rotation;
        rot.z = direction.y * 0.02f;
        transform.rotation = rot;

    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;

        direction = Vector3.zero;

    }

    private void AnimateSprite()
    {
        spriteIndex ++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
            
        } else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseSore();
        }
    }

}

