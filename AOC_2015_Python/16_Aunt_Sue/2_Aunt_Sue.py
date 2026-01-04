from pathlib import Path


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    answ = (0, 0)
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
                stat = aunt_stats_dict[key]
                if ((key in ["cats", "trees"] and stat >= val) or
                    (key in ["pomeranians", "goldfish"] and stat <= val) or 
                    (key not in ["pomeranians", "goldfish", "cats", "trees"] and stat == val)):
                     aunt = int(aunt_num.split()[1])
                     aunts_score[aunt] += 1
                     answ = max(answ, (aunts_score[aunt], aunt))
    print(answ)