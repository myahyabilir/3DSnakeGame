using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bu class halihazırdaki bir OnPointerDrag eventini alıp daha sonrasında Vector3'e göre yönünü ayarlamaktadır
/// Bu yön yılanın hareketini belirleyecektir.
/// </summary>
public class DirectionHandler : MonoBehaviour
{
    [SerializeField] Vector2Event onPointerDrag;
    [SerializeField] Vector3Event onDragDirection;
    private Vector3 direction;
    private bool timeIsDone = true;

    private void OnEnable() {
        onPointerDrag.OnEventRaised += CalculateDirection;
    }

    private void OnDisable() {
        onPointerDrag.OnEventRaised -= CalculateDirection;

    }

    /// <summary>
    /// Belli başlı değerlere göre yön ayarlaması gerçekleştiriyor.
    /// </summary>
    /// <param name="movement">OnPointerDrag'dan gelen parametre buraya geliyor</param>
    private void CalculateDirection(Vector2 movement)
    {
        if(!timeIsDone) return;
        StartCoroutine("IsTimeDone");

        float xValue = movement.x;
        float zValue = movement.y;

        if(Mathf.Abs(xValue) > Mathf.Abs(zValue))
        {
            if(xValue > 0) direction = Vector3.right;
            else direction = Vector3.left;
        }
        else
        {
            if(zValue > 0) direction = new Vector3(0f, 0f, 1f);
            else direction =  new Vector3(0f, 0f, -1f);
        }

        onDragDirection.Raise(direction);

    }

    private IEnumerator IsTimeDone()
    {
        timeIsDone = false;
        yield return new WaitForFixedUpdate();
        timeIsDone = true;
    }

}
