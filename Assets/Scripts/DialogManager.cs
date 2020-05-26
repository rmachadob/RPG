using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour {

    public Text dialogText;//Diálogo 
    public TextAlignment nameTest;//Nome de quem fala
    public GameObject dialogBox;//para saber se deve mostar ou não na UI
    public GameObject nameBox;

    //string[] declarando um array do tipo String
    public string[] dialogLines;

    public int currentLine;

	
	void Start () {
        //Dentro do dialog box eu tenho o objeto Text e dentro dele eu acesso a variável text, por isso é dialogText.text
        dialogText.text = dialogLines[currentLine];//current Line tem 0 como default, vai incrementando.
	}

	void Update () {

        //we can only do this if the dialog box is open
        if (dialogBox.activeInHierarchy)    //is this active at the scene at the moment?

        //--------------além do getAxisRaw eu tenho tambem o metodo getbutton disponiveis pela classe Input------------------------
        //-------------GetButton significa: o botão está sendo apertado? se o player segurar o botão ele skipa todo o diálogo de uma vez---------------------


        {//GetButtonUp só pega quando aperta
            if (Input.GetButtonUp("Fire1"))//Edit-ProjectSettings-Input(menu com os botoes para mapeamento, estou usando o Fire1 aqui(olhar classe playerController)
            {
                currentLine++;//currentLine sempre pega a proxima entao uso ele como i


                if (currentLine >= dialogLines.Length)///if para não estourar o meu array
                {
                    dialogBox.SetActive(false);//desativo o dialogo

                }
                else
                {
                dialogText.text = dialogLines[currentLine];

                }

            }
        }

	}
}
