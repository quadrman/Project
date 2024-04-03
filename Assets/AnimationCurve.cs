using UnityEngine;
public class MoveObject : MonoBehaviour
{
    public Transform targetPosition;
    public AnimationCurve moveCurve;
    public float moveDuration = 1f;
    private float moveTimer = 0f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private void Start()
    {
        startPosition = transform.position;
        endPosition = targetPosition.position;
    }
    private void Update()
    {
        if (moveTimer < moveDuration)
        {
            moveTimer += Time.deltaTime;
            float t = moveTimer / moveDuration;
            float curveValue = moveCurve.Evaluate(t);
            transform.position = Vector3.Lerp(startPosition, endPosition, curveValue);
        }
    }
}
