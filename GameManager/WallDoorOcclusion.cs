using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDoorOcclusion : MonoBehaviour
{
    private Transform player;
    private Material[] mats;
    private MeshRenderer MeshRend;
    private bool transparent = false;

    public Material Pri;
    public Material Sec;
    public Material Acc;

    //public Material PriTrans;
    //public Material SecTrans;
    //public Material AccTrans;

    private Colors colorPallete;

    private Emotion currentEmotion;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        colorPallete = Camera.main.GetComponent<Colors>();
        MeshRend = gameObject.GetComponent<MeshRenderer>();
        mats = MeshRend.materials;
        currentEmotion = Emotion.Angry;
        if(player.position.z > gameObject.transform.position.z)
        {
            transparent = !transparent;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(player.gameObject.GetComponent<PlayerControls>().feeling != currentEmotion)
        {
            ColorSelect(colorPallete.emotion);

            for(int i = 0; i < mats.Length; i++)
            {
                switch (mats[i].name)
                {
                    case "Primary (Instance)":
                        mats[i].color = Pri.color;
                        break;
                    case "Secondary (Instance)":
                        mats[i].color = Sec.color;
                        break;
                    case "Accent (Instance)":
                        mats[i].color = Acc.color;
                        break;
                }
            }
            currentEmotion = player.gameObject.GetComponent<PlayerControls>().feeling;
            transparent = !transparent;
        }

        if(player.position.z > gameObject.transform.position.z)
        {
            if (!transparent)
            {
                for (int i = 0; i < mats.Length; i++)
                {
                    RuntimeShaderChange.ChangeRenderMode(mats[i], RuntimeShaderChange.BlendMode.Transparent);
                    mats[i].color = new Color(mats[i].color.r, mats[i].color.g, mats[i].color.b, 0.5f);
                    //switch (mats[i].name)
                    //{
                    //    case "Primary (Instance)":
                    //        mats[i] = PriTrans;
                    //        break;
                    //    case "Secondary":
                    //        mats[i] = SecTrans;
                    //        break;
                    //    case "Accent":
                    //        mats[i] = AccTrans;
                    //        break;
                    //}
                }
                transparent = true;
            }
        }
        else
        {
            if (transparent)
            {
                for (int i = 0; i < mats.Length; i++)
                {
                    RuntimeShaderChange.ChangeRenderMode(mats[i], RuntimeShaderChange.BlendMode.Opaque);
                    mats[i].color = new Color(mats[i].color.r, mats[i].color.g, mats[i].color.b, 1);
                    //switch (mats[i].name)
                    //{
                    //    case "PrimaryTrans":
                    //        mats[i] = Pri;
                    //        break;
                    //    case "SecondaryTrans":
                    //        mats[i] = Sec;
                    //        break;
                    //    case "AccentTrans":
                    //        mats[i] = Acc;
                    //        break;
                    //}
                }
                transparent = false;
            }
        }
    }

    public void ColorSelect(Emotion a)
    {
        switch (a)
        {
            case Emotion.Neutral:
                Pri.color = colorPallete.Neutral[0];
                Sec.color = colorPallete.Neutral[1];
                Acc.color = colorPallete.Neutral[2];
                break;
            case Emotion.Angry:
                Pri.color = colorPallete.Angry[0];
                Sec.color = colorPallete.Angry[1];
                Acc.color = colorPallete.Angry[2];
                break;
            case Emotion.Happy:
                Pri.color = colorPallete.Happy[0];
                Sec.color = colorPallete.Happy[1];
                Acc.color = colorPallete.Happy[2];
                break;
            case Emotion.Sad:
                Pri.color = colorPallete.Sad[0];
                Sec.color = colorPallete.Sad[1];
                Acc.color = colorPallete.Sad[2];
                break;
            case Emotion.Scared:
                Pri.color = colorPallete.Scared[0];
                Sec.color = colorPallete.Scared[1];
                Acc.color = colorPallete.Scared[2];
                break;
        }
    }
}
