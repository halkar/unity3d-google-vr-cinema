using UnityEngine;

public class Chairs : MonoBehaviour
{
    public GameObject chair;
    public int rows;
    public int cols;

	// Use this for initialization
	void Start ()
	{
	    for (int i = 0; i < cols; i++)
	    {
	        for (int j = 0; j < rows; j++)
	        {
	            var clone = Instantiate(chair, gameObject.transform);
	            clone.transform.localRotation = new Quaternion(0, 180, 0, 1);
	            clone.transform.localPosition = new Vector3(-0.5f + i * (1f / cols), -0.5f + j * (1f / rows), 0);
	            clone.transform.localScale = new Vector3(0.04f, 0.04f, 0.2f);
            }
	    }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
