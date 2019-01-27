using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {
 //   private List<HitByRock> m_hitByRock = new List<HitByRock>();

 //   /// <summary>
 //   /// This rocks!
 //   /// </summary>
	//public void KillIfCollides()
 //   {
 //       for(int i=0; i<m_hitByRock.Count; ++i)
 //       {
 //           m_hitByRock[i].OnHitByRock();
 //       }
 //   }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitByRock killedByRock = collision.gameObject.GetComponent<HitByRock>();

        if (killedByRock)
        {
            killedByRock.OnHitByRock();
            //m_hitByRock.Add(killedByRock);
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    HitByRock killedByRock = collision.gameObject.GetComponent<HitByRock>();

    //    if (killedByRock)
    //    {
    //        m_hitByRock.Remove(killedByRock);
    //    }
    //}
}
