var other : GameObject;
var trans = 0.0;
var istrans = true;
function Update(){
if(istrans==true){other.GetComponent.<Renderer>().material.color.a = trans;} // 50 % transparent
if(istrans==false){other.GetComponent.<Renderer>().material.color.a = 1;} // fully opaque
}