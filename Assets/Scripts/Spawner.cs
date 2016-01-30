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
        // spawn small school
        SpawnFishies(spawnCentre: new Vector3(-400, 300, -400), spawnRadius: 50, spacing: 10, numFishies: 1000, rotation: Quaternion.Euler(new Vector3(50, 30, 10)), scale: 3f, speed: 20, forceDirection: new Vector3(50, 30, 30));
        // spawn medium school
        SpawnFishies(spawnCentre: new Vector3(500, 300, -200), spawnRadius: 100, spacing: 10, numFishies: 200, rotation: Quaternion.Euler(new Vector3(50, 30, 10)), scale: 10f, speed: 15, forceDirection: new Vector3(50, 30, 30));
    }

    void SpawnFishies(Vector3 spawnCentre, int spawnRadius, float spacing, int numFishies, Quaternion rotation, float scale, int speed, Vector3 forceDirection) {
        for (int i = 0; i < numFishies; i++) {
            // generate random pos within spawn sphere
            Vector3 spawnPos = spawnCentre + Random.insideUnitSphere * spawnRadius;
            // check if that pos is 'free'
            Collider[] collisions = Physics.OverlapSphere(spawnPos, spacing);
            if (collisions.Length == 1) {
                // spawn fish at pos
                GameObject fish = (GameObject)Instantiate(prefab, spawnPos, rotation);
                // set fish size
                fish.GetComponent<Rigidbody>().transform.localScale = new Vector3(scale, scale, scale);
                // set fish speed
                fish.GetComponent<Rigidbody>().AddForce(forceDirection * speed);
            }
        }
    }

    void SpawnLargeSchool() {
        Vector3 spawnCentre = new Vector3(500, 300, -200);
        int spawnRadius = 100;
        float spacing = 10;
        for (int i = 0; i < numFishies / 3; i++) {
            // generate random pos within spawn sphere
            Vector3 spawnPos = spawnCentre + Random.insideUnitSphere * spawnRadius;
            // check if that pos is 'free'
            Collider[] collisions = Physics.OverlapSphere(spawnPos, spacing);
            if (collisions.Length == 1) {
                // set fish rotation
                Quaternion rotation = Quaternion.Euler(new Vector3(50, 30, 10));
                // spawn fish at pos
                GameObject fish = (GameObject)Instantiate(prefab, spawnPos, rotation);
                // set fish size
                fish.GetComponent<Rigidbody>().transform.localScale = new Vector3(10f, 10f, 10f);
                // set fish speed
                fish.GetComponent<Rigidbody>().AddForce(new Vector3(-35, 15, 20) * 15);
            }
        }
    }
}