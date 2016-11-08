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

TODO: da rivedere il modo di distribuzione della codebase, 
non posso darla come zip se voglio fornire le branches come recovery points
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
The business ask we to handle a brand new category: History.
At this point we have only one friend...Find all.
Try Find all "category"...many magic strings.
Try Find all "pop"...many fields.
ALT+F7 on popQuestions.
If we look closer to other questions categories we see that there are many duplicated lines of code.
The familiar way to implement the new requirement is to go over Game class and change it in many places.
In other words we add more duplications and more debit.
But we can do better we can refactor the codebase!! :-)

## Setup Tests
Refactor whitout tests? Bad idea!
Install-Package NUnit/xUnit
Write a "TryTestRunner" test and get Red Bar
Fix "TryTestRunner" test and get Green Bar

## Testing strategy
We want write Characterization Tests that freeze current behaviour.
We have many ways to accomplish that, like study the codebase and add many tests for each methods.
But this is crazy, right? Why it is? Because it doesn't scale with large crappy codebases.
In general there are two kinds of test: high level and low level.
Low level tests give feedback on internal quality and they are precise on what failure and why.
High level tests give feedback on external quality and they aren't precise, only fail or not.
Draw GOOS graph to better explaint them.
At the beginning we want write Characterization Tests as application end-to-end tests.

## Begin End-to-end tests
Every application has input and produce outputs.
We can use output to help us write simpler Characterization tests.
The idea is very simple:
  - grab and store output for knows input and use for future verifications.
  - grap current output and compare with stored one.
  - if the output was changed the behaviour was changed too.
The stored output is commonly knows as Golden Master.
This isn't the only way to write this Characterization tests.
It isn't 100% regression bug free, but can rich a good level with low effort.
The quality of this kind of tests depends by the quality of input data.

## Can we Grab the output?
Explore application as black-box.
Add a SpikeTests class in same project.
Write a test that execute GameRunner.Main(null).
Exception? No? Great!
Where output came from? Logger? Trace? Console? Looking for it.
Find All "console.write" in order to verify if app directly write to Console.
I need to grab output. How I can? Possible solutions:
	- execute app and redirect output via shell script
	- replace all Console.WriteLine with a call to a custom logger
	- set Console.Out to a own file/memory stream
Change test Console.SetOut(new StringWriter()) and Assert.Equal("", output);

## Is output deterministic?
Redirect output from memory to file.
Run tests many times, each one to different files.
Are the results equals? Compare with diff tool.
They are different, outout isn.t deterministic.
Why? Possible causes? Input? DateTime? Db? Looking for it.
Find All "random".

## Isolate Randomness
Open ScriptCS or C# Interactive.
Show that a Random with same seed produce every time same sequence of values.
How can we get rid of Random? Possible solutions:
	- input args (high impact, error prone due to if (args == null))
	- slice (medium impact, from static to instance, all done with refactoring move)
	- peel (low impact, only one refactoring move)
Temporally set Random to fixed seed in production code.
Implement all three in branches to feel the impact.
Keep peel, so merge in master.
Remove fixed seed in production code.

## Finally produce Golden Master
Run test with Code Coverage and seed equal to zero.
Run test with Code Coverage and seed equal to two.
Run same test linear function to generate spread seed.
Run test with Code Coverage Tool.
Manually copy output.txt into ..\..\golden-master.txt.
Always do with manual intervention.
Commit gorlden-master.txt file.

## Write Characterization Test
Produce new output file of same number of runs.
Read Golden Master content and put it into "expected" variable.
Read last output content and put into "actual" variable.
Assert.Equal(expected, actual);
Try change something, the test fail.
But remember, it isn't 100% regression bug free.
Clean up test code.

# EPISODE 2

## Bad Code Smell
We do refactoring when have to add a feature to a program, and the code is not structured in a convenient way.
The set of inconvenient way is called bad code smell.
The Martin Fowler's Refactoring Book list 22 Code Smells, of various scope from methods to classes.
There are other books that define different smells or same smells with different names.
With every smell is associated a list of possible refactoring.
The correct refactoring depends from what is our final goal.
We can divide refactoring in three basic movements: extract, inline and move.
This basic movements are at the heart of bigger refactoring (we sum little behaviour to get bigger behaviour).
Most of the time before get the final design we pass through various intermediate steps that increase the level of dirtiness of the code.
Another aspect is that smells and refactoring was born into OOP circle.
Nothing stop to find smells and apply refactoring related to different programming paradigms like FP or other NFR aspect like performance.

## Meet the most frequent smells
Long Method: too much complicated due to many variables and branches.
Long Parameter List: you are too bind to the old procedural world, with many parameters and someone as out result.
Large Class: when a class is try to do too much typically contains too many responsibilities.
Duplicated Code: the simplest form is when you have the exact same expression in two place.
Switch Statements: is a procedural way to express type-based behaviour.
Conditional Complexity: idem, is a procedural way to express context-based behaviour.
Primitive Obsession: we use too much primitive data type offered by runtime like int and string.
Data Clumps: often you'll see the same set of data items together in many places.
Feature Envy: when a method makes too many calls to other classes to obtain data.
Divergent Change: occurs when one class is commonly changed in different ways for different reasons.
Shotgun Surgery: every time you make the same kind of change, you have to make a lot of little changes to a lot of different classes.
Refused Bequest: inherit too much useless fields and methods due to wrong class hierarchy.
Contegorized as:
STRUCTURAL: Long Method, Large Class, Long Parameter List
MISSING OO: Primitive Obsession, Switch Statements, Duplicate Code, Conditional Complexity
RESPONSIBILITY DISTRIBUTION: Data Clumps, Refused Bequest, Divergent Change, Shotgun Surgery, Feature Envy

## Looking for smells
Large Class: Game class
Divergent Change: Game class may change for penalty rule, board, questionnaire, etc.
Primitive Obsession: every Game's field is of primitive types.
Long Method: roll(int roll), wasCorrectlyAnswered().
Duplicated Code: places[currentPlayer], players[currentPlayer], places[currentPlayer] = places[currentPlayer] roll, if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12, if (currentPlayer == players.Count) currentPlayer = 0.
Shotgun Surgery: Every time we handle a new question category we need to modify Game's ctor, askQuestion() and currentCategory().
Data Clump: all question related fields are hang around together, all the player fields.
Feature Envy: GameRunner call many Game methods to decide if there is a winner. Console would be same notification object.
Switch Statement: askQuestion(), currentCategory().
Conditional Complexity: roll(int roll), wasCorrectlyAnswered().

## Smells that impact the new requirement
We need to handle History category.
We have many smells related to questions logic.
The primary is Shotgun Surgery, then Data Clumps and unmissables Primitive Obsession and Duplication.
But directly work inside Game class is complex and even worst risky.
We can do better, we can isolate affected parts moving them into another place.
Then we can works in the new place with little surface and complexity.
At beginning we want favour refactoring that reduce the scope in order to hide complexity.
Focus is really important during refactoring in order to don't introduce regression.
Begin adding a TODO file with the result of ALT+F7 on one random questions field.

## QuestionDeck Born
Target, move questions related code, as is, into a new class.
Remember:
	1) Commit frequently.
	2) Run tests frequently.
	3) Stay focused.
Add empty class QuestionDeck.
Add readonly field in Game.

## Try Attack FillQuestions
First interessed part is in Game's ctor.
The logic is impossible to move around because is in the ctor.
Select all code and then Extract Method "FillQuestions".
Go on "FillQuestions" and hit F6 move method, but R# show many warnings.
Don't do refactoring like that, be more safe, do refactoring with zero/one warning.
In order to move around methods that use this filds, we need to open them to public access.
But open field is risky, let introduce a bottleneck in front of them.

## Encapsulate Fields
The .NET way to encapsulate a field is a property.
But with getters and setters?
We need to understand how Game change questions state.
The fastest and secure way to understand that is to mark field as readonly.
Then Encapsulate fields and expose only getters.
Ensure that all Game's code never directly access to fields.
We have created a bottleneck, se the future refactoring inpact will always be one place.

## Attack FillQuestions
Come back to "FillQuestions", change to public, move method, but R# show one more warning, "createRockQuestion".
See it? One more time, dependencies block the code.
Point to "createRockQuestion", change to public, move into QuestionDeck.
But wait, the method is stupid, we can inline it...don't do that!! Stay focused, add to TODO list.
Point to "FillQuestions", change to public, move into QuestionDeck.
Mark back "createRockQuestion" as private.
Remove this item from TODO list.

## Try Attack AskQuestion
Look at TODO list and point to "askQuestion".
Analyze dependencies, one way to do is copy/paste method from source to destination and see the compilation error.
AskQuestion dependes from CurrentCategory so move this first.

## Attack CurrentCategory
Point to "currentCategory" method.
This method already exists, so before move around we need two check.
First check it is visibility, it is public or private? Private, ok movable for now.
Second check dependencies, more than one method? Yes, revert movable.
Move this method is risky, let introduce a bottleneck behind of them.
The new method must be movable by design, so not introduce dependencies.
Select "places[currentPlayer]" and then Extract Variable to remove duplication.
Select the rest of the method, then Extract Method "CategoryPlace".
Point to "CategoryPlace", F6 move method into QuestionDeck.
Get back in Game and inline "places[currentPlayer]" variable.
Remove this item from TODO list.

## Attack AskQuestion
Point to "AskQuestion".
This method already exists, so before move around we need two check.
First check it is visibility, it is public or private? Private, ok movable for now.
Second check dependencies, more than one method? Yes, revert movable.
Move this method is risky, let introduce a bottleneck behind of them.
More, we dependes by another not moved method, prefer break dependency.
Same refactoring as before but with inverted steps.
Select all method's body, then Extract Method "AskQuestionCategory".
Select "CurrentCategory", Extract Parameter to remove duplication.
Point to "AskQuestionCategory", F6 Move Method into QuestionDeck.
We aren't happy here due to "Console.WriteLine".
Just wait, annotate it and skip. Stay focused!
Remove this item from TODO list.

## Attack Game fields
Find Usages of properties, result in only "QuestionDeck".
At the end we need to move the field initialization from Game to QuestionDeck.
Theretically we can inline all the properties, but in practice we can't.
And even if we will, we wont because Game is used in two places, not one.
Inline properties is risky, let introduce a bottleneck.
Inject ctor "Game" into "QuestionDeck".
Set and use local collections fields.
Remove Game parameter from public methods.
Better but we still can't inline due to invocation chain.
QuestionDeck -> PopQuestions -> private popQuestions -> new LinkedList<String>
We can change field visibility and then inline property but we break the chain in the middle.
Change strategy and start from the end and go backward.
Inline field definition into property.
QuestionDeck -> PopQuestions -> new LinkedList<String>
Inline property  into caller.
QuestionDeck -> new LinkedList<String>
Inline remaining "ScienceQuestions", "SportsQuestions" and "RockQuestions".

# EPISODE 3

## Put CurrentCategory Under Characterization Tests
Add class QuestionDeckTests.
Add "CategoryForPlace" data-driven test.
What for the last category (Rock)?
It seems that it hasn't a relationship with the place.
In reality it has, only that is implicit.
Better evidence the implicit relationship (from implicit to explicit).
Add "CategoryForOutOfBoardPlace" test.

## Put AskQuestion Under Characterization Tests
Add "AskCategoryFirstQuestion" test.
We can test without a visible output.
Change return type from "Void" to "String".
Add a return value equal to printed one.
Complete "AskCategoryFirstQuestion" test.
Add "AskManyQuestionsForSameCategory" test.
Add "AskQuestionForDifferentCategory" test.
Add "AskMixCategoryQuestion" test.

## Clean FillQuestions
Point to "FillQuestions".
Remove useless parenthesis.
Point to "createRockQuestion" not inline because we can reuse it.
Let Extract Parameter category name and then Rename into "CreateQuestion".
This is the power of waiting the last responsible moment to take decisions.

## Clean AskQuestionCategory
Point to "AskQuestionCategory".
Extract Variable from return.
Move variable outer scope to remove duplications.
Move "Console.WriteLine" outer scope to remove duplications.
Move "Console.WriteLine" into "Game".

## Clean CategoryPlace
Point to "CategoryPlace".
Use "||" (or) to collapse conditionals.
Extract array variable with conditionals values, change "IF" in "Contains".
Extract Field and move array initialization into Ctor.
Wow!! More Data Clumps and in a different form.
Another example of the power of waiting the last responsible moment to take decisions.
Port remaining "ScienceQuestions", "SportsQuestions" and "RockQuestions".

## CategoryQuestions Born
Now if we look closer to QuestionDeck we can see that Data Clump is still there.
It is underlined by all little duplications.
The problem here is that the logic is duplicated only to handle different data.
How we proceed? We make a new Object that concentrate only the logic and ask for data.
This time we use another technique called Parallel Design.
Add class "CategoryQuestions" and use Pop Category to shape the external API.
Add "PlaceOn", "AddQuestion", "IsOnPlace" and "NextQuestion" methods.
Don't leave the NotImplementedException, the code must run.
Replace one by one the other categories.
Encapsulate Field to expose "CategoryName" category.
What we have done is follow one of the Pragmatic Programmers tip:
	Put Abstraction in Code and Details in Data.
Aggregate all questions into a collection.

## Retry Add New Requirement
Now handle History Category is one line change.
But the board was full, so we need to understand where place this new questions, so talk with business.
The responses could be many: replace a old one with new, change distribution algorithm, doesn't add History anymore.
In this case replace "Science" with "History".
Run tests and let see what happens.
Golden Master test break, it's ok.
QuestionDeckTests break, it isn't ok, revert replace.

## Get Feedback from QuestionDeck tests
Tests are a great source of feedback because they use our code from a client point of view.
Why tests breaks? Because QuestionDeck and it's tests works with hardcoded production data.
We write tests in this style on purpuse because they are Characterization tests.
But now this tests create frictions, they are legacy tests.
In this case we see that:
  - we miss the correlation from input and output of tests.
  - when a category's data (like name) change many tests break (no behaviour change).
  - the scenario under test aren't clear.
  - totally miss the boundary condition.
Before fix them, in order to show the differencies of style let's write tests for "CategoryQuestins".

## Write CategoryQuestions tests
Add class CategoryQuestionsTests
Add "CheckPositionWithCorrectPlace" test.
Add "CheckPositionWithWrongPlace" test.
Add "ManyNextQuestions" test.
Add "NextQuestionWhenTerminated" test. Chose an Exception.
Use simple collection like List<>.

## Write QuestionDeck Tests
Write better test, in parallel, in order to shape a better API.
Mark legacy tests with "_" and leave were they are.
Rewrite "CategoryForInBoardPlace".
Add a "AddCategory" method.
Rename "CategoryPlace" to "CategoryOn".
Rewrite "CategoryForOutOfBoardPlace".
Rewrite "AskDifferentCategoryQuestion".
Rename "AskQuestion" to "NextQuestionFor".
Rewrite "AskSameCategoryQuestion".
Add "AskQuestionForUnknownCategory".
Update production code to use new API.
Now that we have good test we can remove tests marked with "_".

## Now Add New Requirement
Replace "Science" with "History".
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
Find first "Console.WriteLine" and extract a method.
Repeat for all output call.
Extract "ConsoleGameReport" object.
Move all static methods.
Make Display's methods non-static.
Extract interface.
Extract dependency.
Remove "Console.WriteLine" duplication.
Extract Field writer.
Inline "ConoleWriteLine".
Update Golden Master tests
But we did refactoring without a feature?
There are non-functional requirements guided by non-functional feature.
The tests are our first non-functional requirements stakeholders.

## How to learn Refactoring
TODO: talk about quick & dirty and deep practice

## The End
Thanks a lot to had attended to this course!!!



