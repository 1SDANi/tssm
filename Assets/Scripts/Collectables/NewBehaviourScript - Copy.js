var other : GameObject;
function Update(){
other.GetComponent.<Renderer>().material.color.a = 0.5; // 50 % transparent
//other.GetComponent.<Renderer>().material.color.a = 1.0; // fully opaque
}