using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public GameObject DLight;
    public GameObject Box;
    bool Cycle = false, CheckNight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Cycle)
        {
            DLight.transform.Rotate(Vector3.up, Time.deltaTime * 100);
            //Debug.Log(DLight.transform.rotation.x);
            if (DLight.transform.rotation.x > 0.4 || DLight.transform.rotation.x < -0.4)
            {
                foreach (GameObject i in GameObject.FindGameObjectsWithTag("NightLight"))
                {
                    i.GetComponent<Light>().enabled = false;
                }
            }
            else
            {
                foreach (GameObject i in GameObject.FindGameObjectsWithTag("NightLight"))
                {
                    i.GetComponent<Light>().enabled = true;
                    CheckNight = true;
                }
            }
            if (DLight.transform.rotation.x > 0.7 && DLight.transform.rotation.x < 0.8 && CheckNight)
            {
                Cycle = false;
                GetComponent<GameManager1>().LightReply = true;
            }
        }
    }

    public void NewCycle()
    {
        Cycle = true;
        CheckNight = false;
    }
}
