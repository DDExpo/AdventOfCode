from pathlib import Path

floor = 0
answer = 0
brackets_map = {"(": 1, ")": -1}

with open(Path(__file__).resolve().parent / "task_data", "r") as file:
        
    for char in file.read():
        floor += brackets_map[char]
        answer += 1
        if floor == -1:
            break

print(answer)
