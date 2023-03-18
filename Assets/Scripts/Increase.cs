using UnityEngine;

public class Increase : MonoBehaviour
{
   public GameObject veget;
   public GameObject prefab;

   private void Update()
   {
      if (veget == null)
      {
         veget = Instantiate(prefab, transform.position, Quaternion.identity);
         veget.transform.parent = transform;
      }
   }


}
