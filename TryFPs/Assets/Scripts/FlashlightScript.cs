using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{

    public Light flashlight;

    public bool on = false;

    // Start is called before the first frame update
    void Start()
    {
        on = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            if (on == false)
            {

                flashlight.enabled = true;

                on = true;

            }

            else
            {
                flashlight.enabled = false;

                on = false;
            }
        }
    }
}
