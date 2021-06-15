using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    public static GameObject skinToLoad;
    public GameObject defaultSkin;

    private void Awake()
    {
        Instantiate(defaultSkin,transform);

        if(skinToLoad!=null)
        {
            Destroy(defaultSkin);
            Instantiate(skinToLoad, transform);
        }
        
    }
}
