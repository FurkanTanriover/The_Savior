using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayViewer : MonoBehaviour
{
    public float weaponRange = 50f;

    private Camera fpsCam;
    void Start()
    {
        fpsCam = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // hat başlangıcı tanımlıyorum ve bu kameramın tam ortasına denk geliyor(0.5 sağ alttan sağ ortaya , 0.5alt ortadan yukarıya)
        Vector3 lineOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        //scene ekranımda ışınımı görmek için debug yapıyorum
        Debug.DrawRay(lineOrigin, fpsCam.transform.forward * weaponRange, Color.green);
    }
}
