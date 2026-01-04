from pathlib import Path


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    answer = 0
    vowels = set("aeiou")
    invalid_letters = {"ab", "cd", "pq", "xy"}
        
    for line in file.readlines():
        vowels_count = 0 + (line[-1] in vowels)
        is_twice_in_a_row_exists = False
        contain_invalid_letters = False

        for i in range(len(line)-1):
            cur_char = line[i]
            next_char = line[i+1]

            if vowels_count <= 3 and cur_char in vowels:
                vowels_count += 1
        
            if not is_twice_in_a_row_exists and cur_char == next_char:
                is_twice_in_a_row_exists = True
                
            if cur_char+next_char in invalid_letters:
                contain_invalid_letters = True
                break

        if vowels_count >= 3 and is_twice_in_a_row_exists and not contain_invalid_letters:
            answer += 1
   
    print(answer)
