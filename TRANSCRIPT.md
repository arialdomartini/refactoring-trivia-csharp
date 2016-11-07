# EPISODE 1

## Introduction
People presentation
Describe you
Describe "Refactoring Legacy Code" initiative
  - fast feedback loop
  - tiny steps
  - 2 minutes to commit
  - raise your confidence
  - brach for experiment
  - master IDE short-cuts
  - common bad code smells
  - looking for smells
  - refactoring (what/when)
  - refactoring (moves)
  - break dependencies
  - isolate to reduce scope
  - golden master tests
  - characterization tests
  - exploratory tests

## Introduction to Refactoring
More important of what is when. When refactor?
When you have to add a feature to a program, and the code is not structured in a convenient way to add that feature.
First refactor the program to make it easy to add the feature, then add the feature.
Show two cost/change graphs (anonymous), ideal and legacy.
Refactoring must be applied in order to reduce maintanability costs (aka not increase the crap)
What is refactoring?
Refactoring is the process of restructuring code without changing its external behavior.
Refactoring improves only nonfunctional (quality, performance, etc) attributes of the software.

## Quick FizzBuzz Demo (only you)
Open, build and run solution.
Run tests.
Who knows the kata? Explain it!
Add divisible by 7 print "Yo!".
Easy way, ifs expolosion.
Map this behaviour on the anonymous graphs.
Refactoring way make code reusable.
Now easy and clean way, we can call simple way.
Verify with the 7 implementation.

## Refactoring and Testing relation
After a deep refactoring.
How can we know that we didn't change anything?
We need to cover the application code with automatic tests
With legacy application it's particular kind of tests.
We want write application tests also knows as Characterization Tests.

## Inherit codebase
Get Trivia
	https://drive.google.com/drive/folders/0B72Hr4IhXoCkNWlqQVVQNmN0ZkE
Open, build and run solution.
Execute git init
Execute git add . -A
Execute git commit -m "Inherited mess :-)"

## The Trivia Game
Trivia is a trivial pursuite game simulation.
Who knows? Explain it!
The game was composed by board, dice, players, questions of various categories.
The code isn't a total crap like our production codebases, but is difficult enough.
And like production codebases there aren't tests.

## New Requirement
The business ask we to handle a brand new History category.
If we look closer to other questions categories we see that there are many duplicated lines of code.
The familiar way to implement the new requirement is to go over Game class and change it in many places.
In other words we add more duplications and more debit
But we can do better we can refactor the codebase!! :-)

## Testing strategy
Refactor whitout tests? Bad idea!
We want write application end-to-end tests also knows as Characterization Tests.
This Characterization tests freeze current behaviour.
We can use application output to help us write simpler Characterization tests.
The idea is very simple:
  - grab and store output and use it for future verifications.
  - if the output was changed the behaviour was changed too.
The initial grabbed output is commonly knows as Golden Master.
This isn't the only way to write this Characterization tests.
It isn't 100% regression bug free, but can rich a good level with low effort.
The quality of this kind of tests depends by the quality of input data.

## Setup Tests
Install-Package NUnit/xUnit
Write a "TryTestRunner" test and get Red Bar
Fix "TryTestRunner" test and get Green Bar

## Can we Grab the output?
Explore application as black-box.
Add a SpikeTests class in same project.
Write a test that execute GameRunner.Main(null).
Exception? No/ Great!
Where output came from? Logger? Trace? Console? Looking for it.
Find All 'console.write' in order to verify if app directly write to Console.
I need to grab output. How I can? Possible solutions:
	- execute app and redirect output via shell script
	- execute app via Process class and redirect output
	- replace all Console.WriteLine with a call to a custom logger
	- set Console.Out to a own file/memory stream
Change test Console.SetOut(new StringWriter()) and Assert.Equal("", output);

## Is output deterministic?
Redirect output from memory to file.
Run tests many times, each one on different file.
Are the results equals? Compare with diff tool.
Show that tests aren't deterministic.
Why? Possible causes? Input? DateTime? Db?
Find All 'random'.

## Isolate Randomness
Open ScriptCS
Show that a Random with same seed produce every time same sequence of values.
How can we get rid of Random? Possible solutions:
	- input args (high impact, error prone due to if (args == null))
	- slice (medium impact, all done with refactoring move)
	- peel (low impact)
Implement peel, push up random variable.
Extract Run method.
Run game tests many times.
Are the results equals? Compare with visual tool.

## Finally produce Golden Master
Run game test with seed equal to zero.
Run with Code Coverage Tool.
Run same test with seed from zero to two.
Run with Code Coverage Tool.
Run same test linear function to generate spread seed.
Run with Code Coverage Tool.
Copy output.txt into ..\..\golden-master.txt.
To do always with manual intervention.
Commit gorlden-master.txt file.

## Write Characterization Test
Produce new output file of same number of runs.
Read Golden Master content and put it into 'expected' variable.
Read last output content and put into 'actual' variable.
Assert.Equal(expected, actual);
Try change something, the test fail.
But, remember? It isn't 100% regression bug free.
Try change something else, and test still pass.
Clean up test code.

# EPISODE 2

## Bad Code Smell
We do when have to add a feature to a program, and the code is not structured in a convenient way.
The set of inconvenient way is called bad code smell.
The Martin Fowler's Refactoring Book list 22 Code Smells, of various scope from methods to classes.
There are other books that define different smells or same smells with different names.
With every smell is associated a list of possible refactoring.
Except some special refactoring, we can divide it in three basic movements: extract, inline and move.
This basic refactoring are at the heart of bigger refactoring, we sum little behaviour to get bigger behaviour.
Most of the time before get the final design we pass through various intermediate steps that increase the level of dirtiness of the code.
Sometimes which refactoring is better in which case, is difficult to say, it depends, so we use heuristics or prototypes.
Another aspect is that smells and refactoring was born into OOP circle.
Nothing stop to find smells and apply refactoring related to different programming paradigms like FP or other NFR aspect like performance.

## Meet the most frequent smells
Long Method: too much complicated due to many variables and branches.
Long Parameter List: you are too bind to the old procedural world, with many parameters and someone as out result.
Large Class: when a class is try to do too much typically contains too many responsibilities.
Duplicated Code: the simplest form is when you have the exact same expression in two place.
Switch Statements: is a procedural way to express type-based behaviour.
Conditional Complexity: idem, is a procedural way to express context-based behaviour.
Primitive Obsession: all programming environments offer only primitive data type like int and string.
Data Clumps: often you'll see the same set of data items together in many places.
Feature Envy: when a method makes too many calls to other classes to obtain data.
Divergent Change: occurs when one class is commonly changed in different ways for different reasons.
Shotgun Surgery: every time you make the same kind of change, you have to make a lot of little changes to a lot of different classes.
Refused Bequest: inherit too much useless fields and methods due to wrong class hierarchy.

## Looking for smells
Large Class: Game class
Divergent Change: Game class may change for penalty rule, board, questionnaire, etc.
Primitive Obsession: every Game's field is of primitive types.
Long Method: roll(int roll), wasCorrectlyAnswered().
Duplicated Code: places[currentPlayer], players[currentPlayer], places[currentPlayer] = places[currentPlayer] roll, if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12, if (currentPlayer == players.Count) currentPlayer = 0.
Shotgun Surgery: Every time we handle a new question category we need to modify Game's ctor and askQuestion().
Data Clump: all question related fields are hang around together, all the player fields.
Feature Envy: GameRunner call many Game methods to decide if there is a winner. Console would be same notification object.
Switch Statement: askQuestion(), currentCategory().
Conditional Complexity: roll(int roll), wasCorrectlyAnswered().

## Remember the new requirement
Handle History category.
We have many smells related to questions logic.
The primary is Shotgun Surgery, then Data Clumps and unmissable Primitive Obsession.
But directly work inside Game class is difficult and even worst risky.
We can do better, we can first solve Data Clump and extract questions logic.
Then we can works with the new little surface.
At beginning we want favour refactoring that reduce the scope in order to hide complexity.
Add TODO file with Data Clump and Shotgun Surgery categories.
Focus is really important during refactoring in order to don't introduce regression.

## QuestionDeck Born
Target move questions related code, as is, into a new class.
Remember:
	1) Commit frequently.
	2) Run tests frequently.
	3) Stay focused.
Add empty class QuestionDeck.
Add readonly field in Game.

## Try Attack FillQuestions
Find Usages on all the questions collection show that they are all used in three place.
Take the first in Game's ctor.
The logic is difficult to move around for two reason:
	1) is in the ctor
	2) access to Game's private field

## Encapsulate Fields
We need to understand how Game change questions state.
Find Usages on all the questions collection show that they are all used in three place.
Only 'AskQuestion' introduce side-effects, but nobody change fields.
Improve safety mark field as readonly.
Encapsulate fields.
Ensure that all Game's code never directly access to fields.
Create a bottleneck, not another Shotgun Surgery.

## Attack FillQuestions
The logic is difficult to move around for two reason:
	1) is in the ctor
Fix 1, select all code and then Extract Method 'FillQuestions'.
Point to 'FillQuestions', change to public, move into QuestionDeck, but we can't due to 'CreateRockQuestion'.
See it? One more time, dependencies block the code.
Point to 'CreateRockQuestion', change to public, move into QuestionDeck.
Point to 'FillQuestions', change to public, move into QuestionDeck.
We aren't happy here due to 'CreateRockQuestion'.
Just wait, annotate it and skip. Stay focused!

## Attack CurrentCategory
Point to next Find Usages, aka AskQuestion.
Analyze dependencies, one way to do is copy/paste method from source to destination and see the compilation error.
AskQuestion dependes from CurrentCategory so move this first.
Point to CurrentCategory method.
Is this method related to questions logic? Yes, it is or at least it seems.
So first work on this. Analyze dependencies.
Select 'places[currentPlayer]' and then Extract Variable to remove duplication.
Prefer extract and move private methods instead of public one.
Select the rest of the method, then Extract Method 'CategoryPlace'.
Point to 'CategoryPlace', Move Method into QuestionDeck.
Get back in Game and inline 'places[currentPlayer]' variable.

## Attack AskQuestion
Point to 'AskQuestion'.
One way is to select, extract and move all body, since 'CurrentCategory' is in 'QuestionDeck'.
But maintain the dependency between two methods.
Prefer break dependency.
Select 'CurrentCategory', Extract Variable to remove duplication.
Select the rest of the method, then Extract Method 'AskQuestionCategory'.
Point to 'AskQuestionCategory', Move Method into QuestionDeck.
We aren't happy here due to 'Console.WriteLine'.
Just wait, annotate it and skip. Stay focused!

## Attack Game fields
Find Usages of properties, result in only 'QuestionDeck'.
Inject ctor 'Game' into 'QuestionDeck'.
Set and use local collections fields.
Remove Game parameter from public methods.
Inline 'PopQuestions', 'ScienceQuestions', 'SportsQuestions' and 'RockQuestions'.

# EPISODE 3

## Put CurrentCategory Under Characterization Tests
Add class QuestionnaireCharacterizationTests.
Add 'CategoryForCorrectPlace' data-driven test.
Add 'CategoryForOutOfBoardPlace' test.

## Put AskQuestion Under Characterization Tests
Add 'AskDifferentCategoryQuestion' test.
We can test without a visible output.
Add a return value equal to print.
Complete 'AskDifferentCategoryQuestion' test.
Add 'AskSameCategoryQuestion' test.
Add 'AskMixCategoryQuestion' test.

## Clean FillQuestions
Point to 'FillQuestions'.
Remove useless parenthesis.
Inline 'CreateQuestion'.
Extract 'BuildQuestion' method.

## Clean AskQuestionCategory
Point to 'AskQuestionCategory'.
Extract Variable to remove duplication, call 'Console.WriteLine' only once.
Change return type from 'Void' to 'String'.
Move 'Console.WriteLine' into 'Game'.

## Clean CategoryPlace
Point to 'CategoryPlace'.
Use '||' (or) to collapse conditionals.
What for the last category (Rock)?
It seems that it hasn't a relationship with the place.
In reality it has, only that is implicit.
Better evidence the implicit relationship (from implicit to explicit).
Extract array variable with conditionals values, change 'IF' in 'Contains'.
Extract Field and move array initialization into Ctor.

## CategoryQuestions Born
Now if we look closer to QuestionDeck we can see that Data Clump is still there.
It is underlined by all little duplications.
The problem here is that the logic is duplicated only to handle different data.
How we proceed? We make a new Object that concentrate all the logic.
In order to refactor safely we use Parallel Design.
Add class 'Question' and use Pop Category to shape the external API.
What we have done is follow one of the Pragmatic Programmers tip:
	Put Abstraction in Code and Details in Data.
Replace one by one the other categories.
Encapsulate Field to expose 'CategoryName' category.
Aggregate all questions into a collection.

## Write CategoryQuestions Tests
Add class CategoryQuestionsTests
Add 'CheckPositionWithCorrectPlace' test. Add a 'PlaceOn' method.
Add 'CheckPositionWithWrongPlace' test.
Add 'ManyNextQuestions' test. Add a 'AddQuestion' method.
Add 'NextQuestionWhenTerminated' test. Chose an Exception.
Change method names in 'IsOnPlace' and 'NextQuestion'.
Use simple collection like List<> or Queue<>.

## Retry Add New Requirement
Now handle History Category is one line change.
But the board was full, so we need to understand where place this new questions, so talk with business.
The responses could be many, replace a old one with new, change distribution algorithm, doesn't add History anymore.
In this case replace 'Science' with 'History'.
Golden Master test break, it's ok.
QuestionnaireCharacterization tests break, it isn't ok.
Revert and fix test.

## Get Feedback from QuestionDeck tests
Are tests good? No, they are Characterization tests.
Tests are a great source of feedback because they use our code from a client point of view.
In this case we see that:
	- we miss the correlation from input and output of tests.
	- when a category's data (like name) change many tests break.
	- the scenario under test aren't clear.
	- totally miss the boundary condition.
Write better test, in parallel, in order to shape a better API.

## Write QuestionDeck Tests
Add class QuestionnaireTests.
Rewrite 'CategoryForInBoardPlace'.
Add a 'AddCategory' method.
Rename 'CategoryPlace' to 'CategoryOn'.
Rewrite 'CategoryForOutOfBoardPlace'.
Rewrite 'AskDifferentCategoryQuestion'.
Rename 'AskQuestion' to 'NextQuestionFor'.
Rewrite 'AskSameCategoryQuestion'.
Add 'AskQuestionForUnknownCategory'.

## Remove QuestionDeck Characterization Tests
Now that we have good test we can remove Characterization tests.
Update production code to use new API.

## Now Add New Requirement
Replace 'Science' with 'History'.
Golden Master test break, it's ok.

## Approve New Golden Master
After change Golden Master test break.
You can try to analyze files with merge tool in order to better verify what was changed.
Manually replace old Golden Master with new output file.

## Honor Your Output
In many case Logging Is a Feature.
There are two big category for logging, support and diagnostic.
The first are application output to inform the user.
The second are application output to inform the developer.
Notification rather than logging.
Find first 'Console.WriteLine' and extract a method.
Repeat for all output call.
Extract 'ConsoleGameReport' object.
Move all static methods.
Make Display's methods non-static.
Extract interface.
Extract dependency.
Remove 'Console.WriteLine' duplication.
Extract Field writer.
Inline 'ConoleWriteLine'.
Update Golden Master tests
But we did refactoring without a feature?
There are non-functional requirements guided by non-functional feature.
The tests are our first non-functional requirements stakeholders.

## The End
Thanks a lot to had attended to this course!!!