using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSystem : MonoBehaviour
{
    public GameObject item1, item2, item3, item4, item5;
    public static int powerBar = 0;


    // Start is called before the first frame update
    void Start()
    {
        item1.gameObject.SetActive(false);
        item2.gameObject.SetActive(false);
        item3.gameObject.SetActive(false);
        item4.gameObject.SetActive(false);
        item5.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (powerBar > 5)
            powerBar = 5;

        switch (powerBar)
        {
            case 5:
                item1.gameObject.SetActive(true);
                item2.gameObject.SetActive(true);
                item3.gameObject.SetActive(true);
                item4.gameObject.SetActive(true);
                item5.gameObject.SetActive(true);
                break;
            case 4:
                item1.gameObject.SetActive(true);
                item2.gameObject.SetActive(true);
                item3.gameObject.SetActive(true);
                item4.gameObject.SetActive(true);
                item5.gameObject.SetActive(false);
                break;
            case 3:
                item1.gameObject.SetActive(true);
                item2.gameObject.SetActive(true);
                item3.gameObject.SetActive(true);
                item4.gameObject.SetActive(false);
                item5.gameObject.SetActive(false);
                break;
            case 2:
                item1.gameObject.SetActive(true);
                item2.gameObject.SetActive(true);
                item3.gameObject.SetActive(false);
                item4.gameObject.SetActive(false);
                item5.gameObject.SetActive(false); 
                break;
            case 1:
                item1.gameObject.SetActive(true);
                item2.gameObject.SetActive(false);
                item3.gameObject.SetActive(false);
                item4.gameObject.SetActive(false);
                item5.gameObject.SetActive(false); 
                break;
            case 0:
                item1.gameObject.SetActive(false);
                item2.gameObject.SetActive(false);
                item3.gameObject.SetActive(false);
                item4.gameObject.SetActive(false);
                item5.gameObject.SetActive(false); 
                break;
        }
    }
}
