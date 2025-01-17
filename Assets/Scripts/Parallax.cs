using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public float animationSpeed = 1f; // Used to change the speed at which the background moves

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

    }

    private void Update()
    {
        //Change the offset to give the effect of the player moving by moving the background
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
