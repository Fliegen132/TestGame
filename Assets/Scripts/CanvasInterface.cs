using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CanvasInterface : MonoBehaviour
{
   public Backpack Backpack;
   public TextMeshProUGUI countWheatText;
   public TextMeshProUGUI countCoinText;
   public int countCoin;
   private int count = 0;
   public Animator anim;

   public float time;
   public float maxTime;
   public void Update()
   {
      countWheatText.text = Backpack.currentSize + "/" +  Backpack.maxSize;
      countCoinText.text = count.ToString();

      time += Time.deltaTime;
      if (time >= maxTime)
      {
         if (countCoin > 0)
         {
            AnimationOn("CoinCountAnim");
            count++;
            countCoin--;
         }
         time = 0;
      }
   }

  

   public Image imagePrefab;
   public void DropCoin(int price)
   {
      Image go = Instantiate(imagePrefab,transform.position, Quaternion.identity);
      BehaviorCoin bc = go.GetComponent<BehaviorCoin>();
      bc.price = price;
      go.gameObject.transform.SetParent(transform);
      go.gameObject.transform.localScale = new Vector3(.3f,.3f,.3f);
   }

   public void AnimationOn(string nameAnim)
   {
      anim.SetBool(nameAnim, true);
   }
   
   public void AnimationOff(string nameAnim)
   {
      anim.SetBool(nameAnim, false);
   }
}
