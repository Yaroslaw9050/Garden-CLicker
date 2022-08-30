using UnityEngine;
using DG.Tweening;

public class AppearanceObject : MonoBehaviour
{
    [SerializeField] private float startYPostion;
    [Space(10)]
    [SerializeField] private float step;
    [SerializeField] private float animationTime;

    private void Start()
    {
        ResetPosition();
    }
    public void ResetPosition()
    {
        Vector3 startPosition = new Vector3(0f, startYPostion, 0f);
        transform.localPosition = startPosition;
    }
    public void EndStep()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + step, transform.position.z);

        transform.DOMove(newPosition, animationTime);
    }
}
