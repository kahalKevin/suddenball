using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour {

	// Use this for initialization
    //Game Object
    public SpriteRenderer goTransform;

	void Start () 
    {
        goTransform.color = Color.green;
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
