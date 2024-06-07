using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    int framesCounted;
    bool counting;

    void Start()
    {
        framesCounted = 0;
    }

    void Update()
    {
        framesCounted++;
    }
}
