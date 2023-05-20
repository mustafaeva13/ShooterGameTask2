using System.Collections;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    GameObject Go;
    Oyuncu player;
    void Start()
    {
        player = FindObjectOfType<Oyuncu>();
        StartCoroutine(CreateEnemy());
    }

    void Update()
    {

    }
    IEnumerator CreateEnemy()
    {
        float x = Random.Range(0, 3);
        float y = Random.Range(0, 3);
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Go = Instantiate(enemy, new Vector3(Random.Range(0, 6), 0, Random.Range(0, 6)), Quaternion.identity);
            Go.transform.LookAt(player.transform);
            Go.AddComponent<EnemyMove>();
        }
    }
}
