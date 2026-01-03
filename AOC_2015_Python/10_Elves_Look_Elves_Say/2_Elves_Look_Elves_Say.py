from pathlib import Path


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    
    prev_puz = list(file.read().strip() + "]")
    st = len(prev_puz)-1

    for _ in range(50):
        next_puz = []
        count_digit = 1
        for i in range(len(prev_puz)-1):
            if prev_puz[i] != prev_puz[i+1]:
                next_puz.append(str(count_digit))
                next_puz.append(prev_puz[i])
                count_digit = 1
            else:
                count_digit += 1
        next_puz.append("]")
        prev_puz = next_puz

    print(len(next_puz)-1)

# 3113322113

# 3
# 13
# 1113
# 3113
# 132113
# 1113122113
# 311311222113
# 13211321322113
# 1113122113121113222113
# 3113112221131112_3113322113