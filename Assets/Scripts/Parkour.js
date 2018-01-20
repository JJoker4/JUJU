#pragma strict

var ClimbMax : float;
var VaultMax : float;
var VaultMin : float;
var distanceToGoFwd : float = 0.7;
private var CanVault : boolean;
private var CanClimb : boolean;
private var DistancePlRayFwd : float;
private var DistancePlRayUp : float;
var VaultAnim : String;
var ClimbAnim : String;
var cam : GameObject;
private var Player : Transform;
var Arms : GameObject;
var VaultArms : String;
private var charCont : CharacterController;
private var CanParkour : boolean;
var EnableRoll : boolean;
var lastPos : float;
var Roll : String;
var RollArms : String;
var HeightToRoll : float = 25;
private var canRoll : boolean;
var distanceDamage : float = 55;
var maxFall : float;
private var max : float;
var CheckRay : GameObject;
var range : float;
private var maxH : float;
var Translate : boolean;

function Start()
{
Player = transform.parent.gameObject.transform;
charCont = Player.GetComponent(CharacterController);
}

function Update () 
{
if(CanParkour || charCont.isGrounded == false)
Translate  = true;
else
Translate = false;
maxH = Mathf.Abs(max - Player.transform.position.y + charCont.height/2);
Debug.Log(maxH);
var charContr : CharacterController = Player.GetComponent(CharacterController);
var radius = charCont.radius;
// find centers of the top/bottom hemispheres
var p1 : Vector3 = transform.position + charCont.center;
var p2 = p1;
p2.y += VaultMax;
p1.y -= charCont.height/2 + 0.02;
if (Physics.CapsuleCast(p1, p2, radius, transform.forward, range))
{
if(!Physics.Raycast(transform.position, transform.TransformDirection (Vector3.forward), 0.7))
	{
	if(!CanParkour)
	{
	if(Input.GetKeyDown(KeyCode.V))
	{
				Player.transform.position.y = CheckRay.transform.position.y + charCont.height + 0.1;
				Player.transform.Translate(0, 0, distanceToGoFwd + 0.3);
				cam.GetComponent.<Animation>().Play(VaultAnim);
				//Arms.animation.Play(VaultArms);
				}
}
}
if(Physics.Raycast(CheckRay.transform.position, transform.TransformDirection (Vector3.forward), 0.7))
{
CheckRay.transform.Translate(0, 8 * Time.deltaTime, 0);
max = Mathf.Max(max, CheckRay.transform.position.y);
}
if(maxH < ClimbMax)
{
Changing();
}
else
CanParkour = false;
if(maxH >= VaultMax)
{
CanVault = false;
CanClimb = true;
}
else
{
CanVault = true;
CanClimb = false;
}
}
else
{
CanParkour = false;
max = 0;
CheckRay.transform.position = Vector3(CheckRay.transform.position.x, Player.transform.position.y, CheckRay.transform.position.z);
}
if(CanParkour)
{
		if(CanVault == true)
		{
			if(Input.GetKeyDown(KeyCode.V))
			{
			Vault();
			}
	}
		if(CanClimb == true)
		{
			if(Input.GetKeyDown(KeyCode.V))
			{
			Climb();
			}
			}
			}
			if(EnableRoll)
			{
		if(!charCont.isGrounded)
		maxFall = Mathf.Max(Mathf.Abs(charCont.transform.position.y), maxFall);
		else
		lastPos = charCont.transform.position.y;
	if(charCont.isGrounded) {
        if(maxFall - lastPos > HeightToRoll){
		cam.GetComponent.<Animation>().Play(Roll);
		//Arms.animation.Play(RollArms);
		if(maxFall - lastPos > distanceDamage)
		{
		Player.transform.SendMessageUpwards("GetBulletDamage", maxFall + distanceDamage*2, SendMessageOptions.DontRequireReceiver);
		}
		maxFall = 0;
		}
		}
		}
		}
	
	function Vault()
{
var upDist = CheckRay.transform.position.y + 0.2f;
var fwdDist = distanceToGoFwd;
cam.GetComponent.<Animation>().CrossFade(VaultAnim);
var endPos : Vector3 = Vector3(Player.transform.position.x, upDist, fwdDist);
Player.transform.position = Vector3.MoveTowards(Player.transform.position, endPos, 5 * Time.deltaTime);
yield WaitForSeconds(distanceToGoFwd);
Translate = false;
}

	function Climb()
{
Player.transform.position.y = CheckRay.transform.position.y + charCont.height + 0.1;
Player.transform.Translate(0, 0, distanceToGoFwd + 0.3);
cam.GetComponent.<Animation>().CrossFade(ClimbAnim);
Translate = false;
}

function Changing()
{
yield WaitForSeconds(0.3f);
CanParkour = true;
}
 
