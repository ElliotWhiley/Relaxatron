using UnityEngine;

public class ColorChange : MonoBehaviour {

    public GameObject cube;
    float duration = 20;
    float interpolateDuration = 10;

    Color[] colors = { Color.red, Color.green, Color.blue, Color.yellow, Color.gray };
    Color colorStart = Color.red;
    Color colorEnd = Color.green;

    float rate = 0.2f; // Times per sec new color is chosen
    float i = 0;
    int j = 0;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        i += Time.deltaTime * rate;

        // Blends towards next color in color array
        cube.GetComponent<Renderer>().material.color = Color.Lerp(colorStart, colorEnd, i);

        // If we've got to the current target colour, choose a new one
        if (i >= 1) {
            i = 0;

            j++;
            if (j == colors.Length - 1) {
                colorStart = colors[j];
                colorEnd = colors[0];
            }
            else if (j == colors.Length) {
                colorStart = colors[0];
                colorEnd = colors[1];
                j = 0;
            }
            else {
                colorStart = colors[j];
                colorEnd = colors[j + 1];
            }
        }
    }
}
