from itertools import combinations
from pathlib import Path


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    packages = [int(pkg) for pkg in file.readlines()]
    valid_sum: int = sum(packages) // 3
    answer: int = float("inf")
    min_group_len: int = 9

    for third in range(4, len(packages)//3+1):
        for group1 in combinations(packages, third):
            if sum(group1) != valid_sum:    continue
            if min_group_len < len(group1): continue
            ans: int = 1
            for x in group1:
                ans *= x
            answer = min(answer, ans)

    print(answer) 
