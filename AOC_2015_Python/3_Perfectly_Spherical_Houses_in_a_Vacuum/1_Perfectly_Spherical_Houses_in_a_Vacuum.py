from pathlib import Path

answer = 1
houses = {(0, 0), }
direction_map = {">": (0, 1), "<": (0, -1), "v": (1, 0), "^": (-1, 0)}

with open(Path(__file__).resolve().parent / "task_data", "r") as file:
    x, y = 0, 0 
    for direction in file.read():
        dx, dy = direction_map[direction]
        x, y = x + dx, y + dy
        if (x, y) not in houses:
            answer += 1
            houses.add((x, y))

print(answer)
