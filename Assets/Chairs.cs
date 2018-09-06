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
                var nestedGameObject = new GameObject();
	            nestedGameObject.transform.parent = gameObject.transform;
	            var clone = Instantiate(chair, nestedGameObject.transform);
	            nestedGameObject.transform.localRotation = new Quaternion(0, 180, 0, 0);
	            nestedGameObject.transform.localPosition = new Vector3(-0.45f + i * (1f / cols), -0.45f + j * (1f / rows), 0);
	            nestedGameObject.transform.localScale = new Vector3(0.04f, 0.04f, 0.2f);
	            clone.transform.localPosition = new Vector3(0, 0, 0);
                clone.transform.localEulerAngles = new Vector3(10, 0, 0);
                var meshCollider = clone.AddComponent<MeshCollider>();
	            meshCollider.sharedMesh = mesh;
                var eventTrigger = clone.AddComponent<EventTrigger>();
	            var pointerEnterEvent = new EventTrigger.Entry
	            {
	                eventID = EventTriggerType.PointerEnter
	            };
                pointerEnterEvent.callback.AddListener(data =>
                {
                    var halo = (Behaviour)clone.GetComponent("Halo");
                    halo.enabled = true;
                });
	            eventTrigger.triggers.Add(pointerEnterEvent);
	            var pointerExitEvent = new EventTrigger.Entry
	            {
	                eventID = EventTriggerType.PointerExit
	            };
	            pointerExitEvent.callback.AddListener(data =>
	            {
	                var halo = (Behaviour)clone.GetComponent("Halo");
	                halo.enabled = false;
	            });
	            eventTrigger.triggers.Add(pointerExitEvent);
	            var pointerClickEvent = new EventTrigger.Entry
	            {
	                eventID = EventTriggerType.PointerClick
	            };
	            pointerClickEvent.callback.AddListener(data =>
	            {
	                player.transform.position = clone.transform.position;
	                player.transform.localPosition = new Vector3(player.transform.localPosition.x, player.transform.localPosition.y + 1.5f, player.transform.localPosition.z);
	            });
	            eventTrigger.triggers.Add(pointerClickEvent);
            }
	    }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
