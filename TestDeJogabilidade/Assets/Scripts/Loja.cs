using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loja : MonoBehaviour
{
    public Text Titulo;
    public Text Descricao;
    public Text Valor;
    public GameObject TMais;
    public GameObject Vendido;
    public GameObject Negativado;
    public bool[] habilitado;
    
    void Start()
    {
        FecharMostrarMais();
        habilitado = new bool[1];
        habilitado[0] = false;
    }
    public void Fechar() {
    }
    public void FecharMostrarMais() {
        TMais.SetActive(false);
        Vendido.SetActive(false);
        Negativado.SetActive(false);
    }
    public void MostrarMais(int index) {
        TMais.SetActive(true);
        if (habilitado[index])
        {
            Vendido.SetActive(true);
        }
        else {
            Vendido.SetActive(false);
        }
        switch (index) {
            case 0:
                Titulo.text = "Delacao premiada";
                Descricao.text = "Purifica todos os efeitos negativos que voce possui";
                Valor.text = "500";
                break;
        }
    }
    public void Comprar(int index) {
        habilitado[index] = true;
        if (int.Parse(Valor.text) < GameManager.Money)
        {
            GameManager.Money -= int.Parse(Valor.text);
        }
        else {
            Negativado.SetActive(true);
        }
        
    }
}
