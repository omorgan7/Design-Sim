using UnityEngine;
using UnityEngine.UI;

public class UITransform : MonoBehaviour{
    public static void SetTransform(GameObject obj, GameObject reference, float xOffset,float yOffset){
		RectTransform objRT = obj.GetComponent<RectTransform>();
        RectTransform refRT = reference.GetComponent<RectTransform>();
		objRT.offsetMax = Vector2.zero;
		objRT.offsetMin = Vector2.zero;
		objRT.anchorMax = new Vector2(refRT.anchorMax.x-xOffset,refRT.anchorMax.y-yOffset);
		objRT.anchorMin = new Vector2(refRT.anchorMin.x-xOffset,refRT.anchorMin.y-yOffset);
	}
}