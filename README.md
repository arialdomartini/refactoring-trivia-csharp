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
