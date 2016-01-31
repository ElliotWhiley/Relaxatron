using UnityEngine;
using System.Collections;

public class newSpawner : MonoBehaviour {

    public GameObject spawnTemplate;
    public int counter;

    // Use this for initialization
    void Start () {
     
    }
	
	// Update is called once per frame
	void Update () {
        CreateDataObject();
    }

    private void CreateDataObject()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject clone = Instantiate(spawnTemplate, transform.position, transform.rotation) as GameObject;
            Vector3 dir = new Vector3(Random.Range(0f, 1.0f), Random.Range(-1.0f, 1.00f), Random.Range(-1.0f, 1.0f));
            Debug.Log(dir);

            clone.GetComponent<Rigidbody>().velocity = dir.normalized * 30.0f;
            Destroy(clone, 14.0f);

        }

        //Instantiate(spawnTemplate, transform.position, transform.rotation);
        //spawnTemplate. = transform.TransformDirection((Random.insideUnitSphere) * 0.05f);
        ////spawnedObject = Instantiate(spawnTemplate, transform.position, transform.rotation) as GameObject;
        //// spawnedObject.GetComponent<cubeBehaviour>().SetData(data);
        //counter++;
        //Debug.Log("WE HAVE " + counter + " CUBES");
    }

}

