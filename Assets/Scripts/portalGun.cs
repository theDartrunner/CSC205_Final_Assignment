using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalGun : MonoBehaviour {

    private LineRenderer lineRenderer;
    public Transform laserHit;
    public Transform end;
    private SpriteRenderer spriteRenderer;
    public Sprite gun;
    public Sprite gunO;
    public Sprite gunB;
    public bool shot;

	// Use this for initialization
	void Start () {
        lineRenderer = GetComponent<LineRenderer> ();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
    }
	
	// Update is called once per frame
	void Update () {

        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;

        RaycastHit2D hit = Physics2D.Raycast(end.position, dir);
        //Debug.DrawLine(end.position, hit.point);
        laserHit.position = hit.point;
        lineRenderer.SetPosition(0, end.position);
        lineRenderer.SetPosition(1, laserHit.position);

        if (Input.GetMouseButtonDown(1)) {

            if (!shot)
            {
                spriteRenderer.sprite = gunO;
                lineRenderer.startColor = new Color(0.62745098039215686274509803921569f, 0.28235294117647058823529411764706f, 0.06274509803921568627450980392157f, 1);
                lineRenderer.endColor = new Color(0.62745098039215686274509803921569f, 0.28235294117647058823529411764706f, 0.06274509803921568627450980392157f, 1);


                lineRenderer.enabled = true;
                shot = true;
            }
        }
        if (Input.GetMouseButtonUp(1)){
            shot = false;
            lineRenderer.enabled = false;
            spriteRenderer.sprite = gun;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (!shot)
            {
                spriteRenderer.sprite = gunB;
                lineRenderer.startColor = new Color(0f, 0.14509803921568627450980392156863f, 0.29019607843137254901960784313725f, 1);
                lineRenderer.endColor = new Color(0f, 0.14509803921568627450980392156863f, 0.29019607843137254901960784313725f, 1);

                lineRenderer.enabled = true;
                shot = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            shot = false;
            spriteRenderer.sprite = gun;
            lineRenderer.enabled = false;
        }



    }
}
