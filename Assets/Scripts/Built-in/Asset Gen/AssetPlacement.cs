using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AssetPlacement : MonoBehaviour {
    [System.Serializable]
    public class NatureAsset {
        public string name;
        [SerializeField] public GameObject[] prefabs;
        [SerializeField] public int amount;
        [SerializeField] public Vector2 scaleRange;
        [SerializeField] public Vector2 heightRange;
        [SerializeField] public float groundingOffset; // amount to be "shoved" into the ground, mainly for trees
        [SerializeField] public int xBound = 800;
        [SerializeField] public int zBound = 800;
        [SerializeField] public bool obstacle;
    }

    public NatureAsset[] assets;
    public GameObject water;
    public int globalScale = 1;
    private Vector3 meshSize;
    private GameObject natureAssetsContainer;

#if UNITY_EDITOR
    public void PlaceAssets() {
        // Make sure to clear all the current nature assets if there are any
        natureAssetsContainer = GameObject.Find("Nature Assets Container");
        DestroyImmediate(natureAssetsContainer);

        // Create a new container to store all the assets
        natureAssetsContainer = new GameObject("Nature Assets Container");

        for (int i = 0; i < assets.Length; i++) {
            NatureAsset currentAsset = assets[i];
            GameObject parent = new GameObject(currentAsset.name + " Container");
            parent.transform.SetParent(natureAssetsContainer.transform);

            // Initialize mesh size
            meshSize = new Vector3(currentAsset.xBound, 100, currentAsset.zBound);

            for (int j = 0; j < currentAsset.amount; j++) {
                bool placed = false;

                while (!placed) {
                    Vector3 randomPos = new Vector3(Random.Range(-meshSize.x, meshSize.x), 0, Random.Range(-meshSize.z, meshSize.z));

                    RaycastHit hit;
                    if (Physics.Raycast(new Vector3(randomPos.x, 1000, randomPos.z), Vector3.down, out hit, Mathf.Infinity)) {
                        if (hit.point.y > currentAsset.heightRange.x && hit.point.y < currentAsset.heightRange.y && hit.collider.gameObject != water) {
                            //Debug.Log(hit.collider.gameObject.name); // to see the name of the object hit by the raycast
                            Vector3 placementPos = new Vector3(randomPos.x, hit.point.y - currentAsset.groundingOffset, randomPos.z);
                            Quaternion placementRot = Quaternion.Euler(0, Random.Range(0, 360), 0);
                            GameObject placementPrefab = currentAsset.prefabs[Random.Range(0, currentAsset.prefabs.Length)];

                            GameObject clone = Instantiate(placementPrefab, placementPos, placementRot, parent.transform);
                            clone.transform.localScale *= globalScale * Random.Range(currentAsset.scaleRange.x, currentAsset.scaleRange.y);
                            if(currentAsset.obstacle) {
                                clone.AddComponent<NavMeshObstacle>(); // make the object an obstacle for animals
                            }
                            placed = true;
                        }
                    }
                }
            }
        }
    }
}
#endif
