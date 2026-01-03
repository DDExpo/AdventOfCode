import itertools
from collections import defaultdict
from pathlib import Path

with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    answ = 0
    happinnes_map = defaultdict(dict)
    minus_plus = {"gain": 1, "lose": -1}

    for line in file.readlines():
        name, _, will_happy, val, _, _, _, _, _, _, next_name = line.strip().strip(".").split(" ")

        happinnes_map[name][next_name] = int(val) * minus_plus[will_happy]
        happinnes_map[name]["me"] = 0

    happinnes_map["me"] = {}
    for name in happinnes_map.keys():
        happinnes_map["me"][name] = 0

    for arrangment in itertools.permutations(list(happinnes_map.keys())):
        cur_happines = 0
        for i, name in enumerate(arrangment):
            cur_happines += happinnes_map[name][arrangment[i-1]] + happinnes_map[name][arrangment[(i+1)%len(arrangment)]]

        answ = max(answ, cur_happines)

    print(answ)
