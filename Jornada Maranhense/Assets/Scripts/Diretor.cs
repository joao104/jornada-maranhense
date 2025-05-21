using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diretor : MonoBehaviour
{
    [SerializeField]
    private Text valorRecorde; 
    [SerializeField]
    private GameObject imagemGameOver;
    [SerializeField]
    private AudioSource somDeFundo;
    [SerializeField]
    private AudioSource audioGameOver; 
    private Pomba pomba;
    private Pontuacao pontuacao;
    private int recorde; 

    private void Start()
    {
        this.pomba = GameObject.FindObjectOfType<Pomba>();
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    public void FinalizarJogo()
    {
        Time.timeScale = 0;
        this.pontuacao.SalvarRecorde();
        this.AtualizarInterfaceGrafica();
        this.imagemGameOver.SetActive(true);
        this.somDeFundo.Stop(); 
        this.audioGameOver.Play(); 
    }

    public void ReiniciarJogo()
    {
        this.imagemGameOver.SetActive(false);
        Time.timeScale = 1;
        this.pomba.Reiniciar();
        this.DestruirObstaculos();
        this.somDeFundo.Play();
        this.pontuacao.Reiniciar(); // Corrigido com os parênteses
    }

    private void AtualizarInterfaceGrafica()
    {
        this.recorde = PlayerPrefs.GetInt("recorde");
        this.valorRecorde.text = recorde.ToString(); 
    }

    private void DestruirObstaculos()
    {
        Obstaculo[] obstaculos = GameObject.FindObjectsOfType<Obstaculo>();
        foreach (Obstaculo obstaculo in obstaculos)
        {
            obstaculo.Destruir();
        }
    }
}
