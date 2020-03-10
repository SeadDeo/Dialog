using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Threading.Tasks;


public class DialogLoad : MonoBehaviour
{
    public int speedText,dialogDelay;
    int currentNode=0,indexNode=0;
    public bool showDialog;
    public Text ObjDialog;
    public Dialog dialog;
    public Text[] ObjAnswers=new Text[3]; 
    public Button Accept,Cancel,Answer0,Answer1,Answer2,ButtAC,ButAnsw;
    public TextAsset ta ;
     Node dialNode = new Node();
    private void Start() {
        dialog = Dialog.Load(ta);
    }
    public void cancel_()//обнуляет текст и активирует/деактивирует кнопки
    {   
      
    }
    public void accept()//запускает диалог
    {
    ObjDialog.text=""; //обнуляет текст
    ButtAC.gameObject.SetActive(!ButtAC);//деактивирует
    ContinuationDialog();
    }
    //РАБОТА С ТЕКСТОМ/TEXT
    public void ContinuationDialog()
    {  
        for(indexNode=currentNode;indexNode<dialog.nodes.Length;indexNode++)
        {ButAnsw.gameObject.SetActive(!ButAnsw);

            if(dialog.nodes[indexNode].delay==1){ delay();}
            DialogOut(indexNode);
            AnswerOut(indexNode);
          break;  
        }
        
    }
    async void DialogOut(int indexNode){
        char[] ar = dialog.nodes[indexNode].NpcText.ToCharArray();
            for(int i=0;i<ar.Length;i++)
                {
                    ObjDialog.text+=ar[i];
                    await Task.Delay(speedText);
                }
            ObjDialog.text+="\n";
            ButAnsw.gameObject.SetActive(ButAnsw); 
        }
    
    async void delay(){
         for(int i=0;i<dialogDelay;i++)
        await Task.Delay(dialogDelay);
    }
    /// работа с КНОПАКМИ/BUTTON
    public void AnswerOut(int indexNode)
    {
        for (int i = 0; i <3; i++)
        ObjAnswers[i].text =  dialog.nodes[indexNode].answers[i].text;
    }
    public void AnswerZero()
    {
       currNodeZ(indexNode);
    }
     public void AnswerOne()
    {
       
       currNodeO(indexNode);
       
    }
     public void AnswerTwo()
    {
        
       currNodeT(indexNode);
       
    }
    public void currNodeZ(int indexNode){

        for(int i=0;i< dialog.nodes.Length;i++)
        {
        if(dialog.nodes[indexNode].answers[0].nextNode==dialog.nodes[i].numNode){
            currentNode=dialog.nodes[indexNode].answers[0].nextNode;
            break;
        }
        }
        ContinuationDialog();
    }
    public void currNodeO(int indexNode){

        for(int i=0;i< dialog.nodes.Length;i++)
        {
        if(dialog.nodes[indexNode].answers[1].nextNode==dialog.nodes[i].numNode){
            currentNode=dialog.nodes[indexNode].answers[1].nextNode;
            break;
        }
        }
        ContinuationDialog();
    }
    public void currNodeT(int indexNode){

        for(int i=0;i< dialog.nodes.Length;i++)
        {
        if(dialog.nodes[indexNode].answers[2].nextNode==dialog.nodes[i].numNode){
            currentNode=dialog.nodes[indexNode].answers[2].nextNode;
            break;
        }
        }
       
        ContinuationDialog();
    }
}