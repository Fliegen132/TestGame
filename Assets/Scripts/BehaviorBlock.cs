using System.Collections;
using UnityEngine;

public class BehaviorBlock : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private Backpack Backpack;

    public bool isGround;
    public bool isTaked = false;

    [SerializeField]private float progress;
    public float speed;
    [SerializeField]private float pos;
    public int price;
    private bool isTakble = false;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Backpack = FindObjectOfType<Backpack>();
    }

    private void Update()
    {
        var position = Backpack.transform.position;
        progress = Time.deltaTime * speed;
        Vector3 target = new Vector3(position.x, position.y + pos, position.z);

        float distance = Vector3.Distance(transform.position, Backpack.transform.position);
        
        if (isGround && distance <= 3 && !isTaked)
        {
            Backpack.Fold(this.gameObject, ref isTaked);
        }
        
        if (isTaked)
        {
            if (isTakble == false)
            {
                pos = GetComponent<Collider>().bounds.size.y * Backpack.currentSize;
                isTakble = true;
            }
            transform.position = Vector3.Lerp(transform.position, target, progress);
        }
    }

    public void Sale()
    {
        StartCoroutine(Sale2());
    }

    public CanvasInterface Interface;
    private IEnumerator Sale2()
    {
        Interface = FindObjectOfType<CanvasInterface>();
        yield return new WaitForSeconds(.2f);
        Interface.DropCoin(price);
        Backpack.currentSize--;
        isTaked = false;
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGround = false;
    }
}
