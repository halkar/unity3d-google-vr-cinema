using UnityEngine;
using UnityEngine.EventSystems;

public class Chairs : MonoBehaviour
{
    public GameObject chair;
    public int rows;
    public int cols;
    public Material inactiveMaterial;
    public Material gazedAtMaterial;
    public Mesh mesh;
    public GameObject player;

    // Use this for initialization
    void Start ()
	{
	    for (int i = 0; i < cols; i++)
	    {
	        for (int j = 0; j < rows; j++)
	        {
	            var clone = Instantiate(chair, gameObject.transform);
	            clone.transform.localRotation = new Quaternion(0, 180, 0, 1);
	            clone.transform.localPosition = new Vector3(-0.45f + i * (1f / cols), -0.45f + j * (1f / rows), 0);
	            clone.transform.localScale = new Vector3(0.04f, 0.04f, 0.2f);
	            var meshCollider = clone.AddComponent<MeshCollider>();
	            meshCollider.sharedMesh = mesh;
                var eventTrigger = clone.AddComponent<EventTrigger>();
	            var entry1 = new EventTrigger.Entry
	            {
	                eventID = EventTriggerType.PointerEnter
	            };
                entry1.callback.AddListener(data =>
                {
                    var halo = (Behaviour)clone.GetComponent("Halo");
                    halo.enabled = true;
                });
	            eventTrigger.triggers.Add(entry1);
	            var entry2 = new EventTrigger.Entry
	            {
	                eventID = EventTriggerType.PointerExit
	            };
	            entry2.callback.AddListener(data =>
	            {
	                var halo = (Behaviour)clone.GetComponent("Halo");
	                halo.enabled = false;
	            });
	            eventTrigger.triggers.Add(entry2);
	            var entry3 = new EventTrigger.Entry
	            {
	                eventID = EventTriggerType.PointerClick
	            };
	            entry3.callback.AddListener(data =>
	            {
	                player.transform.position = clone.transform.position;
	                player.transform.localPosition = new Vector3(player.transform.localPosition.x, player.transform.localPosition.y + 1.5f, player.transform.localPosition.z);
	            });
	            eventTrigger.triggers.Add(entry3);
            }
	    }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
