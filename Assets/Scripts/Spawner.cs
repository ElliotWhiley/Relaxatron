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
        // prefab.AddForce(prefab.transform.forward * Bullet_Forward_Force * (bulletForceMin + rb.velocity.magnitude), ForceMode.Impulse);
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
        Vector3 spawnCentre = new Vector3(-500, 200, -500);
        int spawnRadius = 20;
        float spacing = 2;
        for (int i = 0; i < numFishies; i++) {
            // generate random pos within spawn sphere
            Vector3 spawnPos = spawnCentre + Random.insideUnitSphere * spawnRadius;
            // check if that pos is 'free'
            Collider[] collisions = Physics.OverlapSphere(spawnCentre, spacing);
            Debug.Log(collisions.Length);
            if (collisions.Length == 1) {
                // spawn fish at pos
                Instantiate(prefab, spawnPos, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
        }
    }
}