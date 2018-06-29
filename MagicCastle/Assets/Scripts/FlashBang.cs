using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class FlashBang : MonoBehaviour
{
     private CanvasGroup myCG;
     private bool flash = false;
     
	 void Awake()
	 {
		 myCG = GetComponent<CanvasGroup>();
	 }
	 
     void Update()
     {
         if (flash)
         {
             myCG.alpha = myCG.alpha - Time.deltaTime;
             if (myCG.alpha <= 0)
             {
                 myCG.alpha = 0;
                 flash = false;
             }
         }
     }
     
     public void Flash()
     {
         flash = true;
         myCG.alpha = 1;
     }
 }