from collections import defaultdict
from pathlib import Path


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    answer = 0
    instruction_map = {"off": False, "on": True, "toggle": -1}
    grid = defaultdict(bool)
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
                if cur_mode == -1:
                    grid[(x, y)] = not grid[(x, y)]
                else:
                    grid[(x, y)] = cur_mode

    print(sum(grid.values()))
