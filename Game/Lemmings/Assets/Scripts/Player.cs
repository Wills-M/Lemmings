using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	#region Singleton
    public static Player Instance { get; private set; }

    //If an instance of this singleton exists, then destroy the gameobject (this means there are more than one)
    //If an instance doesn't exist, create one
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("Warning: found more than one instance of PlayerColorController Singleton. Destroying " + gameObject.name + " gameobject.");
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    public Color CurrentColor { get; set; }

    private void Start()
    {
        CurrentColor = Color.Red;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            CurrentColor = Color.Red;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            CurrentColor = Color.Yellow;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            CurrentColor = Color.Blue;
    }
}
