using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used to spawmn the pipes in the game
public class Spawer : MonoBehaviour
{
 public GameObject prefab; // the variable used for the pipe prefab

 public float spawnRate = 1f; //The rate at which the pipes spawn (is a float because we are going to increment in seconds)


//Variables will be used to create a range to be used for wihtin the pipes will spawn
 public float minHeight = -1f;
 public float maxHeight = 1f;

//Similar to the invoke reapeating used in the player script but this will only be called when it is enabled
//Because we only want to call it when it will be used (for example it will not be used if the game has ended)
 private void OnEnable() //Called automatically by Unity when script is enabled
 {
     InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);   
 }

private void OnDisable() //Called automatically by Unity when script is disabled
{
    CancelInvoke(nameof(Spawn)); //The cancels the InvokeRepeating

}

 private void Spawn()
{
    //Create a new instance of a prefab object that is going to be dupilcated
    GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity); //Quaternion.identity means no rotation of the object
    pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight); //Create the pipes at random positions within the min and max height

}
}