import hashlib
from pathlib import Path
from itertools import count

with open(Path(__file__).resolve().parent / "task_data", "r") as file:
    key = file.read().encode("utf-8") 
    for answer in count(1):

        hash_str = hashlib.md5(key + (str(answer)).encode("utf-8")).hexdigest()

        if hash_str.startswith("000000"):
            print(answer)
            break

        answer += 1
