using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	public bool HasMirror, HasSheets, HasClip, HasOutfit;
	public int stairs;

	private enum States {
		cell_0, cell_1, cell_2, cell_3, mirror_0, mirror_1,
		sheets_0, sheets_1, sheets_2, lock_0, corridor_0, corridor_1,
		corridor_2, corridor_3, corridor_4, floor, closet_0, closet_1,
		stairs_0, stairs_1, stairs_2, caught, courtyard};
	private States myState;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		print (myState);
		if (myState == States.cell_0) 				{cell_0 ();}
		else if (myState == States.sheets_0) 		{sheets_0 ();}
		else if (myState == States.sheets_1) 		{sheets_1 ();}
		else if (myState == States.sheets_2) 		{sheets_2 ();}
		else if (myState == States.cell_1) 			{cell_1();}
		else if (myState == States.cell_2) 			{cell_2 ();}
		else if (myState == States.cell_3) 			{cell_3 ();}
		else if (myState == States.mirror_0) 		{mirror_0 ();}
		else if (myState == States.mirror_1) 		{mirror_1 ();}
		else if (myState == States.lock_0) 			{lock_0 ();}
		else if (myState == States.corridor_0) 		{corridor_0 ();}
 		else if (myState == States.corridor_1)		{corridor_1 ();}
		else if (myState == States.corridor_2)		{corridor_2 ();}
		else if (myState == States.corridor_3)		{corridor_3 ();}
		else if (myState == States.corridor_4)		{corridor_4 ();}
		else if (myState == States.floor)			{floor ();}
		else if (myState == States.closet_0)		{closet_0 ();}
		else if (myState == States.closet_1) 		{closet_1 ();}
		else if (myState == States.stairs_0)		{stairs_0 ();}
		else if (myState == States.stairs_1)		{stairs_1 ();}
		else if (myState == States.courtyard)		{courtyard ();}
		else if (myState == States.caught)			{caught ();}
	}

	void cell_0 () {
		HasSheets = false;
		HasMirror = false;
		HasClip = false;
		HasOutfit = false;
		stairs = 0;

		text.text = "Who are you? Unimportant.\n\n" +
					"You are in a locked prison cell. Forget why you're there " +
					"or what you did to deserve this, because the only " +
					"all-consuming thought in your head is how to escape, " +
					"how to obtain that which we all yearn for: Freedom.\n\n" +
					"There isn't much here. It is a prison cell after all. " +
					"There are standard-issue, coarse sheets on the bed, a small " +
					"and dingy mirror on the wall above the sink. The only other " +
					"item of note is, of course, the Lock on your cell.\n\n\n" +
					"Press S to examine the Sheets, M to examine the Mirror, " +
					"L to examine the Lock.";

		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.sheets_0;}
		else if (Input.GetKeyDown(KeyCode.M)) 	{myState = States.mirror_0;}
		else if (Input.GetKeyDown(KeyCode.L)) 	{myState = States.lock_0;}
	}

	void cell_1 () {
		text.text = "There still isn't much here. It is still a prison cell " +
					"after all. You've got standard-issue, sheets, and there's " +
					"a small and dingy mirror on the wall above the sink. " +
					"The only other item of note is, of course, the Lock on " +
					" your cell.\n\n" +
					"In short, you have the sheets but not the mirror.\n\n\n" +
					"Press M to examine the Mirror, L to examine the Lock.";

		if 		(Input.GetKeyDown(KeyCode.M)) 	{myState = States.mirror_0;}
		else if (Input.GetKeyDown(KeyCode.L)) 	{myState = States.lock_0;}
	}

	void cell_2 () {
		text.text = "There really isn't much here. You're STILL in prison. There " +
					"are still standard-issue, coarse sheets on the bed, and you're " +
					"holding the mirror in your hand.\n\n\n" +
					"Press L to look at the Lock, S to examine the Sheets.";

		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.sheets_0;}
		else if (Input.GetKeyDown(KeyCode.L))	{myState = States.lock_0;}
	}

	void cell_3 () {
		text.text = "There's absolutely nothing left. Nothing.\n\n" +
					"You have both the mirror and the sheets.\n\n\n" +
					"Press L to look at the Lock.";

		if 		(Input.GetKeyDown(KeyCode.L)) 	{myState = States.lock_0;}
	}

	void sheets_0 () {
		text.text = "The sheets are standard issue prison sheets. They're not " +
					"terribly soft or warm, but they're incredibly durable. You " +
					"don't see any holes in them, but you do notice a distinct " +
					"odor coming from them. It's reminiscent of how your dorm " +
					"room smelled before laundry day. The similarities between " +
					"prison and dorm-life are remarkable.\n\n\n" +
					"Press T to Take the sheets, press R to Return to roaming " +
					"your cell.";

		if (Input.GetKeyDown(KeyCode.T)) {
			HasSheets = true;
			myState = States.sheets_1;
		} else if (Input.GetKeyDown(KeyCode.R) && HasMirror == true) {
			myState = States.cell_2;
		} else if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell_0;}
	}

	void sheets_1 () {
		text.text = "You strip the bed of your sheets, deciding that it's best " +
					"to take them with you.\n\n" +
					"You hold them awkwardly in your hand.\n\n\n" +
					"Press R to Return to roaming your cell.";

		if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.cell_1;}
	}

	void sheets_2 () {

		if (HasMirror == false) {
			text.text = "You strip down until you're naked and drape the sheet " +
						"around yourself like a toga.\n\n" +
						"This strangely doesn't have any effect on the lock.\n\n\n" +
						"Press R to Return to roaming your cell.";

			if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell_1;}
		} else if (HasMirror == true) {
			text.text = "You strip down until you're naked and drape the sheet " +
						"around yourself like a toga.\n\n" +
						"This strangely doesn't have any effect on the lock.\n\n\n" +
						"Press M to use the Mirror or you can press R to Return to " +
						"roaming your cell.";

			if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell_3;}
			else if (Input.GetKeyDown(KeyCode.M)) 	{myState = States.corridor_0;}
		}
	}

	void mirror_0 () {
		text.text = "You see yourself in the mirror. You aren't terribly " +
					"impressed with what you see, especially considering you " +
					"wound up here in prison. The mirror itself isn't very well " +
					"attached to the wall. Years of abuse have taken their " +
					"toll on the frame keeping it in place.\n\n\n" +
					"Press T to Take the mirror, press R to Return to roaming " +
					"your cell.";

		if (Input.GetKeyDown(KeyCode.T)) {
			HasMirror = true;
			myState = States.mirror_1;
		} else if (Input.GetKeyDown(KeyCode.R) && HasSheets == true) {
			myState = States.cell_1;
		} else if (Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell_0;}
	}

	void mirror_1 () {
		text.text = "Trying to be quiet, you snatch the mirror off the wall.\n\n\n" +
					"Press R to Return to roaming your cell.";

		if (Input.GetKeyDown(KeyCode.R) && HasSheets == true) {
			myState = States.cell_3;
		} else if (Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell_2;}

	}

	void lock_0 () {
		if (HasSheets == false && HasMirror == false) {
			text.text = "You see that it's an aged keypad lock. If only " +
						"there were a way to see which keys are most often pressed.\n\n\n" +
						"Press R to Return to roaming your cell.";

			if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.cell_0;}
		}

			else if (HasSheets == true && HasMirror == true) {
			text.text = "You see that it's an aged keypad lock. If only " +
						"there were a way to see which keys are most often pressed.\n\n\n" +
						"Press M to use the Mirror, S to use the Sheets.\n\n" +
						"Or you can press R to Return to roaming your cell.";

			if 		(Input.GetKeyDown(KeyCode.M))	{myState = States.corridor_0;}
			else if (Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell_3;}
			else if (Input.GetKeyDown(KeyCode.S)) 	{myState = States.sheets_2;}
		}

			else if (HasSheets == true && HasMirror == false) {
			text.text = "You see that it's an aged keypad lock. If only " +
						"there were a way to see which keys are most often pressed.\n\n\n" +
						"Press S to use the Sheets, and R to Return to roaming " +
						"your cell";

			if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.sheets_2;}
			else if (Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell_1;}
		}

			else if (HasSheets == false && HasMirror == true) {
			text.text = "You see that it's an aged keypad lock. If only " +
						"there were a way to see which keys are most often pressed.\n\n\n" +
						"Press M to use the Mirror, and R to Return to roaming " +
						"your cell";

			if 		(Input.GetKeyDown(KeyCode.M)) 	{myState = States.corridor_0;}
			else if (Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell_2;}
		}
	}

	void corridor_0 () {
		text.text = "Checking to make sure no one is watching, you slip the mirror " +
					"through the bars and peek outside. Then you tilt the mirror so " +
					"you can see the keypad. Four of the numbers are very worn down " +
					"from use. A few minutes trying different combinations does the " +
					"trick!\n\n" +
					"The lock clangs open and you let yourself out.\n\n" +
					"You might not be totally free, but you're over the first hurdle.\n\n\n" +
					"Press E to head towards the exit.";

		if 		(Input.GetKeyDown(KeyCode.E)) 		{myState = States.corridor_1;}
	}

	void corridor_1 () {
		text.text = "You're in a narrow corridor.\n\n" +
					"In front of you is a staircase with an exit sign above it. " +
					"You don't know what awaits at the top, but you're sure it's " +
					"better than hanging around here waiting to get caught. " +
					"On your right there's a door that says Janitorial Closet on " +
					"it, and something shiny on the floor catches your eye.\n\n\n" +
					"Press S to head up the Stairs, C to open the Closet, F to " +
					"look at the Floor.";

		if 		(Input.GetKeyDown(KeyCode.S))		{myState = States.stairs_0;}
		else if (Input.GetKeyDown(KeyCode.C))		{myState = States.closet_0;}
		else if (Input.GetKeyDown(KeyCode.F))		{myState = States.floor;}
	}

	void corridor_2 () {
		text.text = "Clinging to your paperclip, you can either head up the " +
					"stairs or you can look at the closet.\n\n\n" +
					"Press S to take the stairs, C to try the closet.";

		if 		(Input.GetKeyDown(KeyCode.S))		{myState = States.stairs_1;}
		else if (Input.GetKeyDown(KeyCode.C))		{myState = States.closet_1;}
	}

	void corridor_3 () {
		text.text = "You're back in the hallway, and you've been here long " +
					"enough that it's making you nervous. The closet door is " +
					"open now, but other than that there's nowhere to go but " +
					"up the stairs or back into the closet.\n\n\n" +
					"Press S to go up the stairs, and C to reenter the closet.";

			if 		(Input.GetKeyDown(KeyCode.S))	{myState = States.stairs_1;}
			else if (Input.GetKeyDown(KeyCode.C))	{myState = States.closet_1;}
		}

	void corridor_4 () {
		text.text = "Wearing the janitor's outfit you exit the closet. " +
					"You're feeling confident though. As confident as a " +
					"person can while wearing another person's clothes " +
					"covered in nastiness anyway. But time is short. You " +
					"hear voices coming from the staircase.\n\n\n" +
					"Press S to take the stairs and try your luck, R to " +
					"Remain in the corridor and search for another exit.";

			if 		(Input.GetKeyDown(KeyCode.S))	{myState = States.courtyard;}
			else if (Input.GetKeyDown(KeyCode.R))	{myState = States.caught;}
	}

	void stairs_0 () {
		text.text = "As you head up the stairs you hear the voices of guards.\n\n\n" +
					"Press R to Return to the corridor or E to exit anyway.";

		if 		(Input.GetKeyDown(KeyCode.R)) 		{myState = States.corridor_1;}
		else if (Input.GetKeyDown(KeyCode.E))		{myState = States.caught;}
	}

	void stairs_1 () {
		text.text = "As you reach the top of the stairs you hear the guards " +
					"discussing who should make the next set of rounds. " +
					"You quickly make your way back down to the corridor " +
					"knowing you only have a minute before they'll come down " +
					"and find you out of your cell.\n\n\n" +
					"Press R to Return to the corridor, E to exit anyway.";

		if 		(Input.GetKeyDown(KeyCode.R)) 		{myState = States.corridor_2;}
		else if (Input.GetKeyDown(KeyCode.E))		{myState = States.caught;}
	}

	void floor () {
		text.text = "On the floor you find a Paperclip.\n\n\n" +
					"Press P to pick it up, or R to Return to the corridor.";

		if (Input.GetKeyDown(KeyCode.P)) {
			HasClip = true;
			myState = States.corridor_2;
		} else if (Input.GetKeyDown(KeyCode.R))		{myState = States.corridor_1;}
	}

	void closet_0 () {
		if (HasClip == true) {
			text.text = "The door to the closet is locked, but with your " +
						"paperclip you manage to pick the lock and open the " +
						"door.\n\n\n" +
						"Press R to Return to the corridor, C to enter the " +
						"Closet.";
			if 		(Input.GetKeyDown(KeyCode.C))	{myState = States.closet_1;}
			else if (Input.GetKeyDown(KeyCode.R))	{myState = States.corridor_1;}
		} else {
			text.text = "The door to the closet is locked. Try as you might " +
						"and no matter how hard you try it won't budge.\n\n\n" +
						"Press R to Return to the corridor.";

			if 		(Input.GetKeyDown(KeyCode.R))	{myState = States.corridor_1;}
		}
	}

	void closet_1 () {
		text.text = "This is a very sparse closet. There's a dirty janitor's " +
					"outfit hanging here, but nothing else.\n\n\n" +
					"Press O to put on the Outfit, or R to Return to the corridor.";

		if (Input.GetKeyDown(KeyCode.O)) {
			HasOutfit = true;
			myState = States.corridor_4;
		} else if (Input.GetKeyDown(KeyCode.R))		{myState = States.corridor_3;}
	}

	void caught () {
		if (HasSheets == false) {
			text.text = "The guards catch you hanging around and you're thrown " +
						"into solitary. There's no escaping now.\n\n\n" +
						"Press P to Play again.";

		if (Input.GetKeyDown(KeyCode.P))			{myState = States.cell_0;}
		} else if (HasSheets == true) {
			text.text = "You come up the stairs, toga-wrapped in your sheets, " +
						"and the guards laugh at you before throwing you back " +
						"in your cell.\n\n\n" +
						"Press P to Play again.";

			if (Input.GetKeyDown(KeyCode.P))			{myState = States.cell_0;}
		}

	}

	void courtyard () {
		text.text = "Your janitor's costume fools the guards and you exit " +
					"the building as casually as possible (which isn't all that " +
					"casual considering you're in the process of escaping). " +
					"You just so happen to be in one of those rare prisons " +
					"with no outer fence so ... Good News!\n\n" +
					"You're free!\n\n" +
					"Change your life though, stay out of prison moving forward.\n\n\n" +
					"Press P to Play again.";

		if (Input.GetKeyDown(KeyCode.P))			{myState = States.cell_0;}
	}
}
