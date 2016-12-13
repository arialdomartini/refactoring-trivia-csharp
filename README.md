# Refactoring Trivia

Exercise based on the [Trivia](https://github.com/caradojo/trivia) Legacy Code Retreat code.


# Steps

## Golden Master

* Capture the program's output and check whether it's deterministic or not;
* Repeat the execution a reasonable number of times, until the code coverage gives you enough confidence for your subsequent refactoring activities;
* Collect the output in a file, and include it in the test project, using an error-prone manual operation (Poka-yoke).

## Make the output deterministic

### Injecting pararameters via args
* Identify the source of non-determinism;
* Make it parametric and make the parameter controllable via args;
* Use parameters in tests to make them deterministic.

### Via Slice
* Identify the source of non-determinism;
* Extract it as a method;
* Make the method virtual, so it can be overridden in the tests; using inheritance make a test version of the productive code, which removes the non-deterministic behaviors;
* When needed, introduce non-static classes and replace the static program entry point with a non-static method.

### Via Peel
* Identify the source of non-determinism;
* Isolate it from the code, moving it to the top;
* Extract the rest of the code in a separate method, which takes the non-deterministic value as a parameter;
* Use the new method in the test, with a deterministic parameter.

## Refactor `Game`'s constructor: move question creation to a dedicated class
* Extract the business logic present in the constructor of `Game` to a separate method `FillQuestions()`
* Move `FillQuestions()` in a separate `QuestionDeck` class; `Game`'s constructor will create an instance of `QuestionDeck` and will store it as an instance field;
* Pass `FillQuestions()` the current instance of `Game` so it can stil access the needed fields. We will move them later;
* To achieve the previous step, encapsulate all the fields `FillQuestions()` needs to access, creating Bottlenecks.
* `FillQuestions()` also accesses another `Game`'s method, `createRockQuestion()`: move it to `QuestionDeck` as well;

## Move `CurrentCategory()` to `QuestionDeck`

* We aim to move

```csharp
private String currentCategory()
{
    if (places[currentPlayer] == 0) return "Pop";
    if (places[currentPlayer] == 4) return "Pop";
    if (places[currentPlayer] == 8) return "Pop";
    if (places[currentPlayer] == 1) return "Science";
    if (places[currentPlayer] == 5) return "Science";
    if (places[currentPlayer] == 9) return "Science";
    if (places[currentPlayer] == 2) return "Sports";
    if (places[currentPlayer] == 6) return "Sports";
    if (places[currentPlayer] == 10) return "Sports";
    return "Rock";
}
```

to `QuestionDeck`;
* First, make `places[currentPlayer]` a parameter to remove the duplication. To do so, create a Bottleneck for `currentCategory` extracting its body in a separate method;
* Then refactor `places[currentPlayer]` as a parameter;
* The resulting method won't contain any reference to `places[currentPlayer]`, and won't have but 1 single usage (the original `currentCategory()`), since it's a bottleneck; move it to `QuestionDeck`

## Move `AskQuestion` to `QuestionDeck`

* We aim to move 

```csharp
        private void askQuestion()
        {
            if (currentCategory() == "Pop")
            {
                Console.WriteLine(PopQuestions.First());
                PopQuestions.RemoveFirst();
            }
            if (currentCategory() == "Science")
            {
                Console.WriteLine(ScienceQuestions.First());
                ScienceQuestions.RemoveFirst();
            }
            if (currentCategory() == "Sports")
            {
                Console.WriteLine(SportsQuestions.First());
                SportsQuestions.RemoveFirst();
            }
            if (currentCategory() == "Rock")
            {
                Console.WriteLine(RockQuestions.First());
                RockQuestions.RemoveFirst();
            }
        }
```

to `QuestionDeck`
* Since there are multiple usages of `QuestionDeck`, first create a bottleneck using Extract Method, generating a separate `AskQuestionCategory()` method;
* Make `currentCategory()` one of its parameters with Extract Parameter;
* Use Move to move `AskQuestionCategory()` to `QuestionDeck`.

## Move `Game`'s fields to `QuestionDeck`

* We aim to move `Game`'s fields to `QuestionDeck`
* First inject the `Game` instance into `QuestionDeck` through constructor instead of through methods; that's another way to create a bottleneck, since we end up with one single reference to `Game`;
* Now that there's one single reference to `Game`, move `Game`'s fields to `QuestionDeck`, using Extract Field;
* Using Inline we can now remove all the references from `Game`.
* Remove the injection of the unused `Game` instance into `QuestioDeck`

## Cover `QuestionDeck` with unit tests
* Write unit tests for `QuestionDeck`'s methods
