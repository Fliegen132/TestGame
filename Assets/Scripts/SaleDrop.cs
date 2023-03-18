using UnityEngine;
public class SaleDrop : MonoBehaviour
{
    public GameObject child;
    public Backpack Backpack;
    public BehaviorBlock block;
    public GameObject barn;
    [SerializeField] private float progress;
    public float speed;
    private void Update()
    {
        if (child != null)
        {
            var position = child.transform.position;
            progress = Time.deltaTime * speed;
            Vector3 target = new Vector3(barn.transform.position.x, barn.transform.position.y, barn.transform.position.z);
            child.transform.position = Vector3.Lerp(child.transform.position, target, progress);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        child = null;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.GetComponent<Backpack>())
        {
            Debug.Log("вошел");
            
            Backpack = collision.gameObject.GetComponent<Backpack>();
            if (child == null)
            {
                if (Backpack.gameObject.transform.childCount > 0)
                {
                    child = Backpack.gameObject.transform.GetChild(Backpack.currentSize - 1).gameObject;
                    block = child.GetComponent<BehaviorBlock>();
                    block.isTaked = false;
                    block.Sale();
                }

            }

        }
    }
    
}
