using System.Collections;
using UnityEngine;

public class Egg : MonoBehaviour
{
    private GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        StartCoroutine(Hatch());
    }

    IEnumerator Hatch()
    {
        yield return new WaitForSeconds(10f);
        gameController.HatchEgg(transform.position);
        Destroy(gameObject);
    }
}
