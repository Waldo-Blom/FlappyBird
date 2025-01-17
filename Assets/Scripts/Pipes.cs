using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
  public float speed = 5f; //Will also be used to chang the difficulty of the game
  private float leftEdge; //Will be used to know where an object needs to be deleted


  private void Start () 
  {
    //Use start function as it will only need to be caculated once
    leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x -1f;  //Convert from screen space to world space to make it device indedpent 
                                                                    //-1f to make sure the object is fully off the screen before deleting it

  }
  private void Update()
  {
    transform.position += Vector3.left * speed * Time.deltaTime;

    if(transform.position.x < leftEdge)
    {
        Destroy(gameObject); //Delete the game object when it is no longer needed
    }
  }
}
