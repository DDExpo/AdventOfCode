from pathlib import Path


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    table = {(1, 1): 20151125}
    multiplier: int = 252533
    divider:    int = 33554393 
    prev            = (1, 1)
    row, column     = (2, 1)

    row_column_end = [int(x) for x in file.read().replace(",", "").replace(".", "").split(" ") if x.isdigit()]
    while True:

        if column == 1:
            prev = (1, row-1)
        else:
            prev = (row+1, column-1)
        
        table[(row, column)] = (table[prev] * multiplier) % divider
        
        if (row, column) == (row_column_end[0], row_column_end[1]):
            print(table[(row, column)])
            break

        if row == 1:
            row, column = column+1, row
        else:
            row, column = row-1, column+1
