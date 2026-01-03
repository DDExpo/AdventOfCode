from pathlib import Path


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    answ = 0

    for line in file.readlines():
        line = line.strip()
        answ += len(line) - len(eval(line))

    print(answ)
