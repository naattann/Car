using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fuel : MonoBehaviour
{
    Collider col;
    Renderer rend;
    Color myColor;
    Color gray = new Color(0.5f, 0.5f, 0.5f, 0.5f);

    private void Start()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
        col.enabled = true;
        myColor = rend.material.color;
    }


    public IEnumerator UseFuel()
    {
        col.enabled = false;
        rend.material.color = gray;
        rend.material.SetColor("_EmissionColor", gray);
        yield return new WaitForSeconds(10);
        col.enabled = true;
        rend.material.color = myColor;
        rend.material.SetColor("_EmissionColor", myColor);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0.4f, -0.4f, 0.4f));
    }

    private void OnTriggerEnter(Collider other)
    {
        AddFuel auto = other.GetComponent<AddFuel>();
        if (auto != null && auto.Add())
        {
            StartCoroutine(UseFuel());
        }
    }
}
