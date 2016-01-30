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
        Time.timeScale = 0;
        SpawnSphericalSchool();
        Time.timeScale = 1;
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

    void SpawnSphericalSchool() {
        Vector3 spawnCentre = new Vector3(-500, 260, -500);
        int spawnRadius = 50;
        float spacingRadius = 10;
        float scale = 3f;

        for (int i = 0; i < numFishies; i++) {
            // generate random pos within spawn sphere
            Vector3 spawnPos = spawnCentre + Random.insideUnitSphere * spawnRadius;
            // check if that pos is 'free'
            Collider[] collisions = Physics.OverlapSphere(spawnCentre, spacingRadius);
            Debug.Log(collisions.Length);
            if (collisions.Length == 1) {
                // set fish rotation
                Quaternion rotation = Quaternion.Euler(1500, 800, 1500);
               // Quaternion rotation = Quaternion.Euler(0, 0, 0);
                // spawn fish at pos
                GameObject fish = (GameObject) Instantiate(prefab, spawnPos, rotation);
                // set fish size
                fish.transform.localScale += new Vector3(scale, scale, scale);
                // set fish velocity
                //fish.GetComponent<Rigidbody>().velocity = Quaternion.Euler(1500, 800, 1500);
                //fish.transform.forward = ;  


                //fish.transform.rotation = Quaternion.identity;

                fish.GetComponent<Rigidbody>().AddForce(transform.forward * 100);
                //prefab.GetComponent<Rigidbody>().velocity = ;



            }
        }
    }
}
