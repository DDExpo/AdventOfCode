from pathlib import Path


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    prev_puz = file.read().strip() + "]"
    for _ in range(40):
        next_puz = ""
        count_digit = 1
        for i in range(len(prev_puz)-1):
            if prev_puz[i] != prev_puz[i+1]:
                next_puz += str(count_digit) + prev_puz[i]
                count_digit = 1
            else:
                count_digit += 1
        prev_puz = next_puz + "]"
    print(len(next_puz))
