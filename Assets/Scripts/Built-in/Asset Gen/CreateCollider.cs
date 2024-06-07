using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCollider : MonoBehaviour
{
    private void Awake() {
        GameObject mesh = GameObject.Find("Mesh");
        mesh.AddComponent<MeshCollider>();
    }
}
