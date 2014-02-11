#pragma strict

function Start () {

}

function Update () {

}
function OnParticleCollision (other : GameObject){
    var direction : Vector3 = transform.position - other.transform.position;
    rigidbody.AddForce (direction.normalized * 50);
}