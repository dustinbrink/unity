using System.Linq;
using NUnit.Framework;

[TestFixture]
public class ScoreMasterTest {

	[Test]
	public void ST00Vowl23 () {
		int[] pins = { 2, 3 };
		Assert.AreEqual( 5, ScoreMaster.ScoreCumulative( pins.ToList() )[ 0 ] );
	}

	[Test]
	public void ST01Bowl43 () {
		int[] pins = { 4, 3 };
		Assert.AreEqual( 7, ScoreMaster.ScoreCumulative( pins.ToList() )[ 0 ] );
	}

	[Test]
	public void ST02Strike73 () {
		int[] pins = { 10, 7, 3 };
		Assert.AreEqual( 20, ScoreMaster.ScoreCumulative( pins.ToList() )[ 0 ] );
	}

	[Test]
	public void ST03Spare7 () {
		int[] pins = { 6, 4, 7 };
		Assert.AreEqual( 17, ScoreMaster.ScoreCumulative( pins.ToList() )[ 0 ] );
	}

	[Test]
	public void ST04Turkey () {
		int[] pins = { 10, 10, 10 };
		Assert.AreEqual( 30, ScoreMaster.ScoreCumulative( pins.ToList() )[ 0 ] );
	}

	[Test] // bowls: X,X,7,3,2 scores: 27, 47, 59,
	public void ST05BowlXX732 () {
		int[] pins = { 10, 10, 7, 3, 2 };
		Assert.AreEqual( 27, ScoreMaster.ScoreCumulative( pins.ToList() )[ 0 ] );
	}

	[Test]
	public void ST06BowlXX732 () {
		int[] pins = { 10, 10, 7, 3, 2 };
		Assert.AreEqual( 47, ScoreMaster.ScoreCumulative( pins.ToList() )[ 1 ] );
	}

	[Test]
	public void ST07BowlXX732 () {
		int[] pins = { 10, 10, 7, 3, 2 };
		Assert.AreEqual( 59, ScoreMaster.ScoreCumulative( pins.ToList() )[ 2 ] );
	}

	[Test] // bowls: 3,0,X,9,1,2,1 frame scores: 3, 23, 35, 38
	public void ST08Bowl30X9121 () {
		int[] pins = { 3, 0, 10, 9, 1, 2, 1 };
		Assert.AreEqual( 23, ScoreMaster.ScoreCumulative( pins.ToList() )[ 1 ] );
	}

	[Test]
	public void ST09Bowl30X9121 () {
		int[] pins = { 3, 0, 10, 9, 1, 2, 1 };
		Assert.AreEqual( 35, ScoreMaster.ScoreCumulative( pins.ToList() )[ 2 ] );
	}

	[Test]
	public void ST10Bowl30X9121 () {
		int[] pins = { 3, 0, 10, 9, 1, 2, 1 };
		Assert.AreEqual( 38, ScoreMaster.ScoreCumulative( pins.ToList() )[ 3 ] );
	}

	[Test] // 300
	public void ST11PerfectGameScore () {
		int[] pins = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
		Assert.AreEqual( 300, ScoreMaster.ScoreCumulative( pins.ToList() )[ 9 ] );
	}

	// Test Format Scores

	[Test]
	public void FS00Empty () {
		int[] pins = { };
		string scores = "";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS01Bowl1 () {
		int[] pins = { 1 };
		string scores = "1";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS02Bowl12 () {
		int[] pins = { 1,2 };
		string scores = "12";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS03BowlGutter () {
		int[] pins = { 0 };
		string scores = "-";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS04Strike () {
		int[] pins = { 10 };
		string scores = " X";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS05Spare () {
		int[] pins = { 1, 9 };
		string scores = "1/";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS06Strike5 () {
		int[] pins = { 10, 5 };
		string scores = " X5";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS07Spare5 () {
		int[] pins = { 1, 9, 5 };
		string scores = "1/5";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS08StrikeStrike () {
		int[] pins = { 10, 10 };
		string scores = " X X";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS09StrikeStrikeStrike () {
		int[] pins = { 10, 10, 10 };
		string scores = " X X X";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS10StrikeSpare () {
		int[] pins = { 10, 5, 5 };
		string scores = " X5/";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS11SpareStrike () {
		int[] pins = { 5, 5, 10 };
		string scores = "5/ X";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS12StrikeGutter () {
		int[] pins = { 10, 0 };
		string scores = " X-";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS13StrikeGutterSpare () {
		int[] pins = { 10, 0, 10 };
		string scores = " X-/";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS14LastFrameStrike () {
		int[] pins = { 1,0, 1,0, 1,0, 1,0, 1,0, 1,0, 1,0, 1,0, 1,0, 10 };
		string scores = "1-1-1-1-1-1-1-1-1-X";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS15LastFrameStrikeStrike () {
		int[] pins = { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 10, 10 };
		string scores = "1-1-1-1-1-1-1-1-1-XX";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS16LastFrameTurkey () {
		int[] pins = { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 10, 10, 10 };
		string scores = "1-1-1-1-1-1-1-1-1-XXX";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS17LastFrame () {
		int[] pins = { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
		string scores = "1-1-1-1-1-1-1-1-1-11";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS19LastFrameSpare () {
		int[] pins = { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 9 };
		string scores = "1-1-1-1-1-1-1-1-1-1/";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS20LastFrameSpareStrike () {
		int[] pins = { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 9, 10 };
		string scores = "1-1-1-1-1-1-1-1-1-1/X";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS21LastFrameSpareGutter () {
		int[] pins = { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 9, 0 };
		string scores = "1-1-1-1-1-1-1-1-1-1/-";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}
	[Test]
	public void FS22LastFrameSpare5 () {
		int[] pins = { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 9, 5 };
		string scores = "1-1-1-1-1-1-1-1-1-1/5";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS23LastFrameStrike19 () {
		int[] pins = { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 10, 1, 9 };
		string scores = "1-1-1-1-1-1-1-1-1-X19";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS24Bowl8281 () {
		int[] rolls = { 8, 2, 8, 1 };
		string rollsString = "8/81";
		Assert.AreEqual( rollsString, ScoreMaster.FormatRolls( rolls.ToList() ) );
	}

	[Test] // 300
	public void FS25PerfectGameScore () {
		int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
		string rollsString = " X X X X X X X X XXXX";
		Assert.AreEqual( rollsString, ScoreMaster.FormatRolls( rolls.ToList() ) );
	}

	[Test]
	public void FS26LastFrameStrikeStrike71 () {
		int[] pins = { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 9, 1, 10, 10, 7, 1 };
		string scores = "1-1-1-1-1-1-1-9/ XX71";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS27LastFrameStrikeGutterGutter () {
		int[] pins = { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 10, 0, 0 };
		string scores = "1-1-1-1-1-1-1-1-1-X--";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS28LastFrameStrikeStrikeGutter () {
		int[] pins = { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 10, 10, 0 };
		string scores = "1-1-1-1-1-1-1-1-1-XX-";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS29GutterStrike () {
		int[] pins = { 0, 10 };
		string scores = "-/";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS30GutterStrikeStrike () {
		int[] pins = { 0, 10, 10 };
		string scores = "-/ X";
		Assert.AreEqual( scores, ScoreMaster.FormatRolls( pins.ToList() ) );
	}

	[Test]
	public void FS31RollInTheEnd464 () {
		int[] rolls = { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 4, 6, 4 };
		string testString = "1212121212121212124/4";
		Assert.AreEqual( testString, ScoreMaster.FormatRolls( rolls.ToList() ) );
	}
}
