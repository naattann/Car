using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFuel : MonoBehaviour
{
    public DrivingScript ds;

    public bool Add()
    {

        if (ds.enabled)
        {
            ds.nitroFuel += 1;
            ds.nitroFuel = Mathf.Clamp(ds.nitroFuel, 0, 5);
            ds.ChangeFuelTekst();
            return true;
        }
        else
        {
            return false;
        }

    }
}
