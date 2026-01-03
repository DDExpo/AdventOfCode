from pathlib import Path


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    answ = 0
    aunt_sue_stats = [
        ("children", 3), ("cats", 7), ("samoyeds", 2), ("pomeranians", 3), ("akitas", 0),
        ("vizslas", 0), ("goldfish", 5), ("trees", 3), ("cars", 2), ("perfumes", 1)
    ]
    aunts_score = [0 for _ in range(501)]

    for line in file.readlines():
        aunt_num, aunt_stats = line.strip().split(":", 1)
        
        aunt_stats_dict = {v.split()[0].strip(":"): int(v.split()[1]) for v in aunt_stats.split(",")}

        for key, val in aunt_sue_stats:
            if key in aunt_stats_dict: 
                if aunt_stats_dict[key] == val: aunts_score[int(aunt_num.split()[1])] += 1
    print(aunts_score.index(max(aunts_score)))
