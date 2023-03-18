using UnityEngine;

public class GatherResources : MonoBehaviour
{
    public GameObject point;
    private PlayerMovement player;
    public GameObject[] tools;
    [SerializeField]private string _nameAnim;
    private Tools tool;
    private void Start()
    {
        player = GetComponent<PlayerMovement>();
        tools = GameObject.FindGameObjectsWithTag("Tool");
    }
    private RaycastHit hit;
    private Ray ray;
    private void Update()
    {
        ray = new Ray(point.transform.position, point.transform.forward);
        Debug.DrawRay(point.transform.position, point.transform.forward * 1.5f, Color.blue);
        if (Physics.Raycast(ray, out hit, 1f))
        {
            if(!hit.collider.gameObject.GetComponent<Extraction>())
                return;
            
            for (int i = 0; i < tools.Length; i++)
            {
                tool = tools[i].GetComponent<Tools>();
                if (tool.layer == hit.collider.GetComponent<Extraction>().layer
                    && tool.id == hit.collider.GetComponent<Extraction>().id 
                    && hit.collider.GetComponent<Extraction>().isRiped == true)
                {
                    tools[i].SetActive(true);
                    _nameAnim = hit.collider.GetComponent<Extraction>().animName;
                    player.Chop(_nameAnim);
                }
            }
        }
        else
        {
            player.ExitChop(_nameAnim);
            for (int i = 0; i < tools.Length; i++)
            {
                tools[i].SetActive(false);
            }
        }
    }

    public void Cut()
    {
        if (!hit.collider)
            return;
        
        hit.collider.GetComponent<Extraction>().Cutting();
    }
}
