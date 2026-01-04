import re
from pathlib import Path
from collections import defaultdict

with open(Path(__file__).resolve().parent / "task_data", "r") as file:

    possible_replacements = defaultdict(list)
    medicine_molecule     = ""

    for line in file.readlines():
        line = line.strip()
        if len(line) > 100 or not line:
            medicine_molecule = line.strip()
            continue

        molecules = line.split("=>")
        possible_replacements[molecules[0].strip()].append(molecules[1].strip())

    # EBATI
    # ChatGPt solution is too good
    elements = re.findall(r"[A-Z][a-z]?", medicine_molecule)
    steps = (
        len(elements)
        - medicine_molecule.count("Rn")
        - medicine_molecule.count("Ar")
        - 2 * medicine_molecule.count("Y")
        - 1
    )
    print(steps)
