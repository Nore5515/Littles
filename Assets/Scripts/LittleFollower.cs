using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DG.Tweening;

public class LittleFollower : MonoBehaviour
{
    public GameObject followTarget;

    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        // UpdateTargetPosition();
        // DOTween.SetTweensCapacity(4, 4);
        // transform.DOMove(targetPosition, 1, false);
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    void UpdateTargetPosition()
    {
        targetPosition = followTarget.transform.position;
        targetPosition.y = targetPosition.y - 0.35f;
        targetPosition += GetDirectionToTarget(targetPosition);
    }

    Vector3 GetDirectionToTarget(Vector3 targetVector)
    {
        Vector3 direction = this.transform.position - targetPosition;
        return Vector3.Normalize(direction);
    }

    void FollowTarget()
    {
        UpdateTargetPosition();
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, Time.deltaTime * 4);
        // DOTween.Clear();
        // DOTween.To(() => this.transform.position, x => this.transform.position = x, targetPosition, 0.5f);
        // transform.DORestart();
        // transform.DOPlay();
        // DOTween.Restart();
        // DOTween.To(() => this.transform.position, x => this.transform.position = x, targetPosition, 1);
    }

    public void SelfDestruct()
    {
        Destroy(this.gameObject);
    }
}
