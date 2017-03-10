#pragma strict
 
@script RequireComponent (LineRenderer)
 
var mouse : Vector2;
var hit : RaycastHit;
var range : float = 100.0;
var line : LineRenderer;
var lineMaterial : Material;
var ray : Ray;
var HitThick : float = 0.2;
 
function Start()
{
    line = GetComponent(LineRenderer);
    line.SetVertexCount(2);
    line.renderer.material = lineMaterial;
    line.SetWidth(0.1f, HitThick);
}
 
function Update()
{
    if(Input.GetMouseButton(0))
    {
        line.enabled = true;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var pos : Vector3;
        if(Physics.Raycast(ray, hit, range))
        {
            pos = hit.point;
        }
        else
        {
           pos = Input.mousePosition;
           pos.z = -Camera.main.transform.position.z;
           pos = Camera.main.ScreenToWorldPoint(pos);
        }
 
       line.SetPosition(0, transform.position);
       pos.z = 0.0;
       line.SetPosition(1, pos );
    }
    else
    {
    line.enabled = false;
    }
}