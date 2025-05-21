using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 0.5f;

    [SerializeField]
    private float variacaoDaPosicaoY;

    private Vector3 posicaoDoAviao;
    private Pontuacao pontuacao;
    private bool pontuei = false;

    private void Awake()
    {
        // Aplica variação aleatória na posição Y ao instanciar o obstáculo
        this.transform.Translate(Vector3.up * Random.Range(-variacaoDaPosicaoY, variacaoDaPosicaoY));
    }

    private void Start()
    {
        // Acha a posição inicial da pomba e o sistema de pontuação
        this.posicaoDoAviao = GameObject.FindObjectOfType<Pomba>().transform.position;
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    private void Update()
    {
        // Move o obstáculo para a esquerda
        this.transform.Translate(Vector3.left * this.velocidade * Time.deltaTime);

        // Verifica se já passou da pomba e ainda não pontuou
        if (!this.pontuei && this.transform.position.x < this.posicaoDoAviao.x)
        {
            this.pontuacao.AdicionarPontos();
            this.pontuei = true; // Marca como já pontuado
        }
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        this.Destruir();
    }

    public void Destruir()
    {
        GameObject.Destroy(this.gameObject);
        
    }
}
