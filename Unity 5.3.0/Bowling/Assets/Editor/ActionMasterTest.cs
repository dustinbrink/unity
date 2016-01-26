using System.Linq;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest {
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;

	[Test]
	public void T01OneStrikeEndTurn () {
		int[] pins = { 10 };
		Assert.AreEqual( endTurn, ActionMaster.NextAction( pins.ToList() ) );
	}

	[Test]
	public void T02Bowl8Tidy () {
		int[] pins = { 8 };
		Assert.AreEqual( tidy, ActionMaster.NextAction( pins.ToList() ) );
	}

	[Test]
	public void T03Bowl28SpareEndTurn () {
		int[] pins = { 2,8 };
		Assert.AreEqual( endTurn, ActionMaster.NextAction( pins.ToList() ) );
	}

	[Test] // Never get a spare or strike, then you get 20 bowls.
	public void T04DoneOnTwenty () { 
		int[] pins = { 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2,  2,2 };
		Assert.AreEqual( endGame, ActionMaster.NextAction( pins.ToList() ) );
	}

	[Test]
	public void T05Frame10Ball1StrikeReset () {
		int[] pins = { 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2,  10 };
		Assert.AreEqual( reset, ActionMaster.NextAction( pins.ToList() ) ); // One more turn.
	}

	[Test] // Only return tidy if last two bowls are strikes.
	public void T06Frame10Ball2StrikeReset () {
		int[] pins = { 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2,  10,10 };
		Assert.AreEqual( reset, ActionMaster.NextAction( pins.ToList() ) ); // One more turn.
	}

	[Test] // Make sure game ends when all 12 strikes.
	public void T07Frame10Ball3StrikeEndsGame () {
		int[] pins = { 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2,  10,10,10 };
		Assert.AreEqual( endGame, ActionMaster.NextAction( pins.ToList() ) ); // One more turn.
	}

	[Test]
	public void T08Frame10SpareReset () {
		int[] pins = { 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2,  7,3 };
		Assert.AreEqual( reset, ActionMaster.NextAction( pins.ToList() ) ); // One more turn.
	}


	[Test] // Need to test for end game when no spare or strike at end.
	public void T09Frame10NoSpareEndGame () {
		int[] pins = { 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2,  7,2 };
		Assert.AreEqual( endGame, ActionMaster.NextAction( pins.ToList() ) ); // One more turn.
	}

	[Test] // Need to test for end game strike then gutter
	public void T10Bowl19StrikeThenMissTidy () {
		int[] pins = { 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2,  10,0 };
		Assert.AreEqual( tidy, ActionMaster.NextAction( pins.ToList() ) ); // One more turn.
	}

	[Test] // Need to test for end game strike then pins hit
	public void T11Bowl19StrikeThen2Tidy () {
		int[] pins = { 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2,  10, 2 };
		Assert.AreEqual( tidy, ActionMaster.NextAction( pins.ToList() ) ); // One more turn.
	}

	[Test] // Need to test for end game all gutters
	public void T12Bowl19GutterTidy () {
		int[] pins = { 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2,  0 };
		Assert.AreEqual( tidy, ActionMaster.NextAction( pins.ToList() ) ); // One more turn.
	}

	[Test] // Need to test for end game all gutters
	public void T13Bowl20GutterEndGame () {
		int[] pins = { 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2,  0, 0 };
		Assert.AreEqual( endGame, ActionMaster.NextAction( pins.ToList() ) ); // One more turn.
	}

	[Test]
	public void T14ZeroOneEndTurn () {
		int[] pins = { 0, 1 };
		Assert.AreEqual( endTurn, ActionMaster.NextAction( pins.ToList() ) );
	}

	[Test]
	public void T15StrikeGutterTidy () {
		int[] pins = { 10, 0 };
		Assert.AreEqual( tidy, ActionMaster.NextAction( pins.ToList() ) );
	}

	[Test]
	public void T16Strike6Tidy () {
		int[] pins = { 10, 6 };
		Assert.AreEqual( tidy, ActionMaster.NextAction( pins.ToList() ) );
	}

	[Test]
	public void T17PerfectGameEndGame () {
		int[] pins = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
		Assert.AreEqual( endGame, ActionMaster.NextAction( pins.ToList() ) );
	}

	[Test]
	public void F01Empty () {
		int[] pins = { };
		Assert.AreEqual( 0, ActionMaster.CountFrames( pins.ToList() ) );
	}

	[Test]
	public void F02Strike () {
		int[] pins = { 10 };
		Assert.AreEqual( 1, ActionMaster.CountFrames( pins.ToList() ) );
	}

	[Test]
	public void F03Strike2 () {
		int[] pins = { 10, 10 };
		Assert.AreEqual( 2, ActionMaster.CountFrames( pins.ToList() ) );
	}

	[Test]
	public void F04OneRoll () {
		int[] pins = { 1 };
		Assert.AreEqual( 1, ActionMaster.CountFrames( pins.ToList() ) );
	}

	[Test]
	public void F05TwoRolls () {
		int[] pins = { 1,1 };
		Assert.AreEqual( 1, ActionMaster.CountFrames( pins.ToList() ) );
	}

	[Test]
	public void F06ThreeRolls () {
		int[] pins = { 1, 1, 1 };
		Assert.AreEqual( 2, ActionMaster.CountFrames( pins.ToList() ) );
	}

	[Test]
	public void F07Spare () {
		int[] pins = { 1, 9 };
		Assert.AreEqual( 1, ActionMaster.CountFrames( pins.ToList() ) );
	}

	[Test]
	public void F08SpareOne () {
		int[] pins = { 1, 9, 1 };
		Assert.AreEqual( 2, ActionMaster.CountFrames( pins.ToList() ) );
	}

	[Test]
	public void F09FiveRolls () {
		int[] pins = { 1, 2, 3, 4, 5 };
		Assert.AreEqual( 3, ActionMaster.CountFrames( pins.ToList() ) );
	}

	[Test]
	public void F10TripleStrike () {
		int[] pins = { 10, 10, 10 };
		Assert.AreEqual( 3, ActionMaster.CountFrames( pins.ToList() ) );
	}

	[Test]
	public void F10Frame12 () {
		int[] pins = { 10, 10, 10 };
		Assert.AreEqual( 3, ActionMaster.CountFrames( pins.ToList() ) );
	}

	[Test] 
	public void F11DoneOnTwenty () {
		int[] pins = { 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2, 2,2 };
		Assert.AreEqual( 10, ActionMaster.CountFrames( pins.ToList() ) );
	}

	[Test]
	public void F12Frame10Ball1StrikeReset () {
		int[] pins = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 10 };
		Assert.AreEqual( 10, ActionMaster.CountFrames( pins.ToList() ) ); // One more turn.
	}

	[Test] // Only return tidy if last two bowls are strikes.
	public void F13Frame10Ball2StrikeReset () {
		int[] pins = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 10, 10 };
		Assert.AreEqual( 10, ActionMaster.CountFrames( pins.ToList() ) ); // One more turn.
	}

	[Test] // Make sure game ends when all 12 strikes.
	public void F14Frame10Ball3StrikeEndsGame () {
		int[] pins = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 10, 10, 10 };
		Assert.AreEqual( 10, ActionMaster.CountFrames( pins.ToList() ) ); // One more turn.
	}

	[Test]
	public void F15Frame10SpareReset () {
		int[] pins = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 7, 3 };
		Assert.AreEqual( 10, ActionMaster.CountFrames( pins.ToList() ) ); // One more turn.
	}


	[Test] // Need to test for end game when no spare or strike at end.
	public void F16Frame10NoSpareEndGame () {
		int[] pins = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 7, 2 };
		Assert.AreEqual( 10, ActionMaster.CountFrames( pins.ToList() ) ); // One more turn.
	}

	[Test] // Need to test for end game strike then gutter
	public void F17Bowl19StrikeThenMissTidy () {
		int[] pins = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 10, 0 };
		Assert.AreEqual( 10, ActionMaster.CountFrames( pins.ToList() ) ); // One more turn.
	}

	[Test] // Need to test for end game strike then pins hit
	public void F18Bowl19StrikeThen2Tidy () {
		int[] pins = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 10, 2 };
		Assert.AreEqual( 10, ActionMaster.CountFrames( pins.ToList() ) ); // One more turn.
	}

	[Test] // Need to test for end game all gutters
	public void F19Bowl19GutterTidy () {
		int[] pins = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0 };
		Assert.AreEqual( 10, ActionMaster.CountFrames( pins.ToList() ) ); // One more turn.
	}

	[Test] // Need to test for end game all gutters
	public void F20Bowl20GutterEndGame () {
		int[] pins = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0 };
		Assert.AreEqual( 10, ActionMaster.CountFrames( pins.ToList() ) ); // One more turn.
	}
}
