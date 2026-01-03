from pathlib import Path


def represents_int(s):
    try: 
        int(s)
    except ValueError:
        return False
    else:
        return True

with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    answ = 0

    for vals in file.read().strip().split(","):
        for v in vals.split(":"):
            v = v.replace("[", "").replace("{", "").replace("]", "").replace("}", "").strip()
            
            if represents_int(v):
                answ += int(v)
    print(answ)
