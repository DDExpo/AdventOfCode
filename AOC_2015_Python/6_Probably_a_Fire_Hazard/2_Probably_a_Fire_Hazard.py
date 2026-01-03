from collections import defaultdict
from pathlib import Path


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    answer = 0
    instruction_map = {"off": -1, "on": 1, "toggle": 2}
    grid = defaultdict(int)
    mode = ""
    start = ""
    end = ""

    for instructions in file.readlines():

        instruction = instructions.strip().split()
        if instruction[0] == "turn":
            mode = instruction[1]
            start = instruction[2]
            end = instruction[4]
        else:
            mode = instruction[0]
            start = instruction[1]
            end = instruction[3]

        x_cord, y_cord = map(int, start.split(","))
        x1_cord, y1_cord = map(int, end.split(","))
        
        cur_mode = instruction_map[mode]
        
        for x in range(x_cord, x1_cord+1):
            for y in range(y_cord, y1_cord+1):
                grid[(x, y)] = max(0, grid[(x, y)] + cur_mode)

    print(sum(grid.values()))
