from pathlib import Path


with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    prev_passw = file.read().strip()
    corporate_alphabet = {
        "a": "b", "b": "c", "c": "d", "d": "e", "e": "f", "f": "g", "g": "h", "h": "j",
        "j": "k", "k": "m", "m": "n", "n": "p", "p": "q", "q": "r", "r": "s", "s": "t",
        "t": "u", "u": "v", "v": "w", "w": "x", "x": "y", "y": "z", "z": "a"
    }

    def get_next(pw):
        if pw[-1] != "z":
            return pw[:len(pw)-1] + corporate_alphabet[pw[-1]]
        else:
            return get_next(pw[:len(pw)-1]) + "a"

    while True:
        
        prev_passw = get_next(prev_passw)

        if (sum(char + char in prev_passw for char in "abcdefghjkmnpqrstuvwxyz") >= 2 and
            any(corporate_alphabet[prev_passw[i]] == prev_passw[i+1] and corporate_alphabet[prev_passw[i+1]] == prev_passw[i+2] for i in range(len(prev_passw)-2))):
            break

    print(prev_passw)
