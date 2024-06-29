using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeRoomBG : MonoBehaviour
{
    [SerializeField] private Sprite[] backgrounds;

    public SpriteRenderer Render;

	void OnAwake ()
    {
        Render = GetComponent<SpriteRenderer>(); 
        /*assigning the Render to the object's SpriteRender, this will allow us to access the image from 
        code*/
        Render.sprite = backgrounds[Random.Range(0, backgrounds.Length)]; 
        /*this will change the current sprite of the sprite renderer to a random sprite that was chosen 
        randomly from the array of backgrounds */
    }
}