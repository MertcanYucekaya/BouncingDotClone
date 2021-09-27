using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject rotationChange;
    int zRotation;
    
    void Start()
    {
        zRotation = 0;   
    }

    
    void Update()
    {
        
    }
    public void leftbutton()
    {
        zRotation = zRotation + 60;
        rotationChange.transform.rotation = Quaternion.Euler(0, 0,zRotation );
    }
    public void rightButton()
    {
        zRotation = zRotation - 60;
        rotationChange.transform.rotation = Quaternion.Euler(0, 0, zRotation);
    }
}
