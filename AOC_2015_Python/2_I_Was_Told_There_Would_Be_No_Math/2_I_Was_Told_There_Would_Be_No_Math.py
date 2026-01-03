from pathlib import Path

answer = 0

with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    for dimensions_l_w_h in file.readlines():
        l, w, h = map(int, dimensions_l_w_h.split("x"))
        sides = sorted([l, w, h])
        answer += sides[0]+sides[0]+sides[1]+sides[1]+l*w*h

print(answer)