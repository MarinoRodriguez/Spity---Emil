using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float Timer;

    public GameObject burbuja;

    public float TiempoRecolocacionBurbuja;
    float contadorRecolocarBurbuja;

    private void Start()
    {
        RecolocarBurbuja();
    }
    private void Update()
    {
        if (Timer <= 0)
        {
            Timer = 0;
            return;
        }
        contadorRecolocarBurbuja += Time.deltaTime;

        if (contadorRecolocarBurbuja > TiempoRecolocacionBurbuja)
        {
            RecolocarBurbuja();
            contadorRecolocarBurbuja = 0;
        }

        Timer -= Time.deltaTime;
    }

    void RecolocarBurbuja()
    {
        float nX = Random.Range(Limitador.MinX + 1.5f, Limitador.MaxX - 1.5f);
        var pos = burbuja.transform.position;
        pos.x = nX;
        pos.y = Limitador.percent25.y;

        burbuja.transform.position = pos;
    }
}
