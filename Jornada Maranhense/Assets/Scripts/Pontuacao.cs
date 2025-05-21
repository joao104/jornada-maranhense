using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour
{
    public int pontos {get; private set;} 
    [SerializeField]
    private Text textoPontuacao;
    [SerializeField]
    private AudioSource audioPontuacao;

    public void AdicionarPontos()
    {
        this.pontos++;
        this.textoPontuacao.text =  this.pontos.ToString();
        this.audioPontuacao.Play();
    }

    public void Reiniciar()
    {
        this.pontos = 0;
        this.textoPontuacao.text =  this.pontos.ToString();
    }

    public void SalvarRecorde()
    {
        int recordeAtual = PlayerPrefs.GetInt("recorde");
        if(this.pontos > recordeAtual) 
        {
            PlayerPrefs.SetInt("recorde", this.pontos);
        }
    }

} 
