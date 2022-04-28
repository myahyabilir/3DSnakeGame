using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bu class yeni yiyecekler oluşturur ve yok eder. Oluşan durumlara göre puan ekler. 
/// </summary>
public class FoodSpawner : MonoBehaviour
{

    [Header("Events")]
    [SerializeField] private VoidEvent onFoodEaten;

    [Header("Variables")]
    private Vector3 foodPos;
    private Vector3 oldFoodPos = Vector3.zero;
    private List<Vector3> childrenPos;
    private bool shouldSpawn = true;
    private LTDescr lt;

    [Header("GameObjects")]
    [SerializeField] private Transform snake;
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private Transform traps;
    private GameObject food;

    [Header("Pooler")]
    [SerializeField] private PoolController pooler;
    
    private void Start() {
        childrenPos = new List<Vector3>();
        Invoke("CheckPosition", 0.5f);
    }

    private void OnEnable() {
        onFoodEaten.OnEventRaised += CheckPosition;
    }
    private void OnDisable() {
        onFoodEaten.OnEventRaised -= CheckPosition;
    }

    /// <summary>
    /// Yeni çıkacak yiyeceğin pozisyonunu belirler. 
    /// </summary>
    private void CalculatePosition()
    { 
        oldFoodPos = foodPos;
        Bounds bounds = boxCollider.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z); 

        foodPos = new Vector3(Mathf.Round(x), transform.position.y, Mathf.Round(z));
    }

    /// <summary>
    /// Oluşturulan pozisyonun uygunluğunu kontrol eder. 
    /// </summary>
    private void CheckPosition()
    {
        if(lt != null) LeanTween.cancel(lt.id); 
        StopCoroutine("StartDisappering");
        if(shouldSpawn) CalculatePosition();
        
        foreach(Transform snakeNode in snake){
            childrenPos.Add(snakeNode.position);
        }

        foreach(Transform trap in traps){
            childrenPos.Add(trap.position);
        }

        foreach (Vector3 nodePos in childrenPos)
        {
            if(foodPos == nodePos || foodPos == oldFoodPos) {
                shouldSpawn = false;
                CalculatePosition();
                CheckPosition();
                return;
            }
        }

        shouldSpawn = true;
        SpawnObject(foodPos);
    }


    /// <summary>
    /// Oluşturulan pozisyona göre poolerdan yiyecek çağırır.
    /// </summary>
    /// <param name="pos">foodPos</param>
    private void SpawnObject(Vector3 pos)
    {    
        if(food != null) food.SetActive(false); 
        food = pooler.SpawnFromPool("food", pos, Quaternion.identity);
        StartCoroutine("StartDisappering");
    }


    /// <summary>
    /// Yiyeceğin 2 saniye içerisinde yenmemesi durumunda animasyon oynatır ve yiyeceği yok edip yenisini oluşturur.
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartDisappering()
    {
        yield return new WaitForSeconds(2f);

        if(food != null)
        {
            lt = LeanTween.scale(food, new Vector3(1.2f, 1.2f, 1.2f), 0.2f).setOnComplete(_ => {
                LeanTween.scale(food, Vector3.one, 0.2f).setOnComplete(value => {
                    LeanTween.scale(food, new Vector3(1.2f, 1.2f, 1.2f), 0.2f).setOnComplete(_ => {
                        LeanTween.scale(food, Vector3.one, 0.2f).setOnComplete(_ => {
                                CheckPosition();
                        });
                    });
                });
            });
        }
    }
}
