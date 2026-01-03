from pathlib import Path

with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    answ = 0
    yards_map = [["."]*102 for _ in range(102)]
    meaning = {"#": 1, ".": 0}
    
    for row, line in enumerate(file.readlines()):
        line = line.strip()
        for col, ch in enumerate(line):
            yards_map[row+1][col+1] = ch
    
    yards_map[1][1]   = "#"
    yards_map[-2][-2] = "#"
    yards_map[1][-2]  = "#"
    yards_map[-2][1]  = "#"
    
    for _ in range(100):

        yards_map_2 = [["."]*102 for _ in range(102)]
        yards_map_2[1][1]   = "#"
        yards_map_2[-2][-2] = "#"
        yards_map_2[1][-2]  = "#"
        yards_map_2[-2][1]  = "#"


        for row in range (1, 101):
            for col in range(1, 101):
                if (row, col) in ((1, 1), (100, 100), (100, 1), (1, 100)): continue

                lights_on = 0
                for nrow, ncol in [(1, 0), (0, 1), (1, 1), (-1, 0), (0, -1), (-1, -1), (-1, 1), (1, -1)]:
                    lights_on += meaning[yards_map[row+nrow][col+ncol]]
                
                if    lights_on == 3      and yards_map[row][col] == ".": yards_map_2[row][col] = "#"
                elif  lights_on in (2, 3) and yards_map[row][col] == "#": yards_map_2[row][col] = "#"
                else: yards_map_2[row][col] = "."

        yards_map = yards_map_2

    for row in yards_map: answ += row.count("#")

    print(answ)
