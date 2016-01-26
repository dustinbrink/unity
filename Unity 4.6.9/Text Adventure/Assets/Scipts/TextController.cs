using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States { 
		cell, cell_mirror,
		sheets_0, sheets_1, 
		mirror, 
		lock_0, lock_1, 
		corridor_0, corridor_1, corridor_2, corridor_3,
		stairs_0, stairs_1, stairs_2,
		closet_door, closet_in,
		floor,
		courtyard
	};
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		// print ( myState );
		
		switch ( myState ) {
			case States.cell:			cell();			break;
			case States.cell_mirror:	cell_mirror();	break;
			case States.sheets_0:		sheets_0();		break;
			case States.sheets_1:		sheets_1 ();	break;
			case States.mirror:			mirror();		break;
			case States.lock_0:			lock_0();		break;
			case States.lock_1:			lock_1();		break;
			case States.corridor_0:		corridor_0();	break;
			case States.corridor_1:		corridor_1();	break;
			case States.corridor_2:		corridor_2();	break;
			case States.corridor_3:		corridor_3();	break;
			case States.stairs_0: 		stairs_0(); 	break;
			case States.stairs_1: 		stairs_1(); 	break;
			case States.stairs_2: 		stairs_2(); 	break;
			case States.closet_door:	closet_door();	break;
			case States.closet_in:		closet_in();	break;
			case States.floor:			floor();		break;
			case States.courtyard:		courtyard();	break;
		}
	}
	
	void cell() {
		text.text = "You are in a prison cell, and you want to escape. There are some dirty sheets on " +
					"the bed, a mirror on the wall, and the door is locked from the outside.\n\n" +
					"Press S to view Sheets, M to view Mirror, and L to view Lock";
					
		if 		( Input.GetKeyDown ( KeyCode.S ) )	{ myState = States.sheets_0; } 
		else if ( Input.GetKeyDown ( KeyCode.M ) )	{ myState = States.mirror; }
		else if ( Input.GetKeyDown ( KeyCode.L ) )	{ myState = States.lock_0; }
	}
	
	void sheets_0() {
		text.text = "You can't believe you sleep in these things. Surely it's time somebody changed them. " +
					"The pleasures of prison life, I guess!!\n\n" +
					"Press R to return to roaming your cell";
		
		if ( Input.GetKeyDown ( KeyCode.R ) )		{ myState = States.cell; } 
	}
	
	void mirror() {
		text.text = "The mirror is grimmy from years of neglect. You can barely make out your own refection. " +
					"You notice a crack in the bottom cornor of the mirror. With a little prying, you should " +
					"be able to remove a piece of the mirror.\n\n" +
					"Press T to Take mirror shard, R to return to roaming your cell";
		
		if 		( Input.GetKeyDown ( KeyCode.R ) )	{ myState = States.cell; } 
		else if ( Input.GetKeyDown ( KeyCode.T ) )	{ myState = States.cell_mirror; }
	}
	
	void lock_0() {
		text.text = "This is one of those button locks. You have no idea what the " +
					"combination is. You wish you could somehow see where the dirty " +
					"fingerprints were, maybe that would help.\n\n" +
					"Press R to Return to roaming your cell" ;;
		
		if 		( Input.GetKeyDown ( KeyCode.R ) )	{ myState = States.cell; } 
	}
	
	void cell_mirror() {
		text.text = "You return to your cell with the mirror chip in hand. What should you use it on?\n\n" +
					"To use the glass shard on Sheets press S, for Lock press L";
		
		if 		( Input.GetKeyDown ( KeyCode.S ) )	{ myState = States.sheets_1; } 
		else if ( Input.GetKeyDown ( KeyCode.L ) )	{ myState = States.lock_1; }
	}
	
	void sheets_1() {
		text.text = "You try cutting a ribbon of fabric from the sheets, but the glass shard isn't sharp enough. " +
					"It does little more than hurt your hand. Maybe you can use it on something else.\n\n" +
					"Press R to return to roaming your cell";
		
		if 		( Input.GetKeyDown ( KeyCode.R ) )	{ myState = States.cell_mirror; }
	}
	
	void lock_1() {
		text.text = "You carefully put the mirror through the bars, and turn it round " +
					"so you can see the lock. You can just make out fingerprints around " +
					"the buttons. You press the dirty buttons, and hear a click.\n\n" +
					"Press O to Open, or R to Return to your cell" ;
		
		if 		( Input.GetKeyDown( KeyCode.O ) )	{ myState = States.corridor_0; }
		else if ( Input.GetKeyDown( KeyCode.R ) )	{ myState = States.cell_mirror; }
	}
	
	void corridor_0() {
		text.text = "You're out of your cell, but not out of trouble." +
					"You are in the corridor, there's a closet and some stairs leading to " +
					"the courtyard. There's also various detritus on the floor.\n\n" +
					"C to view the Closet, F to inspect the Floor, and S to climb the stairs";
					
		if 		( Input.GetKeyDown( KeyCode.S ) )	{ myState = States.stairs_0; }
		else if ( Input.GetKeyDown( KeyCode.F ) )	{ myState = States.floor; }
		else if ( Input.GetKeyDown( KeyCode.C ) )	{ myState = States.closet_door; }
	}
	
	void corridor_1() {
		text.text = "Still in the corridor. Floor still dirty. Hairclip in hand. " +
					"Now what? You wonder if that lock on the closet would succumb to " +
					"to some lock-picking?\n\n" +
					"P to Pick the lock, and S to climb the stairs";
					
		if 		( Input.GetKeyDown( KeyCode.P ) )	{ myState = States.closet_in; }
		else if ( Input.GetKeyDown( KeyCode.S ) )	{ myState = States.stairs_1; }
	}
	
	void corridor_2() {
		text.text = "Back in the corridor, having declined to dress-up as a cleaner.\n\n" +
					"Press C to revisit the Closet, and S to climb the stairs";
					
		if 		( Input.GetKeyDown( KeyCode.C ) )	{ myState = States.closet_in; }
		else if ( Input.GetKeyDown( KeyCode.S ) )	{ myState = States.stairs_2; }
	}
	
	void corridor_3() {
		text.text = "You're standing back in the corridor, now convincingly dressed as a cleaner. " +
					"You strongly consider the run for freedom.\n\n" +
					"Press S to take the Stairs, or U to Undress";
					
		if 		( Input.GetKeyDown( KeyCode.S ) )	{ myState = States.courtyard; }
		else if ( Input.GetKeyDown( KeyCode.U ) )	{ myState = States.closet_in; }
	}
	
	void stairs_0() {
		text.text = "You start walking up the stairs towards the outside light. " +
					"You realise it's not break time, and you'll be caught immediately. " +
					"You slither back down the stairs and reconsider.\n\n" +
					"Press R to Return to the corridor." ;
					
		if 		( Input.GetKeyDown( KeyCode.R ) )	{ myState = States.corridor_0; }
	}
	
	void stairs_1() {
		text.text = "Unfortunately weilding a puny hairclip hasn't given you the " +
					"confidence to walk out into a courtyard surrounded by armed guards!\n\n" +
					"Press R to Retreat down the stairs" ;
					
		if 		( Input.GetKeyDown( KeyCode.R ) )	{ myState = States.corridor_1; }
	}
	
	void stairs_2() {
		text.text = "You feel smug for picking the closet door open, and are still armed with " +
					"a hairclip (now badly bent). Even these achievements together don't give " +
					"you the courage to climb up the staris to your death!\n\n" +
					"Press R to Return to the corridor";
					
		if 		( Input.GetKeyDown( KeyCode.R ) )	{ myState = States.corridor_2; }
	}
	
	void closet_door() {
		text.text = "You are looking at a closet door, unfortunately it's locked. " +
					"Maybe you could find something around to help enourage it open?\n\n" +
					"Press R to Return to the corridor";
					
		if 		( Input.GetKeyDown( KeyCode.R ) )	{ myState = States.corridor_0; }
	}
	
	void closet_in() {
		text.text = "Inside the closet you see a cleaner's uniform that looks about your size! " +
					"Seems like your day is looking-up.\n\n" +
					"Press D to Dress up, or R to Return to the corridor";
					
		if 		( Input.GetKeyDown( KeyCode.R ) )	{ myState = States.corridor_2; }
		else if ( Input.GetKeyDown( KeyCode.D ) )	{ myState = States.corridor_3; }
	}
	
	void floor() {
		text.text = "Rummagaing around on the dirty floor, you find a hairclip.\n\n" +
					"Press R to Return to the standing, or H to take the Hairclip." ;
					
		if 		( Input.GetKeyDown( KeyCode.R ) )	{ myState = States.corridor_0; }
		else if ( Input.GetKeyDown( KeyCode.H ) )	{ myState = States.corridor_1; }
	}
	
	void courtyard() {
		text.text = "You walk through the courtyard dressed as a cleaner. " +
					"The guard tips his hat at you as you waltz past, claiming " +
					"your freedom. You heart races as you walk into the sunset.\n\n" +
					"Press P to Play again." ;
					
		if 		( Input.GetKeyDown( KeyCode.P ) )	{ myState = States.cell; }
	}
}
