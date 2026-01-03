from pathlib import Path
from collections import defaultdict


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    answer = 0
    
    for line in file.readlines():

        line = line.strip() + "10"
        dict_pairs_letters = defaultdict(int)
        is_between_same_latter = False
        is_double_pair_letter = False

        for i in range(len(line)-2):
            left, mid, right = line[i], line[i+1], line[i+2]

            if not is_between_same_latter and left == right: is_between_same_latter = True
            
            dict_pairs_letters[left+mid] += not (left == mid == right) or line[i-1] == left == mid == right
            if not is_double_pair_letter and dict_pairs_letters[left+mid] >= 2: is_double_pair_letter = True

            if is_between_same_latter and is_double_pair_letter:
                answer += 1
                break

    print(answer)


