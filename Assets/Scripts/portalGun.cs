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
    public GameObject portalO;
    public GameObject portalB;


    // Use this for initialization
    void Start () {
        lineRenderer = GetComponent<LineRenderer> ();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));

        portalO = Instantiate(portalO);
        portalB = Instantiate(portalB);
        portalO.transform.position = new Vector3(-13, -11, 0);
        portalB.transform.position = new Vector3(-14, -11, 0);
        portalO.SetActive(false);
        portalB.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        RaycastHit2D hit = Physics2D.Raycast(end.position, dir);
        //Debug.DrawLine(end.position, hit.point);
        laserHit.position = hit.point;
        lineRenderer.SetPosition(0, end.position);
        lineRenderer.SetPosition(1, laserHit.position);

        if (Input.GetMouseButtonDown(1)) {

            portalO.SetActive(false);

            if (!shot)
            {
                spriteRenderer.sprite = gunO;
                lineRenderer.startColor = new Color(0.62745098039215686274509803921569f, 0.28235294117647058823529411764706f, 0.06274509803921568627450980392157f, 1);
                lineRenderer.endColor = new Color(0.62745098039215686274509803921569f, 0.28235294117647058823529411764706f, 0.06274509803921568627450980392157f, 1);

                lineRenderer.enabled = true;
                shot = true;

                portalO.transform.position = hit.point;
                portalO.transform.rotation = Quaternion.FromToRotation(Vector3.right, hit.normal);
                portalO.SetActive(true);
                portalO.GetComponent<Collider2D>().enabled = true;



            }
        }
        if (Input.GetMouseButtonUp(1)){
            shot = false;
            lineRenderer.enabled = false;
            spriteRenderer.sprite = gun;
        }
        if (Input.GetMouseButtonDown(0))
        {
            portalB.SetActive(false);
            if (!shot)
            {
                spriteRenderer.sprite = gunB;
                lineRenderer.startColor = new Color(0f, 0.14509803921568627450980392156863f, 0.29019607843137254901960784313725f, 1);
                lineRenderer.endColor = new Color(0f, 0.14509803921568627450980392156863f, 0.29019607843137254901960784313725f, 1);

                lineRenderer.enabled = true;
                shot = true;

                portalB.transform.position = hit.point;
                portalB.transform.rotation = Quaternion.FromToRotation(Vector3.right, hit.normal);
                portalB.SetActive(true);
                portalB.GetComponent<Collider2D>().enabled = true;

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
