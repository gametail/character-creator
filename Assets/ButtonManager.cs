using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public CharacterCreator cc;

    public GameObject styleUI;
    public TextMeshProUGUI style;

    public Sprite unselected;
    public Sprite selected;
    public Sprite male;
    public Sprite female;


    public Image skin;
    public Image hair;
    public Image shirt;
    public Image pants;
    public Image shoes;
    public Image gender;
    
    public Image genderImage;

    public Image colorPreview;

    private int selectedCategory = 0;
    private bool selectedGender = true;

    private void Start() {
        selectCategory(0);

    }


    public void selectCategory(int cat){
        hair.sprite = unselected;
        skin.sprite = unselected;
        shirt.sprite = unselected;
        pants.sprite = unselected;
        shoes.sprite = unselected;

        switch((CharacterCreator.Category)cat){

            case CharacterCreator.Category.SKIN:
                styleUI.SetActive(false);
                selectedCategory = cat;
                skin.sprite = selected;
                style.text = "";
                colorPreview.color = cc.skinTones[cc.skinColorID];
            break;

            case CharacterCreator.Category.HAIR:
                styleUI.SetActive(true);
                selectedCategory = cat;
                hair.sprite = selected;
                style.text = (cc.hairStyle + 1).ToString();
                colorPreview.color = cc.hairColors[cc.hairColorID];
            break;

            case CharacterCreator.Category.SHIRT:
                styleUI.SetActive(true);
                selectedCategory = cat;
                shirt.sprite = selected;
                style.text = (cc.shirtID + 1).ToString();
                colorPreview.color = cc.colors[cc.shirtColorID];
            break;

            case CharacterCreator.Category.PANTS:
                styleUI.SetActive(true);
                selectedCategory = cat;
                pants.sprite = selected;
                style.text = (cc.pantsID + 1).ToString();
                colorPreview.color = cc.colors[cc.pantsColorID];
            break;

            case CharacterCreator.Category.SHOES:
                styleUI.SetActive(true);
                selectedCategory = cat;
                shoes.sprite = selected;
                style.text = (cc.shoesID + 1).ToString();
                colorPreview.color = cc.colors[cc.shoesColorID];
            break;

            default:
                Debug.Log("could not find Category");
            break;
        }
    }
    public void switchGender(){
        if(selectedGender){
            selectedGender = false;
            cc.setGender(1);
        }
        else{
            selectedGender = true;
            cc.setGender(0);
        }
        updateGender();
    }
    public void updateGender(){
        if(cc.gender == CharacterCreator.Gender.MALE){
            //Male
            genderImage.sprite = unselected;
            gender.sprite = male;
        }
        else{
            //Female
            genderImage.sprite = selected;
            gender.sprite = female;
        }
    }
    public void updateStylePreview(){
        switch(selectedCategory){
            case 0:
                
            break;

            case 1:
                style.text = (cc.hairStyle + 1).ToString();
            break;

            case 2:
                style.text = (cc.shirtID + 1).ToString();
            break;
                
            case 3:
                style.text = (cc.pantsID + 1).ToString();
            break;

            case 4:
                style.text = (cc.shoesID + 1).ToString();
            break;
        }
    }
    public void updateColorPreview(){
        switch(selectedCategory){
            case 0:
                colorPreview.color = cc.skinTones[cc.skinColorID];
            break;

            case 1:
                colorPreview.color = cc.hairColors[cc.hairColorID];
            break;

            case 2:
                colorPreview.color = cc.colors[cc.shirtColorID];
            break;
                
            case 3:
                colorPreview.color = cc.colors[cc.pantsColorID];
            break;

            case 4:
                colorPreview.color = cc.colors[cc.shoesColorID];
            break;
        }
    }

    public void closeApp(){
        Application.Quit();
    }
}
