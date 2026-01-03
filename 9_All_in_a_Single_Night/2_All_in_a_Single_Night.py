import itertools

from pathlib import Path
from collections import defaultdict


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    graph = defaultdict(int)
    all_possiblepaths = set()

    for line in file.readlines():
        dst_from, _, dst_to, _, distance = line.strip().split()
        all_possiblepaths.add(dst_from)
        all_possiblepaths.add(dst_to)
        graph[dst_from+dst_to] = int(distance)
        graph[dst_to+dst_from] = int(distance)

    max_path = float("-inf")

    for possible_paths in itertools.permutations(all_possiblepaths):
        path_dst = 0
        for i in range(len(possible_paths)-1):
            path_dst += graph[possible_paths[i]+possible_paths[i+1]]
        max_path = max(max_path, path_dst)

    print(max_path)
