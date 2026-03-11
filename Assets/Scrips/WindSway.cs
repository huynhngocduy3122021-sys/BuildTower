using UnityEngine;

public class WindSway : MonoBehaviour
{
    public float swayAngle = 8f;
    public float swaySpeed = 1.5f;
    private float randomOffset;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        randomOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        if (rectTransform != null)
        {
            float angle = Mathf.Sin((Time.time + randomOffset) * swaySpeed) * swayAngle;
            rectTransform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }
}