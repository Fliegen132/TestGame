using UnityEngine;
using Random = UnityEngine.Random;

public class Extraction : MonoBehaviour
{
    public int id;
    public LayerMask layer;
    public string animName;
    
    public Backpack Backpack;
    public PlayerMovement Player;

    public DropObjects obj;
    
    public bool isRiped = false;
    [Header("Рост")]
    public float progress;
    public float maxProgress;
    public float speed;

    public int countCutting;
    private void Start()
    {
        Backpack = FindObjectOfType<Backpack>();
        Player = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        Vector3 size = new Vector3(1,1,1);
        if (progress < maxProgress && transform.localScale.x < size.x)
        {
            progress += Time.deltaTime * speed;
            transform.localScale = new Vector3(progress / maxProgress,  progress / maxProgress, progress / maxProgress);
        }
        else if (transform.localScale.x >= size.x)
        {
            isRiped = true;
        }
    }

    public BehaviorBlock block;
    public GameObject lastHitPrefab;
    public void Cutting()
    {
        var go = Instantiate(obj.CollectibleObject, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z),Quaternion.identity);
        block = go.GetComponent<BehaviorBlock>();
        block.price = obj.price;
        var position = go.transform.position;
        var direction = Random.insideUnitCircle.normalized;
        go.GetComponent<Rigidbody>().AddForce(direction.x , 6, Random.Range(-1,1), ForceMode.Impulse);
        countCutting--;
        if(countCutting <= 0)
            Destroy(gameObject);
        else
        {
            GameObject last = Instantiate(lastHitPrefab, gameObject.transform.GetChild(0).transform.position, lastHitPrefab.transform.rotation);
            last.transform.parent = transform;
            Destroy(gameObject.transform.GetChild(0).gameObject);
           
        }
    }



}
