using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour {

    public Text dialogText;//Diálogo 
    public TextAlignment nameTest;//Nome de quem fala
    public GameObject dalogBox;//para saber se deve mostar ou não na UI
    public GameObject nameBox;

    //string[] declarando um array do tipo String
    public string[] dialogLines;

    public int currentLine;

	
	void Start () {
        //Dentro do dialog box eu tenho o objeto Text e dentro dele eu acesso a variável text, por isso é dialogText.text
        dialogText.text = dialogLines[currentLine];//current Line tem 0 como default, vai incrementando.
	}

	void Update () {
		

	}
}
