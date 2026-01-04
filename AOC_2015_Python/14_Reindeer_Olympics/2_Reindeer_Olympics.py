from pathlib import Path


with open(Path(__file__).resolve().parent / "task_data", "r") as file:
    
    deers_points = {}
    time_to_race_sec = 2503
    cur_positions = []
    reindeer_stats = []
    
    for line in file.readlines():
        reindeer, _, _, speed_kmsec, _, _, time_sec, _, _, _, _, _, _, rest_time_sec, _ = line.strip().split()
        reindeer_stats.append((reindeer, int(speed_kmsec), int(time_sec), int(rest_time_sec)))
        deers_points[reindeer] = 0
        cur_positions.append((0, int(time_sec), int(rest_time_sec)))

    while time_to_race_sec > 0:

        time_to_race_sec -= 1
        cur_max = 0

        for i, deer_st in enumerate(cur_positions):
            cur_dist, work_time, rest_time = deer_st
            if work_time > 0:
                cur_dist += reindeer_stats[i][1]
                work_time -= 1
            else:
                rest_time -= 1
            
            if rest_time == 0:
                rest_time = reindeer_stats[i][3]
                work_time = reindeer_stats[i][2]
            
            cur_max = max(cur_dist, cur_max)
            cur_positions[i] = (cur_dist, work_time, rest_time)

        for i, deer_st in enumerate(cur_positions):
            if deer_st[0] >= cur_max:
                deers_points[reindeer_stats[i][0]] += 1

    print(max(deers_points.values()))
    