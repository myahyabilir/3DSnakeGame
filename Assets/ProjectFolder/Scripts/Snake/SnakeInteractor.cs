using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Yılan'ın collide etmesi sonucu triggerladığı her obje için oluşması gereken eventler burada raise edilmektedir.
/// </summary>
public class SnakeInteractor : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private VoidEvent onFoodEaten;
    [SerializeField] private BoolEvent onGameFinishedSuccessful;
    [SerializeField] private IntEvent onScoreGained; 

    [Header("Layers")]
    [SerializeField] private LayerMask foodLayerMask;
    [SerializeField] private LayerMask obstacleLayerMask;
    [SerializeField] private LayerMask nodeLayerMask;

    private void OnTriggerEnter(Collider other) {
        if((1 << other.gameObject.layer & foodLayerMask) != 0)
        {
            onFoodEaten.Raise();
            onScoreGained.Raise(1);
        }

        if((1 << other.gameObject.layer & obstacleLayerMask) != 0)
        {
            onGameFinishedSuccessful.Raise(false);
        }

        if((1 << other.gameObject.layer & nodeLayerMask) != 0)
        {
            onGameFinishedSuccessful.Raise(false);
        }
    }

}
