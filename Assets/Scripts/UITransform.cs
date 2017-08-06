using UnityEngine;
using UnityEngine.UI;

public class UITransform : MonoBehaviour{
    public static void SetTransform(GameObject obj, GameObject reference, float xOffset,float yOffset){
		RectTransform objRT = obj.GetComponent<RectTransform>();
        RectTransform refRT = reference.GetComponent<RectTransform>();
		objRT.offsetMax = Vector2.zero;
		objRT.offsetMin = Vector2.zero;
		objRT.anchorMax = new Vector2(reference.anchorMax.x-xOffset,reference.anchorMax.y-yOffset);
		objRT.anchorMin = new Vector2(reference.anchorMin.x-xOffset,reference.anchorMin.y-yOffset);
	}
}