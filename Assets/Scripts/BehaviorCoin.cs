using DG.Tweening;
using UnityEngine;

public class BehaviorCoin : MonoBehaviour
{
   public GameObject target;
   public int price;
   public CanvasInterface Interface;
   private void Start()
   {
      Interface = FindObjectOfType<CanvasInterface>();
      target = GameObject.FindWithTag("CoinText");
      transform.DOMove(target.transform.position, 1f).OnComplete(End);
   }
   
   private void End()
   {
      Debug.Log("okok");

      Interface.countCoin += price;
      Destroy(gameObject);
   }
}
