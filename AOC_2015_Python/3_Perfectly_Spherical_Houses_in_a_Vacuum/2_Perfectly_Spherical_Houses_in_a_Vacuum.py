from pathlib import Path

answer = 1
houses = {(0, 0), }
direction_map = {">": (0, 1), "<": (0, -1), "v": (1, 0), "^": (-1, 0)}

with open(Path(__file__).resolve().parent / "task_data", "r") as file:
    x, y = 0, 0 
    x_robo, y_robo = 0, 0
    santa_turn = True
    for direction in file.read():
        dx, dy = direction_map[direction]
        
        if santa_turn:
            santa_turn = False
            x, y = x+dx, y+dy
            nx, ny = x, y
        else:
            santa_turn = True
            x_robo, y_robo = x_robo+dx, y_robo+dy
            nx, ny = x_robo, y_robo

        if (nx, ny) not in houses:
            answer += 1
            houses.add((nx, ny))

print(answer)
