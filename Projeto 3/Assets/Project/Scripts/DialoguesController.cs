using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguesController : MonoBehaviour {

	string[] messages = new string[16];

	public Text msgText;

	// Use this for initialization
	void Start () {
		msgText.gameObject.SetActive (false);

		// MENSAGENS DAS PORTAS
		messages [0] = "Está trancada";
		messages [1] = "Esta porta não tem maçaneta";
		messages [2] = "Está emperrada";
		messages [3] = "Está trancada, deve haver alguma chave por aqui";
		messages [4] = "Está trancada";
		messages [5] = "As dobradiças estão soltas";
		messages [6] = "Está trancada";
		messages [7] = "Está coberta por tábuas de madeira";

		// PUZZLE DO BASEMENT
		messages [8] = "Huh??";
		messages [9] = "Nada aconteceu... por enquanto";

		// MENSAGENS DAS CHAVES
		messages [10] = "Talvez com essa chave eu consiga abrir alguma porta...";
		messages [11] = "Acho que consigo desemperrar alguma coisa com isso";
		messages [12] = "Agora eu consigo arrumar aquelas dobradiças";
		messages [13] = "Não tinha uma porta que estava sem maçaneta?";
		messages [14] = "Com isso eu consigo quebrar madeiras velhas";

		// MENSAGEM DE DEFEITO DE LUZ
		messages[15] = "Parece que não tem energia no prédio";
	}

	public void DisplayMessage(int msgIndex){
		msgText.text = messages [msgIndex].ToString ();
		msgText.gameObject.SetActive (true);
		Invoke ("DesactivateMessage", 2f);
	}

	void DesactivateMessage(){
		msgText.gameObject.SetActive (false);
	}
}
