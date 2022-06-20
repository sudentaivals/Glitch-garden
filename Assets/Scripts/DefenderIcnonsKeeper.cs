using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderIcnonsKeeper : MonoBehaviour
{
    [SerializeField] float _iconSizeUnits = 0.75f;

    void Start()
    {
        int counter = 0;
        foreach (Transform tr in transform)
        {
            tr.position = new Vector3(_iconSizeUnits * counter + 1, transform.position.y, transform.position.z);
            counter++;
        }
    }

}
