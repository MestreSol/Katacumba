using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum GameState{
    Menu,
    Loja,
    NormalTopTower,
    NormalInTower
}
public class GameManager : MonoBehaviour
{
    public GameState State;
    public int enemysOfTower = 0;
    public int enemysInTower = 0;
    public Enemy[] EnemyInTower;
    public static int CurrentWeapon = 0;
    public static int Money;
    public static int Pontos;
    public AudioSource Musica;

    public Text PontosText;
    public Text MoneyText;
    public GameObject PabloVitar;
    public Canvas UIGame;
    public Canvas Loja;
    void Start()
    {
        State = GameState.NormalTopTower;
        DontDestroyOnLoad(Musica);
        DontDestroyOnLoad(gameObject);
    }

    
    void Update()
    {
        PontosText.text = "PONTOS: "+Pontos;
        MoneyText.text = Money.ToString();
        if (Input.GetKeyDown("p")) {
            State = GameState.Loja;
            AbrirLoja();
        }
        if (Input.GetKeyDown("s")) {
            if (State == GameState.NormalTopTower) {
                State = GameState.NormalInTower;
                SceneManager.LoadScene("InTower");
            } 
        }
        if (Input.GetKeyDown("w")) {
            if (State == GameState.NormalInTower) {
                State = GameState.NormalTopTower;
                SceneManager.LoadScene("TopTower");
            } 
        }
    }
    public void AbrirLoja()
    {
        SceneManager.LoadScene("Loja");
        PabloVitar.gameObject.SetActive(false);
    }
   
}
