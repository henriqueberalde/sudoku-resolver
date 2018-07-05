# sudoku-resolver
> Vou escrever em inglês porque sou chique, mas fui eu mesmo que escrevi heim. Tem nada da internet aqui não papai.

Resolves easy sudokus, the ones that has always one blank space with only one number possibility.


The propose of the project was to study and put in practice TDD development method once the Sudoku game rules are very clear and defined.

### Talking about code

The algorithm travels through all blank spaces analyzing how many numbre possibilities it has and in case it is only one, it fills the space and restart the verification.
For while sudoku to be solved is setted by hard-code, it is a two dimensions matriz int[9,9].

##### Example:
```
var matriz = new int[9, 9] {
    { 1, 0, 0, 6, 0, 5, 0, 8, 0 },
    { 0, 0, 0, 0, 0, 0, 3, 4, 0 },
    { 7, 8, 3, 0, 0, 2, 0, 1, 6 },
    { 3, 1, 5, 9, 4, 6, 2, 0, 8 },
    { 0, 0, 0, 0, 0, 0, 4, 6, 0 },
    { 4, 7, 0, 0, 1, 0, 0, 5, 0 },
    { 0, 3, 2, 0, 0, 0, 0, 9, 7 },
    { 0, 0, 0, 1, 0, 3, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 8, 0, 5 }
};
```
> Blank spaces are filled with 0 to be solved.

As the application travels through the blank spaces it outputs:
"Try resolve [row, column]" where row is the row index and column is the column index of the current item.

##### Example:
```
Try resolve [0, 0]
```

In case the application finds more than one possibility for the blank space it outpus:
"Not Resolved. possible values: [n, n, n]" where n is the possibility number.
##### Example:
```
Not Resolved. possible values: [1, 2, 3]
```
In case the application finds only one possibility it fills the value and outpus:
"Resolved: n" where n is the correct number for the blank space.
##### Example:
```
Resolved: 9
```
When the application no longer finds blank spaces it outputs the solved sudoku:
##### Example:
```
##################
 1 2 4 6 3 5 7 8 9
 5 6 9 8 7 1 3 4 2
 7 8 3 4 9 2 5 1 6
 3 1 5 9 4 6 2 7 8
 2 9 8 3 5 7 4 6 1
 4 7 6 2 1 8 9 5 3
 8 3 2 5 6 4 1 9 7
 9 5 7 1 8 3 6 2 4
 6 4 1 7 2 9 8 3 5
##################
```
When the application is done it runs the sudoku validator.
The sudoku validator shows the validation status, it shows 1 for correct filled number anda 0 for incorrect ones.
##### Example:
```
Validating Result:
######RESULT######
 1 1 1 1 1 1 1 1 1
 1 1 1 1 1 1 1 1 1
 1 1 1 1 1 1 1 1 1
 1 1 1 1 1 1 1 1 1
 1 1 1 1 1 1 1 1 1
 1 1 1 1 1 1 1 1 1
 1 1 1 1 1 1 1 1 1
 1 1 1 1 1 1 1 1 1
 1 1 1 1 1 1 1 1 1
######RESULT######
```
### New Features
- [ ] Cover 100% of the Sudoku game rules on unity tests
- [ ] Create an easy interface to input the sudoku to be solved.
- [ ] Evolve the algorithm to solve complex sudoku, the ones that not always has one number possibility for white space
- [ ] Plug a device to scan sudoku magazines to solve
