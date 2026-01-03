from pathlib import Path


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    answ = 0
    
    for line in file.readlines():
        reindeer, _, _, speed_kmsec, _, _, time_sec, _, _, _, _, _, _, rest_time_sec, _ = line.strip().split()
        time_sec = int(time_sec)
        rest_time_sec = int(rest_time_sec)
        dist = int(speed_kmsec) * time_sec
        dist_passed = 0
        time_to_race_sec = 2503
        while time_to_race_sec > 0:
            dist_passed += dist
            time_to_race_sec -= time_sec

            if time_to_race_sec <= 0:
                dist_passed -= time_to_race_sec * -1 * int(speed_kmsec)
                break
            time_to_race_sec -= rest_time_sec

        answ = max(answ, dist_passed)
         
    print(answ)
    