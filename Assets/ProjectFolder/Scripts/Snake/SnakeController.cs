using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Yılanın hareketleri bu classda belirlenecektir.
/// </summary>
public class SnakeController : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private Vector3Event onDragDirection;
    [SerializeField] private VoidEvent onFoodEaten;

    [Header("Variables")]
    [SerializeField] private BoolVariable isGameStarted;
    private List<Transform> children;
    private Vector3 rotation = new Vector3(0f,90f,0f);
    private Vector3 direction = Vector3.right;

    [Header("Objects")]
    [SerializeField] private GameObject head;

    [Header("Pooler")]
    [SerializeField] private PoolController pooler;

    private void OnEnable() {
        onDragDirection.OnEventRaised += FinalizeDirection;
        onFoodEaten.OnEventRaised += AddNodeToList;
    }

    private void OnDisable() {
        onDragDirection.OnEventRaised -= FinalizeDirection;
        onFoodEaten.OnEventRaised -= AddNodeToList;
    }

    private void Start() {
        children = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            children.Add(transform.GetChild(i));
        }
        isGameStarted.SetValue(false);
    }

    /// <summary>
    /// InputController'ın yolladığı eventi bu classın içerisinden ulaşılabilen direction Vector3'üne atıyor.
    /// Ayrıca yılanın rotasyonunu da belirliyor ve rotation Vector3'üne atıyor.
    /// </summary>
    /// <param name="direction_from_event"></param>
    private void FinalizeDirection(Vector3 direction_from_event)
    {
        if(direction == direction_from_event) return; 
        if(direction == -direction_from_event) return;
        direction = direction_from_event;

        if(direction == Vector3.right) rotation = new Vector3(0f,90f,0f);
        if(direction == new Vector3(0f, 0f, 1f)) rotation = new Vector3(0f,0f,0f);
        if(direction == Vector3.left) rotation = new Vector3(0f,270f,0f);
        if(direction == new Vector3(0f, 0f, -1f)) rotation = new Vector3(0f,180f,0f);

    }


    /// <summary>
    /// Yeni yılan elemanı eklenir
    /// </summary>
    private void AddNodeToList()
    {
        GameObject node = pooler.SpawnFromPool("node", children[children.Count - 1].position, Quaternion.identity);
        children.Add(node.transform);
        node.transform.SetParent(transform);
    }

    /// <summary>
    /// Yılanın hareketi sağlanır
    /// </summary>
    private void Move()
    {
        if(!isGameStarted.GetValue()) return;
        for(int i = children.Count-1; i > 0; i--)
        {
            children[i].position = children[i-1].position;
            children[i].eulerAngles = children[i-1].eulerAngles;
        }

        head.transform.position = new Vector3(Mathf.Round(head.transform.position.x) + direction.x, transform.position.y, Mathf.Round(head.transform.position.z) + direction.z);

        head.transform.eulerAngles = rotation;
    }  

    private void FixedUpdate() {
        Move();
    }

}
