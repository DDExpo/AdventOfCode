from collections import defaultdict
from pathlib import Path
from pprint import pprint

with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    possible_replacements = defaultdict(list)
    medicine_molecule     = ""
    answ = set()
    
    for line in file.readlines():
        line = line.strip()

        if len(line) > 100 or not line:
            medicine_molecule = line.strip()
            continue

        molecules = line.split("=>")
        possible_replacements[molecules[0].strip()].append(molecules[1].strip())

    pprint(possible_replacements)
    print(len(medicine_molecule))
