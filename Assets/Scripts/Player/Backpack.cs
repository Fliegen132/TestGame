using UnityEngine;

public class Backpack : MonoBehaviour
{
   public int maxSize;
   public int currentSize;
   public CanvasInterface Interface;
   public void Fold(GameObject extracted, ref bool isTaked)
   {
      if(currentSize >= maxSize)
         return;
      
      currentSize++;
      extracted.GetComponent<Rigidbody>().isKinematic = true;
      extracted.GetComponent<Rigidbody>().useGravity = false;
      extracted.transform.parent = transform;
      extracted.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
      Interface.AnimationOn("AnimForCount");
      isTaked = true;

   }
}
