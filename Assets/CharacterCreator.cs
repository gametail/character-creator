using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreator : MonoBehaviour
{
    public Texture2D cursor;
    public Material mat;
    private Texture2D texture;
    private Texture2D textureCopy;

    public Texture2D skin;
    public Texture2D eyebrow;
    //swap to array later for different styles
    public Texture2D pants;
    public Texture2D shirt;
    public Texture2D shoes;

    public Texture2D[] pants2;
    public Texture2D[] shirt2;
    public Texture2D[] shoes2;



    public Transform headAnchor;
    public Material hairMat;
    public GameObject[] hairMale;
    public GameObject[] hairFemale;
    private GameObject currentHair;

    public enum Gender{
        MALE = 0,
        FEMALE = 1,
        DIVERSE = 2
    }
    public enum Category{
        SKIN = 0,
        HAIR = 1,
        SHIRT = 2,
        PANTS = 3,
        SHOES = 4
    }


    //Colors for swap
    private Color skinKey = new Color(1f, 0.5f, 0);
    private Color hairKey = new Color(0, 1f, 0);
    private Color pantsKey = new Color(1f, 1f, 0);
    private Color shirtKey = new Color(0.5f, 1f, 0);
    private Color shoesKey = new Color(1f, 0, 0);

    public Color[] colors = new Color[] { 
        new Color32(255,255,255, 255),
        new Color32(255,102,102, 255),
        new Color32(255,178,102, 255),
        new Color32(255,255,102, 255),
        new Color32(178,255,102, 255),
        new Color32(102,255,102, 255),  
        new Color32(102,255,178, 255),  
        new Color32(102,255,255, 255),  
        new Color32(102,178,255, 255),  
        new Color32(102,102,255, 255),  
        new Color32(178,102,255, 255),  
        new Color32(255,102,255, 255),  
        new Color32(255,102,178, 255),  
        new Color32(192,192,192, 255),  
        new Color32(0,0,0, 255),
        };

    public Color[] skinTones = new Color[]{
        new Color32(194,153,95, 255),
        new Color32(223,184,130, 255),
        new Color32(233,197,147, 255),
        new Color32(246,215,172, 255),
        new Color32(255,228,191, 255),

        new Color32(200,165,92, 255),
        new Color32(216,188,128, 255),
        new Color32(219,192,135, 255),
        new Color32(226,201,146, 255),
        new Color32(232,209,159, 255),

        new Color32(102,83,63, 255),
        new Color32(192,147,101, 255),
        new Color32(207,159,110, 255),
        new Color32(227,181,134, 255),
        new Color32(254,222,191, 255),

        new Color32(139,85,47, 255),
        new Color32(179,126,87, 255),
        new Color32(197,146,103, 255),
        new Color32(206,155,110, 255),
        new Color32(223,171,126, 255),

        new Color32(212,138,123, 255),
        new Color32(254,197,161, 255),
        new Color32(254,216,193, 255),
        new Color32(254,231,216, 255),
        new Color32(255,244,232, 255),

        new Color32(100,49,2, 255),
        new Color32(253,183,159, 255),
        new Color32(255,206,176, 255),
        new Color32(255,217,191, 255),
        new Color32(255,228,210, 255),
        new Color32(255,244,221, 255)

    };

    public Color[] hairColors = new Color[] {
        //black - brown - red - orange
        new Color32(0,0,0, 255),
        new Color32(29,29,4, 255),
        new Color32(41,21,11, 255),
        new Color32(75,41,25, 255),
        new Color32(49,0,6, 255),
        new Color32(75,16,24, 255),
        new Color32(72,12,43, 255),
        new Color32(126,59,94, 255),
        new Color32(107,11,15, 255),
        new Color32(153,29,37, 255),
        new Color32(171,102,61, 255),
        new Color32(238,95,35, 255),
        new Color32(192,103,103, 255),

        //yellows
        new Color32(255,184,61, 255),
        new Color32(255,203,61, 255),
        new Color32(240,224,50, 255),

        //greens
        new Color32(46,71,24, 255),
        new Color32(78,115,45, 255),
        new Color32(145,189,105, 255),

        //blues
        new Color32(28,28,78, 255),
        new Color32(62,61,154, 255),
        new Color32(56,105,196, 255),
        new Color32(100,100,174, 255),
        new Color32(80,57,117, 255),
        new Color32(109,72,170, 255),
        new Color32(128,100,174, 255),

        //gray - white
        new Color32(149,149,149, 255),
        new Color32(191,188,205, 255),
        new Color32(200,206,218, 255),
        new Color32(227,229,242, 255),
        new Color32(228,228,228, 255),
        new Color32(255,255,255, 255),


    };
    public Category currentCategory;

    public int skinColorID = 0;
    public int hairColorID = 0;
    public int pantsColorID = 0;
    public int shirtColorID = 0;
    public int shoesColorID = 0;
    public int hairStyle = 0;
    public Gender gender = Gender.MALE;

    public int pantsID = 0;
    public int shirtID = 0;
    public int shoesID = 0;



    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Cursor.SetCursor(cursor, Vector3.zero , CursorMode.ForceSoftware);

        texture = new Texture2D(64, 64, TextureFormat.ARGB32, false);
        textureCopy = new Texture2D(64, 64, TextureFormat.ARGB32, false);

        skinColorID = 21;
        hairColorID = 7;
        pantsColorID = 8;
        shirtColorID = 13;
        shoesColorID = 0;
        hairStyle = 0;
        hairMat.SetColor("_BaseColor", hairColors[hairColorID]);
        pantsID = 0;
        shirtID = 3;
        shoesID = 0;

        ApplyClothes();
        
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }

    }
    private void ApplyClothes(){
        texture = new Texture2D(64, 64, TextureFormat.RGBA32, false);
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Point;

        textureCopy = new Texture2D(64, 64, TextureFormat.RGBA32, false);
        textureCopy.wrapMode = TextureWrapMode.Clamp;
        textureCopy.filterMode = FilterMode.Point;


        //TODO merge to array
        Color[] result = texture.GetPixels();
        Color[] skinCol = skin.GetPixels();
        Color[] eyebrowCol = eyebrow.GetPixels();
        Color[] pantsCol = pants2[pantsID].GetPixels();
        Color[] shirtCol = shirt2[shirtID].GetPixels();
        Color[] shoesCol = shoes2[shoesID].GetPixels();



        for(int y = 0; y < texture.height; y++){
            for(int x = 0; x < texture.width; x++){

                int pixelIndex = x + (y * texture.width);
                Color currentPixelColor = skinCol[pixelIndex];
                
                //TODO iterate through array
                if(currentPixelColor.a > 0){
                    result[pixelIndex] = currentPixelColor;
                }
                currentPixelColor = eyebrowCol[pixelIndex];
                if(currentPixelColor.a > 0){
                    result[pixelIndex] = currentPixelColor;
                }
                currentPixelColor = pantsCol[pixelIndex];
                if(currentPixelColor.a > 0){
                    result[pixelIndex] = currentPixelColor;
                }
                currentPixelColor = shirtCol[pixelIndex];
                if(currentPixelColor.a > 0){
                    result[pixelIndex] = currentPixelColor;
                }
                currentPixelColor = shoesCol[pixelIndex];
                if(currentPixelColor.a > 0){
                    result[pixelIndex] = currentPixelColor;
                }

                //texture.SetPixel(x,y, skin.GetPixel(x,y));
                //texture.SetPixel(x,y, eyebrow.GetPixel(x,y));
                //texture.SetPixel(x,y, pants.GetPixel(x,y));
                //texture.SetPixel(x,y, shirt.GetPixel(x,y));
                //texture.SetPixel(x,y, shoes.GetPixel(x,y));
            }
        }
        texture.SetPixels(result);
        texture.Apply(false);
        
        textureCopy.SetPixels(result);
        textureCopy.Apply(false);
        
        Debug.Log("Applied Clothes!");
        ApplyColor();
    }

    private void ApplyHairStyle(){

        if(hairStyle == 0){
            GameObject.Destroy(currentHair);
            return;
        }

        switch(gender){
            case Gender.MALE:
            if(currentHair != null){
                Destroy(currentHair);
            }

            currentHair = Instantiate(hairMale[hairStyle]);
            currentHair.transform.SetParent(headAnchor); 
            currentHair.GetComponent<MeshRenderer>().material = hairMat;
            break;

            case Gender.FEMALE:
            if(currentHair != null){
                Destroy(currentHair);
            }

            currentHair = Instantiate(hairFemale[hairStyle]);
            currentHair.transform.SetParent(headAnchor); 
            currentHair.GetComponent<MeshRenderer>().material = hairMat;
            break;

            case Gender.DIVERSE:
            Debug.Log("Not implemented yet");
            break;

            default:
            Debug.Log("The gender is unknown.");
            break;
        }

        hairMat.SetColor("_BaseColor", hairColors[hairColorID]);
        Debug.Log("Applied Hairstyle!");
        
    }
    private void ApplyColor(){

        Color[] col = texture.GetPixels();
        
        
        for(int i = 0; i < col.Length; i++){
            if(((Color32)col[i]).Equals((Color32)skinKey)){
                col[i] = skinTones[skinColorID];
            }
            else if(((Color32)col[i]).Equals((Color32)hairKey)){
                col[i] = hairColors[hairColorID];
            }
            else if(((Color32)col[i]).Equals((Color32)pantsKey)){
                col[i] = colors[pantsColorID];
            }
            else if(((Color32)col[i]).Equals((Color32)shirtKey)){
                col[i] = colors[shirtColorID];
            }
            else if(((Color32)col[i]).Equals((Color32)shoesKey)){
                col[i] = colors[shoesColorID];
            }
        }

        textureCopy.SetPixels(col);
        textureCopy.Apply(false);
        mat.SetTexture("_BaseColorMap", textureCopy);   
        hairMat.SetColor("_BaseColor", hairColors[hairColorID]);

        Debug.Log("Applied Colors!");
    }
    private void randomColor(){
        skinColorID = Random.Range(0, skinTones.Length);
        hairColorID = Random.Range(0, hairColors.Length);
        pantsColorID = Random.Range(0, colors.Length);
        shirtColorID = Random.Range(0, colors.Length);
        shoesColorID = Random.Range(0, colors.Length);
        ApplyColor();
    }
    private void randomHair(){
        if(gender == Gender.MALE){
            hairStyle = Random.Range(0, hairMale.Length);
        }
        else if(gender == Gender.FEMALE){
            hairStyle = Random.Range(0, hairFemale.Length);
        }
        ApplyHairStyle();
    }
    private void randomClothes(){
        pantsID = Random.Range(0, pants2.Length);
        shirtID = Random.Range(0, shirt2.Length);
        shoesID = Random.Range(0, shoes2.Length);
        ApplyClothes();
    }
    private void randomGender(){
        //when diverse implemented change to 3
        int rnd = Random.Range(0, 2);

        if(rnd == 0){
            gender = Gender.MALE;
        }
        else{
            gender = Gender.FEMALE;
        }
    }

    public void randomCharacter(){
        randomGender();
        randomColor();
        randomHair();
        randomClothes();
    }

    public void incrementStyle(){
        switch (currentCategory){
            case Category.SKIN:
            break;

            case Category.HAIR:
                if((gender == Gender.MALE && hairStyle + 1 < hairMale.Length) 
                || (gender == Gender.FEMALE && hairStyle + 1 < hairFemale.Length)){
                    hairStyle++;
                    ApplyHairStyle();
                }
            break;

            case Category.SHIRT:
                if(shirtID + 1 < shirt2.Length){
                    shirtID++;
                    ApplyClothes();
                }
            break;

            case Category.PANTS:
                if(pantsID + 1 < pants2.Length){
                    pantsID++;
                    ApplyClothes();
                    }
            break;

            case Category.SHOES:
                if(shoesID + 1 < shoes2.Length){
                    shoesID++;
                    ApplyClothes();
                }
            break;

            default:
                Debug.Log("Could not find Category");
            break;
        }
    }

    public void decrementStyle(){
        switch (currentCategory){
            case Category.SKIN:
            break;

            case Category.HAIR:
                if(hairStyle - 1 >= 0){
                    hairStyle--;
                    ApplyHairStyle();
                }
            break;

            case Category.SHIRT:
                if(shirtID - 1 >= 0){
                    shirtID--;
                    ApplyClothes();
                }
            break;

            case Category.PANTS:
                if(pantsID - 1 >= 0){
                    pantsID--;
                    ApplyClothes();
                    }
            break;

            case Category.SHOES:
                if(shoesID - 1 >= 0){
                    shoesID--;
                    ApplyClothes();
                }
            break;

            default:
                Debug.Log("Could not find Category");
            break;
        }
    }
    
    public void incrementColor(){
        switch (currentCategory){
            case Category.SKIN:
                if(skinColorID + 1 < skinTones.Length){
                    skinColorID++;
                    ApplyColor();
                }
            break;

            case Category.HAIR:
                if(hairColorID + 1 < hairColors.Length){
                    hairColorID++;
                    ApplyColor();
                }
            break;

            case Category.SHIRT:
                if(shirtColorID + 1 < colors.Length){
                    shirtColorID++;
                    ApplyColor();
                }
            break;

            case Category.PANTS:
                if(pantsColorID + 1 < colors.Length){
                    pantsColorID++;
                    ApplyColor();
                }
            break;

            case Category.SHOES:
                if(shoesColorID + 1 < colors.Length){
                    shoesColorID++;
                    ApplyColor();
                }
            break;

            default:
                Debug.Log("Could not find Category");
            break;
        }
    }

    public void decrementColor(){
        switch (currentCategory){
            case Category.SKIN:
                if(skinColorID - 1 >= 0){
                    skinColorID--;
                    ApplyColor();
                }
            break;

            case Category.HAIR:
                if(hairColorID - 1 >= 0){
                    hairColorID--;
                    ApplyColor();
                }
            break;

            case Category.SHIRT:
                if(shirtColorID - 1 >= 0){
                    shirtColorID--;
                    ApplyColor();
                }
            break;

            case Category.PANTS:
                if(pantsColorID - 1 >= 0){
                    pantsColorID--;
                    ApplyColor();
                }
            break;

            case Category.SHOES:
                if(shoesColorID - 1 >= 0){
                    shoesColorID--;
                    ApplyColor();
                }
            break;

            default:
                Debug.Log("Could not find Category");
            break;
        }
    }
    public void setCategory(int cat){
        switch ((Category)cat){
            case Category.SKIN:
                currentCategory = Category.SKIN;
            break;

            case Category.HAIR:
                currentCategory = Category.HAIR;
            break;

            case Category.SHIRT:
                currentCategory = Category.SHIRT;
            break;

            case Category.PANTS:
                currentCategory = Category.PANTS;
            break;

            case Category.SHOES:
                currentCategory = Category.SHOES;
            break;

            default:
                Debug.Log("Could not find Category");
            break;
        }
    }
    public void setGender(int g){
        switch ((Gender)g){
            case Gender.MALE:
                gender = Gender.MALE;
                ApplyHairStyle();
            break;

            case Gender.FEMALE:
                gender = Gender.FEMALE;
                ApplyHairStyle();
            break;

            case Gender.DIVERSE:
                gender = Gender.DIVERSE;
                ApplyHairStyle();
            break;

            default:
                Debug.Log("Could not find Gender");
            break;
        }
    }
}
