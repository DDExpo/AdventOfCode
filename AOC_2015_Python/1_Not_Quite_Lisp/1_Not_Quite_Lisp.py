from pathlib import Path

answer = 0
brackets_map = {"(": 1, ")": -1}

with open(Path(__file__).resolve().parent / "task_data", "r") as file:
        
    for char in file.read():
        answer += brackets_map[char]

print(answer)
