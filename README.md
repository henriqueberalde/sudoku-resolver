# sudoku-resolver
> Vou escrever em inglês porque sou chique, mas fui eu mesmo que escrevi heim. Tem nada da internet aqui não papai.

Resolves easy sudokus, the ones that has always one blank space with only one number possibility.


The propose (purpose) of the project was (is) to study and put in practice TDD development method once the Sudoku game rules are very clear and defined.

# Talking about (the) code

The algorithm scrolls through all blank spaces, analyzing how many possible numbers each blanck space has.

If, in case of only one number possibility was found, the application fills the blanck space. However, if more than one number  possibility is found, the application goes to next blanck space.

The application does the single number possibility assessment until there is no blanck spaces.

For while the unsolved sudoku needs to be seted by hard-code, as a two dimensions matriz int[9,9]. Fill all blanck spaces with 0.

#### Example:
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

While the application scrolls through the blank spaces it outputs useful information.
#### Example:
```
Try resolve [4, 0]
Not Resolved. Possible values: [2, 9]
Try resolve [4, 1]
Resolved: 9
Try resolve [4, 3]
Resolved: 3
Try resolve [6, 0]
Resolved: 8
Try resolve [6, 4]
Resolved: 6
Try resolve [7, 0]
Resolved: 9
Try resolve [7, 1]
Resolved: 5
Try resolve [4, 0]
Resolved: 2
No blank space was found
The Sudoku is resolved
```


When the application no longer finds blank spaces it outputs the solved sudoku:
#### Example:
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


When the application is done it shows the validation status for each position of the sudoku, if the position is valid the status is 1 but if it's not the status is 0.
#### Example:
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
# New Features
- [ ] Cover 100% of the Sudoku game rules on unity tests
- [ ] Create an easy interface to input the sudoku to be solved.
- [ ] Evolve the algorithm to solve complex sudokus, the ones that not always has one number possibility for white space
- [ ] Plug a device to scan sudoku magazines to solve
