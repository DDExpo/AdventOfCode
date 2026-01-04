from collections import defaultdict
from pathlib import Path
from itertools import combinations

with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    containers = []
    len_combs = defaultdict(int)
    min_len_comb = 100000

    for line in file.readlines(): containers.append(int(line.strip()))
    
    for r in range(1, len(containers)+1):
        for comb in combinations(containers, r):
            if sum(comb) == 150:
                if len(comb) <= min_len_comb:
                    min_len_comb = len(comb)
                    len_combs[min_len_comb] += 1 

    print(len_combs)
