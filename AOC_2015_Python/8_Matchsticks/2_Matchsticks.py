from pathlib import Path


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    answ = 0
    for line in file.readlines():
        answ += line.count('"') + line.count('\\') + 2

    print(answ)
