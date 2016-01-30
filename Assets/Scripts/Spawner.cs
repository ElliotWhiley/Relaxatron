using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public int worldX;
    public int worldY;
    public int worldZ;
    public int numObjects;
    public int numFishies;
    public GameObject prefab;

    void Start() {
        SpawnSchool();
        //Vector3 center = transform.position;
        //for (int i = 0; i < numObjects; i++)
        //{
        //    Vector3 pos = RandomCircle(center, 5.0f);
        //    Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
        //    Instantiate(prefab, pos, rot);
        //}
    }

    Vector3 RandomCircle(Vector3 center, float radius) {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }

    void SpawnSchool() {
        Vector3 spawnCentre = new Vector3(-500, 300, -500);
        int spawnRadius = 30;
        float spacing = 2;
        for (int i = 0; i < numFishies; i++) {
            // generate random pos within spawn sphere
            Vector3 spawnPos = spawnCentre + Random.insideUnitSphere * spawnRadius;
            // check if that pos is 'free'
            Collider[] collisions = Physics.OverlapSphere(spawnPos, spacing);
            Debug.Log(collisions.Length);
            if (collisions.Length == 1) {
                // set fish rotation
                Quaternion rotation = Quaternion.Euler(new Vector3(50, 30, 10));
                // spawn fish at pos
                GameObject fish = (GameObject) Instantiate(prefab, spawnPos, rotation);
                fish.GetComponent<Rigidbody>().AddForce(new Vector3(50, 30, 30) * 50);

            }
        }
    }
}