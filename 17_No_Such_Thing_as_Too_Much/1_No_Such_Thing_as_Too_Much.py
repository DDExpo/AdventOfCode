from pathlib import Path
from itertools import combinations

with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    answ = 0
    containers = []

    for line in file.readlines(): containers.append(int(line.strip()))
    
    for r in range(1, len(containers)+1):
        for comb in combinations(containers, r):
            if sum(comb) == 150: answ += 1
    print(answ)
